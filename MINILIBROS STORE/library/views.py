from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth.decorators import login_required
from django.http import JsonResponse
from django.views.decorators.http import require_POST
from django.contrib.contenttypes.models import ContentType
from .models import LibraryAccess, PDFAnnotation, ReaderSettings, AnnotationType
from books.models import Book
from products.models import CustomProduct
import json
import os


@login_required
def my_library(request):
    """User's digital library"""
    library_items = LibraryAccess.objects.filter(user=request.user).select_related('content_type')

    items = []
    for access in library_items:
        obj = access.content_object
        if obj is None:
            continue  # LibraryAccess apunta a un objeto eliminado

        if isinstance(obj, Book):
            has_file = bool(obj.pdf_file)
            items.append({
                'type': 'book',
                'id': obj.id,
                'title': obj.title,
                'author': obj.author,
                'cover_image': obj.cover_image.url if obj.cover_image else None,
                'pdf_file': obj.pdf_file.url if has_file else None,
            })
        elif isinstance(obj, CustomProduct):
            has_file = bool(obj.pdf_file)
            items.append({
                'type': 'product',
                'id': obj.id,
                'title': obj.get_product_type_display(),
                'cover_image': obj.cover_image.url if obj.cover_image else None,
                'pdf_file': obj.pdf_file.url if has_file else None,
            })

    return render(request, 'library/my_library.html', {'items': items})



@login_required
def pdf_reader(request, content_type, object_id):
    """Reader view — supports both PDF and ePub files"""
    import os
    # Get the library access
    ct = ContentType.objects.get(model=content_type)
    access = get_object_or_404(LibraryAccess, user=request.user, content_type=ct, object_id=object_id)

    obj = access.content_object
    file_url = None
    title = "Document"

    if isinstance(obj, Book):
        file_url = obj.pdf_file.url if obj.pdf_file else None
        title = obj.title
    elif isinstance(obj, CustomProduct):
        if obj.pdf_file:
            file_url = obj.pdf_file.url
            title = obj.get_product_type_display()

    if not file_url:
        return redirect('library:my_library')

    # Detect file type from extension
    _, ext = os.path.splitext(file_url.lower())
    file_type = 'epub' if ext == '.epub' else 'pdf'

    # Get or create reader settings
    settings, _ = ReaderSettings.objects.get_or_create(user=request.user)

    # Get annotations (only relevant for PDF)
    annotations = PDFAnnotation.objects.filter(library_access=access)
    annotations_data = []
    for ann in annotations:
        annotations_data.append({
            'id': ann.id,
            'page': ann.page_number,
            'type': ann.annotation_type,
            'content': ann.content,
            'color': ann.color,
            'position': ann.position_data,
        })

    context = {
        'file_url': file_url,
        'file_type': file_type,
        'title': title,
        'settings': settings,
        'annotations': json.dumps(annotations_data),
        'access_id': access.id,
    }

    return render(request, 'library/reader.html', context)


@login_required
def nfc_book_redirect(request, slug):
    """Redirect from NFC tag URL to the reader for the logged-in user."""
    book = get_object_or_404(Book, slug=slug)
    ct   = ContentType.objects.get_for_model(Book)
    access = LibraryAccess.objects.filter(
        user=request.user,
        content_type=ct,
        object_id=book.id
    ).first()
    if not access:
        return render(request, 'library/no_access.html', {'book': book})
    return redirect('library:pdf_reader', content_type='book', object_id=book.id)



@login_required
@require_POST
def save_annotation(request):
    """Save PDF annotation"""
    try:
        data = json.loads(request.body)
        access_id = data.get('access_id')
        
        access = LibraryAccess.objects.get(id=access_id, user=request.user)
        
        annotation = PDFAnnotation.objects.create(
            library_access=access,
            page_number=data.get('page'),
            annotation_type=data.get('type'),
            content=data.get('content', ''),
            color=data.get('color', '#FFFF00'),
            position_data=data.get('position', {})
        )
        
        return JsonResponse({
            'success': True,
            'annotation_id': annotation.id
        })
    except Exception as e:
        return JsonResponse({'success': False, 'message': str(e)}, status=400)


@login_required
@require_POST
def delete_annotation(request, annotation_id):
    """Delete PDF annotation"""
    try:
        annotation = PDFAnnotation.objects.get(
            id=annotation_id,
            library_access__user=request.user
        )
        annotation.delete()
        return JsonResponse({'success': True})
    except PDFAnnotation.DoesNotExist:
        return JsonResponse({'success': False, 'message': 'Annotation not found'}, status=404)


@login_required
@require_POST
def save_reader_settings(request):
    """Save reader settings"""
    try:
        data = json.loads(request.body)
        settings, _ = ReaderSettings.objects.get_or_create(user=request.user)
        
        if 'theme' in data:
            settings.theme = data['theme']
        if 'font_size' in data:
            settings.font_size = data['font_size']
        if 'background_color' in data:
            settings.background_color = data['background_color']
        if 'text_color' in data:
            settings.text_color = data['text_color']
        
        settings.save()
        
        return JsonResponse({'success': True})
    except Exception as e:
        return JsonResponse({'success': False, 'message': str(e)}, status=400)
