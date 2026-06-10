from django.shortcuts import render, redirect
from django.contrib import messages
from django.views.decorators.csrf import csrf_exempt
from django.views.decorators.http import require_POST
from django.http import HttpResponse, JsonResponse
from django.conf import settings
from django.contrib.contenttypes.models import ContentType
from orders.models import Order, OrderItem, ShippingLocation, PaymentStatus
from library.models import LibraryAccess
from redirects.models import RedirectCode
from books.models import Book
from products.models import CustomProduct
import mercadopago
import json


def get_mercadopago_sdk():
    """Initialize MercadoPago SDK"""
    # LOG: Verificar credenciales
    public_key = settings.MERCADOPAGO_PUBLIC_KEY
    access_token = settings.MERCADOPAGO_ACCESS_TOKEN
    
    print("\n" + "="*60)
    print("🔑 VERIFICACIÓN DE CREDENCIALES MERCADOPAGO")
    print("="*60)
    print(f"Public Key: {public_key}")
    print(f"Access Token: {access_token[:20]}...{access_token[-10:]}")
    
    if public_key.startswith('TEST-') and access_token.startswith('TEST-'):
        print("✅ MODO: PRUEBAS (TEST) - Correcto para desarrollo")
    else:
        print("⚠️  MODO: PRODUCCIÓN - ¡Cuidado! Usando credenciales reales")
    print("="*60 + "\n")
    
    sdk = mercadopago.SDK(access_token)
    return sdk


def checkout(request):
    """Checkout page - create MercadoPago preference"""
    if request.method != 'POST':
        return redirect('core:cart')
    
    cart = request.session.get('cart', {})
    if not cart:
        messages.error(request, 'Your cart is empty')
        return redirect('core:cart')
    
    # Get shipping location
    shipping_location = request.POST.get('shipping_location')
    email = request.POST.get('email')
    
    if not shipping_location or not email:
        messages.error(request, 'Please select shipping location and provide email')
        return redirect('core:cart')
    
    # Create order
    order = Order.objects.create(
        user=request.user if request.user.is_authenticated else None,
        email=email,
        shipping_location=shipping_location
    )

    # Capturar datos de envío extendidos
    full_name = request.POST.get('full_name')
    phone = request.POST.get('phone')
    address = request.POST.get('address')
    city = request.POST.get('city')
    department = request.POST.get('department')

    from orders.models import ShippingAddress
    ShippingAddress.objects.create(
        order=order,
        full_name=full_name,
        phone=phone,
        address=address,
        city=city,
        department=department
    )
    
    # Add items to order
    items = []
    for key, item_data in cart.items():
        item_type, item_id = key.split('_')
        
        if item_type == 'book':
            book = Book.objects.get(id=item_id)
            OrderItem.objects.create(
                order=order,
                content_type=ContentType.objects.get_for_model(Book),
                object_id=book.id,
                quantity=item_data['quantity'],
                price=book.price
            )
            items.append({
                'title': book.title,
                'quantity': item_data['quantity'],
                'currency_id': 'COP',
                'unit_price': float(book.price),
            })
        elif item_type == 'product':
            product = CustomProduct.objects.get(id=item_id)
            OrderItem.objects.create(
                order=order,
                content_type=ContentType.objects.get_for_model(CustomProduct),
                object_id=product.id,
                quantity=item_data['quantity'],
                price=product.base_price
            )
            items.append({
                'title': f"{product.get_product_type_display()}",
                'quantity': item_data['quantity'],
                'currency_id': 'COP',
                'unit_price': float(product.base_price),
            })
    
    # Calculate totals
    order.calculate_totals()
    
    # Add shipping as an item if applicable
    if order.shipping_cost > 0:
        items.append({
            'title': 'Shipping',
            'quantity': 1,
            'currency_id': 'COP',
            'unit_price': float(order.shipping_cost),
        })
    
    # Create MercadoPago preference
    sdk = get_mercadopago_sdk()
    
    # Check if MercadoPago is properly configured
    if not settings.MERCADOPAGO_PUBLIC_KEY or not settings.MERCADOPAGO_ACCESS_TOKEN or \
       settings.MERCADOPAGO_PUBLIC_KEY == 'TEST-your-public-key-here':
        # MercadoPago not configured - show order summary without payment
        messages.warning(request, f'Orden creada: {order.order_number}. Configure MercadoPago para procesar pagos.')
        context = {
            'order': order,
            'preference_id': None,
            'public_key': None,
            'mp_not_configured': True,
        }
        return render(request, 'payments/checkout.html', context)
    
    back_urls = {
        'success': request.build_absolute_uri('/payments/success/'),
        'failure': request.build_absolute_uri('/payments/failure/'),
        'pending': request.build_absolute_uri('/payments/pending/'),
    }
    
    # CHEQUEO 1: Datos de Items
    print("\n" + "="*50)
    print("CHEQUEO 1: Items a enviar")
    print(json.dumps(items, indent=2))
    
    # CHEQUEO 2: URLs de retorno
    print("-" * 50)
    print("CHEQUEO 2: Back URLs")
    print(json.dumps(back_urls, indent=2))

    payer_info = {
        'email': email,
    }
    
    # Si el usuario está autenticado, intentamos enviar nombre y apellido si existen
    if request.user.is_authenticated:
        if request.user.first_name:
            payer_info['name'] = request.user.first_name
        if request.user.last_name:
            payer_info['surname'] = request.user.last_name

    preference_data = {
        'items': items,
        'payer': payer_info,
        'back_urls': back_urls,
        'auto_return': 'approved',
        'external_reference': str(order.order_number),
        'notification_url': request.build_absolute_uri('/payments/webhook/'),
        'statement_descriptor': 'MINILIBROS',
        'binary_mode': True,
    }
    
    # CHEQUEO 3: Payload completo
    print("-" * 50)
    print("CHEQUEO 3: Payload completo a MercadoPago")
    print(json.dumps(preference_data, indent=2))
    print("="*50 + "\n")
    
    try:
        preference_response = sdk.preference().create(preference_data)
        
        # CHEQUEO 4: Respuesta de MercadoPago
        print("\n" + "="*50)
        print("CHEQUEO 4: Respuesta de MercadoPago")
        print(f"Status: {preference_response.get('status')}")
        print(f"Response Body: {json.dumps(preference_response.get('response', {}), indent=2)}")
        print("="*50 + "\n")
        
        if preference_response.get('status') not in [200, 201]:
            error_detail = preference_response.get('response', {})
            print(f"MercadoPago Error: {error_detail}") # Log error to console
            messages.error(request, f'Error MP ({preference_response.get("status")}): {error_detail.get("message", "Error desconocido")}')
            return redirect('core:cart')
        
        preference = preference_response.get('response', {})
        preference_id = preference.get('id')
        
        if not preference_id:
            messages.error(request, 'Error: No se recibió ID de preferencia de MercadoPago.')
            return redirect('core:cart')
        
        context = {
            'order': order,
            'preference_id': preference_id,
            'public_key': settings.MERCADOPAGO_PUBLIC_KEY,
        }
        
        return render(request, 'payments/checkout.html', context)
        
    except Exception as e:
        import traceback
        traceback.print_exc()
        messages.error(request, f'Error técnico: {str(e)}')
        return redirect('core:cart')


