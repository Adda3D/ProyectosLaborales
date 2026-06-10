from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth import login, logout, authenticate
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib import messages
from django.http import JsonResponse
from django.views.decorators.http import require_POST
from django.views.decorators.csrf import csrf_exempt
from django.contrib.contenttypes.models import ContentType
from books.models import Book
from products.models import CustomProduct
import json


def home(request):
    """Home page with featured book listing"""
    # Solo mostramos los 8 libros más recientes en el landing
    books = Book.objects.filter(is_available=True).order_by('-created_at')[:8]
    return render(request, 'core/index.html', {'books': books})


def cart_view(request):
    """View shopping cart"""
    cart = request.session.get('cart', {})
    cart_items = []
    subtotal = 0
    
    for key, item_data in cart.items():
        item_type, item_id = key.split('_')
        
        if item_type == 'book':
            try:
                book = Book.objects.get(id=item_id)
                cart_items.append({
                    'type': 'book',
                    'id': book.id,
                    'title': book.title,
                    'price': book.price,
                    'quantity': item_data['quantity'],
                    'cover_image': book.cover_image.url if book.cover_image else None,
                    'total': book.price * item_data['quantity']
                })
                subtotal += book.price * item_data['quantity']
            except Book.DoesNotExist:
                continue
        elif item_type == 'product':
            try:
                product = CustomProduct.objects.get(id=item_id)
                cart_items.append({
                    'type': 'product',
                    'id': product.id,
                    'title': f"{product.get_product_type_display()}",
                    'price': product.base_price,
                    'quantity': item_data['quantity'],
                    'cover_image': product.cover_image.url if product.cover_image else None,
                    'total': product.base_price * item_data['quantity']
                })
                subtotal += product.base_price * item_data['quantity']
            except CustomProduct.DoesNotExist:
                continue
    
    context = {
        'cart_items': cart_items,
        'subtotal': subtotal,
    }
    return render(request, 'core/cart.html', context)


@require_POST
def add_to_cart(request):
    """Add item to cart via AJAX"""
    try:
        data = json.loads(request.body)
        item_type = data.get('type')  # 'book' or 'product'
        item_id = data.get('id')
        quantity = int(data.get('quantity', 1))
        
        cart = request.session.get('cart', {})
        key = f"{item_type}_{item_id}"
        
        if key in cart:
            cart[key]['quantity'] += quantity
        else:
            cart[key] = {'quantity': quantity}
        
        request.session['cart'] = cart
        request.session.modified = True
        
        # Calculate cart count
        cart_count = sum(item['quantity'] for item in cart.values())
        
        return JsonResponse({
            'success': True,
            'message': 'Item added to cart',
            'cart_count': cart_count
        })
    except Exception as e:
        return JsonResponse({'success': False, 'message': str(e)}, status=400)


def remove_from_cart(request, item_type, item_id):
    """Remove item from cart"""
    cart = request.session.get('cart', {})
    key = f"{item_type}_{item_id}"
    
    if key in cart:
        del cart[key]
        request.session['cart'] = cart
        request.session.modified = True
        messages.success(request, 'Item removed from cart')
    
    return redirect('core:cart')


@require_POST
def update_cart(request):
    """Update cart quantities"""
    try:
        data = json.loads(request.body)
        cart = request.session.get('cart', {})
        
        for key, quantity in data.items():
            if key in cart:
                cart[key]['quantity'] = int(quantity)
        
        request.session['cart'] = cart
        request.session.modified = True
        
        return JsonResponse({'success': True})
    except Exception as e:
        return JsonResponse({'success': False, 'message': str(e)}, status=400)


def login_view(request):
    """User login"""
    if request.method == 'POST':
        form = AuthenticationForm(request, data=request.POST)
        if form.is_valid():
            user = form.get_user()
            login(request, user)
            # Vincular órdenes de invitado con este email al iniciar sesión
            from orders.models import Order, PaymentStatus
            from library.models import LibraryAccess
            from redirects.models import RedirectCode
            guest_orders = Order.objects.filter(email=user.email, user__isnull=True)
            if guest_orders.exists():
                guest_orders.update(user=user)
                # Otorgar acceso para órdenes completadas
                completed = Order.objects.filter(email=user.email, user=user, payment_status=PaymentStatus.COMPLETED)
                for order in completed:
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
            next_url = request.GET.get('next', 'core:home')
            return redirect(next_url)
    else:
        form = AuthenticationForm()
    
    return render(request, 'core/login.html', {'form': form})


from .forms import UserRegistrationForm
from orders.models import Order
from products.models import CustomProduct

