from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth.models import User
from django.contrib.auth import login
from django.contrib import messages
from .models import Order, PaymentStatus
from library.models import LibraryAccess
from redirects.models import RedirectCode


def _link_orders_to_user(user):
    """Vincula todas las órdenes de invitado con el email del usuario,
    y otorga acceso a biblioteca para las órdenes completadas."""
    guest_orders = Order.objects.filter(email=user.email, user__isnull=True)
    linked = 0
    for order in guest_orders:
        order.user = user
        order.save()
        linked += 1
        # Si el pago estaba completado, otorgar acceso a biblioteca
        if order.payment_status == PaymentStatus.COMPLETED:
            for item in order.items.all():
                LibraryAccess.objects.get_or_create(
                    user=user,
                    content_type=item.content_type,
                    object_id=item.object_id
                )
                RedirectCode.objects.get_or_create(
                    content_type=item.content_type,
                    object_id=item.object_id,
                    user=user
                )
    return linked


def post_purchase_register(request, order_number):
    """Post-purchase registration for guest users"""
    order = get_object_or_404(Order, order_number=order_number)

    if request.method == 'POST':
        email = request.POST.get('email')
        password = request.POST.get('password')

        # Verificar si el email ya existe
        if User.objects.filter(email=email).exists() or User.objects.filter(username=email).exists():
            messages.error(request, 'Ya existe una cuenta con ese correo. Por favor inicia sesión.')
            return render(request, 'orders/post_purchase_register.html', {'order': order})

        # Crear cuenta nueva
        user = User.objects.create_user(username=email, email=email, password=password)
        # Especificar backend explícitamente (requerido cuando hay múltiples backends)
        user.backend = 'django.contrib.auth.backends.ModelBackend'

        # Assign user to any guest-created custom products in this order
        from products.models import CustomProduct
        from django.contrib.contenttypes.models import ContentType
        product_ct = ContentType.objects.get_for_model(CustomProduct)
        for item in order.items.filter(content_type=product_ct):
            custom_product = CustomProduct.objects.get(id=item.object_id)
            if not custom_product.user:
                custom_product.user = user
                custom_product.save()

        # Update shipping address if provided
        from .models import ShippingAddress
        full_name = request.POST.get('full_name', '')
        address = request.POST.get('address', '')
        city = request.POST.get('city', '')
        phone = request.POST.get('phone', '')
        if full_name or address:
            ShippingAddress.objects.update_or_create(
                order=order,
                defaults={
                    'full_name': full_name,
                    'address': address,
                    'city': city,
                    'phone': phone,
                    'additional_info': request.POST.get('additional_info', ''),
                }
            )

        # Vincular TODAS las órdenes de invitado con este email (incluida la actual)
        linked = _link_orders_to_user(user)

        login(request, user)
        messages.success(request, f'¡Cuenta creada! Se vincularon {linked} orden(es) a tu cuenta.')
        return redirect('library:my_library')

    context = {
        'order': order,
    }
    return render(request, 'orders/post_purchase_register.html', context)