def payment_success(request):
    """Payment success callback"""
    payment_id = request.GET.get('payment_id')
    external_reference = request.GET.get('external_reference')
    
    # LOG: Entrada a payment_success
    print("\n" + "="*60)
    print("✅ CALLBACK: payment_success() - PAGO EXITOSO")
    print("="*60)
    print(f"Payment ID: {payment_id}")
    print(f"Order Number (external_reference): {external_reference}")
    print(f"Parámetros GET completos: {dict(request.GET)}")
    
    if external_reference:
        try:
            order = Order.objects.get(order_number=external_reference)
            
            print(f"\n📦 ORDEN ENCONTRADA:")
            print(f"  - ID Orden: {order.order_number}")
            print(f"  - Email: {order.email}")
            print(f"  - Usuario asociado: {order.user.username if order.user else 'INVITADO (sin usuario)'}")
            print(f"  - Estado anterior: {order.payment_status}")
            print(f"  - Total: ${order.total}")
            
            # ALWAYS update payment status, even for guest users
            order.payment_status = PaymentStatus.COMPLETED
            order.payment_id = payment_id
            order.save()
            
            print(f"  - Estado actualizado a: {order.payment_status}")
            print(f"  - Payment ID guardado: {payment_id}")
            
            # Grant library access ONLY if user is authenticated
            if order.user:
                print(f"\n🎁 OTORGANDO ACCESO A BIBLIOTECA (usuario: {order.user.username})")
                items_count = 0
                for item in order.items.all():
                    LibraryAccess.objects.get_or_create(
                        user=order.user,
                        content_type=item.content_type,
                        object_id=item.object_id
                    )
                    
                    # Create redirect code for this item
                    RedirectCode.objects.get_or_create(
                        content_type=item.content_type,
                        object_id=item.object_id,
                        user=order.user
                    )
                    items_count += 1
                    print(f"  ✓ Acceso otorgado: {item.content_object}")
                    
                print(f"  Total items otorgados: {items_count}")
            else:
                print(f"\n⏭️  ACCESO NO OTORGADO (usuario invitado - esperando registro)")
            
            # Clear cart
            request.session['cart'] = {}
            request.session.modified = True
            print(f"\n🛒 Carrito limpiado")
            
            # Redirect to registration if guest user
            if not order.user:
                print(f"🔀 Redirigiendo a registro de usuario invitado")
                print("="*60 + "\n")
                messages.success(request, '¡Pago completado! Crea una cuenta para acceder a tus compras.')
                return redirect('orders:post_purchase_register', order_number=order.order_number)
            
            print(f"🔀 Redirigiendo a biblioteca del usuario")
            print("="*60 + "\n")
            messages.success(request, '¡Pago exitoso! Tus productos están en tu biblioteca.')
            return redirect('library:my_library')
            
        except Order.DoesNotExist:
            print(f"\n❌ ERROR: Orden {external_reference} no encontrada en la base de datos")
            print("="*60 + "\n")
            messages.error(request, 'No se encontró la orden.')
            return redirect('core:home')
    
    print(f"\n⚠️  WARNING: No se recibió external_reference")
    print("="*60 + "\n")
    messages.success(request, '¡Pago completado!')
    return redirect('core:home')


