from django.shortcuts import render, redirect
from django.contrib import messages
from .models import CustomProduct, ProductType
from django.conf import settings


def create_cd(request):
    """Create custom mini CD - no login required"""
    if request.method == 'POST':
        # Create product with or without user
        product = CustomProduct.objects.create(
            product_type=ProductType.CD,
            user=request.user if request.user.is_authenticated else None,
            case_color=request.POST.get('case_color'),
            nfc_url=request.POST.get('nfc_url'),
            base_price=settings.PRICE_MINI_CD
        )
        
        if request.FILES.get('cover_image'):
            product.cover_image = request.FILES['cover_image']
            product.save()
        
        # Add to cart
        quantity = int(request.POST.get('quantity', 1))
        cart = request.session.get('cart', {})
        key = f"product_{product.id}"
        cart[key] = {'quantity': quantity}
        request.session['cart'] = cart
        request.session.modified = True
        
        messages.success(request, f'¡{quantity} Mini CD(s) creado(s) y añadido(s) al carrito!')
        return redirect('core:cart')
    
    return render(request, 'products/create_cd.html', {
        'product_type': 'CD',
        'price': settings.PRICE_MINI_CD
    })


def create_vinyl(request):
    """Create custom mini vinyl - no login required"""
    if request.method == 'POST':
        # Create product with or without user
        product = CustomProduct.objects.create(
            product_type=ProductType.VINYL,
            user=request.user if request.user.is_authenticated else None,
            case_color=request.POST.get('case_color'),
            nfc_url=request.POST.get('nfc_url'),
            base_price=settings.PRICE_MINI_VINYL
        )
        
        if request.FILES.get('cover_image'):
            product.cover_image = request.FILES['cover_image']
            product.save()
        
        # Add to cart
        quantity = int(request.POST.get('quantity', 1))
        cart = request.session.get('cart', {})
        key = f"product_{product.id}"
        cart[key] = {'quantity': quantity}
        request.session['cart'] = cart
        request.session.modified = True
        
        messages.success(request, f'¡{quantity} Mini Vinilo(s) creado(s) y añadido(s) al carrito!')
        return redirect('core:cart')
    
    return render(request, 'products/create_vinyl.html', {
        'product_type': 'Vinyl',
        'price': settings.PRICE_MINI_VINYL
    })


def upload_custom_book(request):
    """Upload custom book - no login required"""
    if request.method == 'POST':
        # Create product with or without user
        product = CustomProduct.objects.create(
            product_type=ProductType.CUSTOM_BOOK,
            user=request.user if request.user.is_authenticated else None,
            custom_message=request.POST.get('custom_message'),
            base_price=settings.PRICE_CUSTOM_BOOK
        )
        
        if request.FILES.get('pdf_file'):
            product.pdf_file = request.FILES['pdf_file']
        if request.FILES.get('cover_image'):
            product.cover_image = request.FILES['cover_image']
        
        product.save()
        
        # Add to cart
        quantity = int(request.POST.get('quantity', 1))
        cart = request.session.get('cart', {})
        key = f"product_{product.id}"
        cart[key] = {'quantity': quantity}
        request.session['cart'] = cart
        request.session.modified = True
        
        messages.success(request, f'¡{quantity} Libro(s) personalizado(s) subido(s) y añadido(s) al carrito!')
        return redirect('core:cart')
    
    return render(request, 'products/upload_book.html', {
        'price': settings.PRICE_CUSTOM_BOOK
    })