def register_view(request):
    """User registration"""
    if request.method == 'POST':
        form = UserRegistrationForm(request.POST)
        if form.is_valid():
            user = form.save()
            
            print("\n" + "="*60)
            print("👤 REGISTRO DE NUEVO USUARIO")
            print("="*60)
            print(f"Username: {user.username}")
            print(f"Email: {user.email}")
            
            # SOLUCIÓN: Especificar el backend explícitamente
            user.backend = 'django.contrib.auth.backends.ModelBackend'
            
            login(request, user)
            print("✓ Usuario logueado exitosamente")
            
            # Link guest orders to this user based on email
            if user.email:
                from orders.models import PaymentStatus
                from library.models import LibraryAccess
                from redirects.models import RedirectCode
                from django.contrib.contenttypes.models import ContentType
                
                print(f"\n🔍 BUSCANDO ÓRDENES DE INVITADO con email: {user.email}")
                guest_orders = Order.objects.filter(email=user.email, user__isnull=True)
                order_count = guest_orders.count()
                
                print(f"Órdenes de invitado encontradas: {order_count}")
                
                if order_count > 0:
                    print(f"\n📋 LISTADO DE ÓRDENES A VINCULAR:")
                    for idx, order in enumerate(guest_orders, 1):
                        print(f"  {idx}. Orden #{order.order_number}")
                        print(f"     - Estado: {order.payment_status}")
                        print(f"     - Total: ${order.total}")
                        print(f"     - Items: {order.items.count()}")
                    
                    # Link Custom Products first
                    print(f"\n🔗 VINCULANDO PRODUCTOS PERSONALIZADOS...")
                    ct = ContentType.objects.get_for_model(CustomProduct)
                    products_linked = 0
                    for order in guest_orders:
                        for item in order.items.filter(content_type=ct):
                            try:
                                product = CustomProduct.objects.get(id=item.object_id)
                                if not product.user:
                                    product.user = user
                                    product.save()
                                    products_linked += 1
                                    print(f"  ✓ Producto personalizado vinculado")
                            except CustomProduct.DoesNotExist:
                                pass
                    print(f"Total productos personalizados vinculados: {products_linked}")
                    
                    # Link Orders
                    print(f"\n🔗 VINCULANDO ÓRDENES AL USUARIO...")
                    guest_orders.update(user=user)
                    print(f"  ✓ {order_count} órdenes vinculadas")
                    
                    # Grant library access for COMPLETED orders
                    print(f"\n🎁 OTORGANDO ACCESO A BIBLIOTECA (solo órdenes completadas)...")
                    completed_orders = Order.objects.filter(
                        email=user.email, 
                        user=user,
                        payment_status=PaymentStatus.COMPLETED
                    )
                    
                    completed_count = completed_orders.count()
                    print(f"Órdenes completadas: {completed_count}")
                    
                    items_granted = 0
                    for order in completed_orders:
                        print(f"\n  Procesando orden #{order.order_number}:")
                        for item in order.items.all():
                            # Grant library access
                            LibraryAccess.objects.get_or_create(
                                user=user,
                                content_type=item.content_type,
                                object_id=item.object_id
                            )
                            
                            # Create redirect code
                            RedirectCode.objects.get_or_create(
                                content_type=item.content_type,
                                object_id=item.object_id,
                                user=user
                            )
                            items_granted += 1
                            print(f"    ✓ Acceso otorgado: {item.content_object}")
                    
                    print(f"\n📊 RESUMEN:")
                    print(f"  - Órdenes vinculadas: {order_count}")
                    print(f"  - Órdenes completadas: {completed_count}")
                    print(f"  - Items con acceso otorgado: {items_granted}")
                    print(f"  - Productos personalizados: {products_linked}")
                    print("="*60 + "\n")
                    
                    if items_granted > 0:
                        messages.success(request, f'¡Cuenta creada! Hemos vinculado {order_count} compras anteriores y otorgado acceso a {items_granted} productos.')
                    else:
                        messages.success(request, f'¡Cuenta creada! Hemos vinculado {order_count} compras anteriores.')
                else:
                    print("  → No se encontraron órdenes previas")
                    print("="*60 + "\n")
                    messages.success(request, '¡Cuenta creada exitosamente!')
            else:
                print("  → No se proporcionó email")
                print("="*60 + "\n")
                messages.success(request, '¡Cuenta creada exitosamente!')
                
            return redirect('core:home')
    else:
        form = UserRegistrationForm()
    
    return render(request, 'core/register.html', {'form': form})

def logout_view(request):
    """User logout"""
    logout(request)
    messages.success(request, 'Logged out successfully')
    return redirect('core:home')

@csrf_exempt
@require_POST
def firebase_login(request):
    """
    Endpoint to receive Firebase ID Token via AJAX, authenticate the user,
    and log them in using Django's session.
    """
    try:
        data = json.loads(request.body)
        id_token = data.get('idToken')
        
        if not id_token:
            return JsonResponse({'success': False, 'message': 'Token missing'}, status=400)
            
        from core.firebase_auth import FirebaseAuthenticationBackend
        backend = FirebaseAuthenticationBackend()
        user = backend.authenticate(request, id_token=id_token)
        
        if user is not None:
            user.backend = 'core.firebase_auth.FirebaseAuthenticationBackend'
            login(request, user)
            
            # Link guest orders based on email (similar to standard register/login)
            from orders.models import Order, PaymentStatus
            from library.models import LibraryAccess
            from redirects.models import RedirectCode
            
            guest_orders = Order.objects.filter(email=user.email, user__isnull=True)
            if guest_orders.exists():
                guest_orders.update(user=user)
                completed = Order.objects.filter(email=user.email, user=user, payment_status=PaymentStatus.COMPLETED)
                for order in completed:
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
            
            return JsonResponse({'success': True, 'redirect_url': '/'})
        else:
            return JsonResponse({'success': False, 'message': 'Token inválido o error en autenticación'}, status=401)
            
    except Exception as e:
        return JsonResponse({'success': False, 'message': str(e)}, status=500)