def payment_failure(request):
    """Payment failure callback"""
    external_reference = request.GET.get('external_reference')
    
    if external_reference:
        try:
            order = Order.objects.get(order_number=external_reference)
            order.payment_status = PaymentStatus.FAILED
            order.save()
        except Order.DoesNotExist:
            pass
    
    messages.error(request, 'Payment failed. Please try again.')
    return redirect('core:cart')


def payment_pending(request):
    """Payment pending callback - también se llama cuando PSE aprueba el pago.
    
    PSE (y otras transferencias bancarias) siempre redirigen aquí, incluso si
    el pago fue aprobado. Por eso consultamos la API de MercadoPago con el
    payment_id para obtener el estado real del pago.
    """
    payment_id = request.GET.get('payment_id')
    external_reference = request.GET.get('external_reference')
    payment_status_mp = request.GET.get('payment_status')  # estado que MP pasa por GET
    
    print("\n" + "="*60)
    print("⏳ CALLBACK: payment_pending() - PAGO PENDIENTE/PSE")
    print("="*60)
    print(f"Payment ID: {payment_id}")
    print(f"Order Number (external_reference): {external_reference}")
    print(f"Status en URL: {payment_status_mp}")
    print(f"Parámetros GET completos: {dict(request.GET)}")
    
    if not external_reference:
        print("⚠️  Sin external_reference - redirigiendo a home")
        print("="*60 + "\n")
        return redirect('core:home')
    
    try:
        order = Order.objects.get(order_number=external_reference)
    except Order.DoesNotExist:
        print(f"❌ Orden {external_reference} no encontrada")
        print("="*60 + "\n")
        return redirect('core:home')
    
    # Si hay payment_id, consultar la API de MercadoPago para el estado real
    real_status = payment_status_mp  # fallback al status en URL
    if payment_id:
        try:
            sdk = get_mercadopago_sdk()
            payment_info = sdk.payment().get(payment_id)
            print(f"\nRespuesta MP status: {payment_info.get('status')}")
            
            if payment_info.get('status') == 200:
                payment_data = payment_info['response']
                real_status = payment_data.get('status')
                print(f"Estado real del pago (API): {real_status}")
                print(f"Estado detallado: {payment_data.get('status_detail')}")
            else:
                print(f"Error consultando API MP: {payment_info.get('status')}")
        except Exception as e:
            print(f"Error al consultar API MP: {e}")
            import traceback
            traceback.print_exc()
    
    if real_status == 'approved':
        # PSE aprobado - tratar igual que payment_success
        print(f"\n✅ PAGO PSE APROBADO - Actualizando orden {order.order_number}")
        order.payment_status = PaymentStatus.COMPLETED
        order.payment_id = payment_id
        order.save()
        print(f"  - Estado actualizado a: COMPLETED")
        
        # Otorgar acceso a biblioteca si hay usuario autenticado
        if order.user:
            print(f"\n🎁 OTORGANDO ACCESO A BIBLIOTECA (usuario: {order.user.username})")
            for item in order.items.all():
                LibraryAccess.objects.get_or_create(
                    user=order.user,
                    content_type=item.content_type,
                    object_id=item.object_id
                )
                RedirectCode.objects.get_or_create(
                    content_type=item.content_type,
                    object_id=item.object_id,
                    user=order.user
                )
                print(f"  ✓ Acceso otorgado: {item.content_object}")
        else:
            print(f"\n⏭️  Usuario invitado - acceso pendiente de registro")
        
        # Limpiar carrito
        request.session['cart'] = {}
        request.session.modified = True
        print(f"\n🛒 Carrito limpiado")
        print("="*60 + "\n")
        
        return redirect('payments:payment_confirmation', order_number=str(order.order_number))
    
    else:
        # Pago genuinamente pendiente (ej: efectivo, transferencia lenta)
        print(f"\n⏳ Pago en estado: {real_status} - guardando como PENDING")
        order.payment_status = PaymentStatus.PENDING
        if payment_id:
            order.payment_id = payment_id
        order.save()
        
        # Limpiar carrito de todas formas
        request.session['cart'] = {}
        request.session.modified = True
        print("="*60 + "\n")
        
        return redirect('payments:payment_confirmation', order_number=str(order.order_number))


