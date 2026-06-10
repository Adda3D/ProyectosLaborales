from django.urls import path
from . import views

app_name = 'payments'

urlpatterns = [
    path('checkout/', views.checkout, name='checkout'),
    path('success/', views.payment_success, name='success'),
    path('failure/', views.payment_failure, name='failure'),
    path('pending/', views.payment_pending, name='pending'),
    path('confirmation/<uuid:order_number>/', views.payment_confirmation, name='payment_confirmation'),
    path('verify/<uuid:order_number>/', views.verify_payment, name='verify_payment'),
    path('webhook/', views.mercadopago_webhook, name='webhook'),
]

