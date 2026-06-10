from django.contrib import admin
from django.contrib.contenttypes.models import ContentType
from .models import LibraryAccess, PDFAnnotation, ReaderSettings
from books.models import Book


class LibraryAccessInline(admin.TabularInline):
    """Inline for granting library access directly from a Book"""
    model = LibraryAccess
    extra = 1
    fields = ['user']
    verbose_name = "Acceso de usuario"
    verbose_name_plural = "Dar acceso a usuarios"

    def get_queryset(self, request):
        qs = super().get_queryset(request)
        book_ct = ContentType.objects.get_for_model(Book)
        return qs.filter(content_type=book_ct)

    def save_model(self, request, obj, form, change):
        if not obj.content_type_id:
            obj.content_type = ContentType.objects.get_for_model(Book)
        super().save_model(request, obj, form, change)


@admin.register(LibraryAccess)
class LibraryAccessAdmin(admin.ModelAdmin):
    list_display = ['user', 'content_type', 'object_id', 'content_object_display', 'purchased_at']
    list_filter = ['purchased_at', 'content_type']
    search_fields = ['user__username', 'user__email']
    readonly_fields = ['purchased_at', 'last_accessed', 'content_object_display']
    fields = ['user', 'content_type', 'object_id', 'content_object_display', 'purchased_at', 'last_accessed']

    def content_object_display(self, obj):
        try:
            return str(obj.content_object)
        except Exception:
            return '—'
    content_object_display.short_description = 'Objeto vinculado'


@admin.register(PDFAnnotation)
class PDFAnnotationAdmin(admin.ModelAdmin):
    list_display = ['library_access', 'annotation_type', 'page_number', 'created_at']
    list_filter = ['annotation_type', 'created_at']
    readonly_fields = ['created_at', 'updated_at']


@admin.register(ReaderSettings)
class ReaderSettingsAdmin(admin.ModelAdmin):
    list_display = ['user', 'theme', 'font_size', 'updated_at']
    list_filter = ['theme']
    search_fields = ['user__username']