def payment_confirmation(request, order_number):
    """Página de confirmación post-pago (para PSE aprobado o pago pendiente)"""
    try:
        order = Order.objects.get(order_number=order_number)
    except Order.DoesNotExist:
        return redirect('core:home')
    
    context = {
        'order': order,
        'is_approved': order.payment_status == PaymentStatus.COMPLETED,
        'user_authenticated': request.user.is_authenticated,
    }
    return render(request, 'payments/pending.html', context)


def verify_payment(request, order_number):
    """Vista para verificar manualmente el estado de un pago PSE.
    
    En sandbox (y con localhost), MercadoPago NO redirige al back_url después
    de PSE. El usuario usa este botón desde el checkout para verificar su pago.
    Busca el pago en la API de MP usando el external_reference (order_number).
    """
    print("\n" + "="*60)
    print("🔍 VERIFICACIÓN MANUAL DE PAGO PSE")
    print("="*60)
    print(f"Buscando pago para orden: {order_number}")
    
    try:
        order = Order.objects.get(order_number=order_number)
    except Order.DoesNotExist:
        print(f"❌ Orden {order_number} no encontrada")
        print("="*60 + "\n")
        return redirect('core:home')
    
    # Si ya está completado, ir directamente a la confirmación
    if order.payment_status == PaymentStatus.COMPLETED:
        print(f"✅ Orden ya marcada como COMPLETED, redirigiendo a confirmación")
        print("="*60 + "\n")
        return redirect('payments:payment_confirmation', order_number=str(order.order_number))
    
    try:
        sdk = get_mercadopago_sdk()
        
        # Buscar pagos por external_reference (número de orden)
        search_result = sdk.payment().search({
            "external_reference": str(order_number),
            "sort": "date_created",
            "criteria": "desc",
        })
        
        print(f"Respuesta búsqueda MP: {search_result.get('status')}")
        
        if search_result.get('status') == 200:
            payments = search_result['response'].get('results', [])
            print(f"Pagos encontrados: {len(payments)}")
            
            approved_payment = None
            for p in payments:
                print(f"  - Payment ID: {p.get('id')}, Status: {p.get('status')}, Status detail: {p.get('status_detail')}")
                if p.get('status') == 'approved':
                    approved_payment = p
                    break
            
            if approved_payment:
                print(f"\n✅ PAGO APROBADO ENCONTRADO: ID {approved_payment['id']}")
                order.payment_status = PaymentStatus.COMPLETED
                order.payment_id = str(approved_payment['id'])
                order.save()
                print(f"  - Orden actualizada a COMPLETED")
                
                # Otorgar acceso a biblioteca
                if order.user:
                    print(f"🎁 Otorgando acceso a biblioteca...")
                    for item in order.items.all():
                        LibraryAccess.objects.get_or_create(
                            user=order.user,
                            content_type=item.content_type,
                            object_id=item.object_id
                        )
                        RedirectCode.objects.get_or_create(
                            content_type=item.content_type,
                            object_id=item.object_id,
                            user=order.user
                        )
                        print(f"  ✓ Acceso: {item.content_object}")
                
                # Limpiar carrito
                request.session['cart'] = {}
                request.session.modified = True
                print("="*60 + "\n")
                return redirect('payments:payment_confirmation', order_number=str(order.order_number))
            
            else:
                # No hay pago aprobado aún — mostrar página informativa de todos modos
                print(f"⏳ No se encontró pago aprobado. Mostrando página de espera.")
                # Guardar el payment_id del más reciente si existe
                if payments:
                    order.payment_id = str(payments[0].get('id', ''))
                    order.save()
                print("="*60 + "\n")
                return redirect('payments:payment_confirmation', order_number=str(order.order_number))
        
        else:
            print(f"❌ Error consultando API MP: {search_result.get('status')}")
            print("="*60 + "\n")
            return redirect('payments:payment_confirmation', order_number=str(order.order_number))
    
    except Exception as e:
        print(f"❌ ERROR en verify_payment: {e}")
        import traceback
        traceback.print_exc()
        print("="*60 + "\n")
        return redirect('payments:payment_confirmation', order_number=str(order.order_number))


