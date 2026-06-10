from django.urls import path
from . import views

app_name = 'orders'

urlpatterns = [
    path('post-purchase-register/<uuid:order_number>/', views.post_purchase_register, name='post_purchase_register'),
]