@csrf_exempt
@require_POST
def mercadopago_webhook(request):
    """MercadoPago IPN webhook"""
    print("\n" + "="*60)
    print("🔔 WEBHOOK: mercadopago_webhook() - NOTIFICACIÓN IPN")
    print("="*60)
    
    try:
        data = json.loads(request.body)
        print(f"Tipo de notificación: {data.get('type')}")
        print(f"Datos recibidos: {json.dumps(data, indent=2)}")
        
        if data.get('type') == 'payment':
            payment_id = data['data']['id']
            print(f"\nConsultando detalles del pago ID: {payment_id}")
            
            # Get payment details from MercadoPago
            sdk = get_mercadopago_sdk()
            payment_info = sdk.payment().get(payment_id)
            
            print(f"Status de respuesta MercadoPago: {payment_info['status']}")
            
            if payment_info['status'] == 200:
                payment = payment_info['response']
                external_reference = payment.get('external_reference')
                payment_status = payment.get('status')
                
                print(f"\n💳 INFORMACIÓN DEL PAGO:")
                print(f"  - Estado del pago: {payment_status}")
                print(f"  - Orden (external_reference): {external_reference}")
                print(f"  - Monto: {payment.get('transaction_amount')} {payment.get('currency_id')}")
                
                if external_reference:
                    order = Order.objects.get(order_number=external_reference)
                    print(f"\n📦 ORDEN ENCONTRADA:")
                    print(f"  - Email: {order.email}")
                    print(f"  - Usuario: {order.user.username if order.user else 'INVITADO'}")
                    print(f"  - Estado anterior: {order.payment_status}")
                    
                    if payment['status'] == 'approved':
                        print(f"\n✅ PAGO APROBADO - Actualizando orden")
                        # ALWAYS update payment status, even for guest users
                        order.payment_status = PaymentStatus.COMPLETED
                        order.payment_id = payment_id
                        order.save()
                        print(f"  - Estado actualizado a: COMPLETED")
                        
                        # Grant library access ONLY if user exists
                        if order.user:
                            print(f"\n🎁 OTORGANDO ACCESO (webhook) para usuario: {order.user.username}")
                            items_count = 0
                            for item in order.items.all():
                                LibraryAccess.objects.get_or_create(
                                    user=order.user,
                                    content_type=item.content_type,
                                    object_id=item.object_id
                                )
                                
                                RedirectCode.objects.get_or_create(
                                    content_type=item.content_type,
                                    object_id=item.object_id,
                                    user=order.user
                                )
                                items_count += 1
                                print(f"  ✓ Acceso otorgado: {item.content_object}")
                            print(f"  Total items: {items_count}")
                        else:
                            print(f"  ⏭️  Usuario invitado - acceso pendiente de registro")
                    
                    elif payment['status'] == 'rejected':
                        print(f"\n❌ PAGO RECHAZADO")
                        order.payment_status = PaymentStatus.FAILED
                        order.save()
                        print(f"  - Estado actualizado a: FAILED")
        
        print("✓ Webhook procesado exitosamente")
        print("="*60 + "\n")
        return HttpResponse(status=200)
    except Exception as e:
        print(f"\n❌ ERROR EN WEBHOOK: {str(e)}")
        import traceback
        traceback.print_exc()
        print("="*60 + "\n")
        return HttpResponse(status=500)

