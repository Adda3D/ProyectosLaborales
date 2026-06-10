from django.db import models
from django.contrib.auth.models import User
from django.contrib.contenttypes.models import ContentType
from django.contrib.contenttypes.fields import GenericForeignKey
from django.conf import settings
import uuid


class ShippingLocation(models.TextChoices):
    BOGOTA = 'BOGOTA', 'Bogotá'
    OUTSIDE_BOGOTA = 'OUTSIDE', 'Fuera de Bogotá'


class PaymentStatus(models.TextChoices):
    PENDING = 'PENDING', 'Pendiente'
    COMPLETED = 'COMPLETED', 'Completado'
    FAILED = 'FAILED', 'Fallido'


class Order(models.Model):
    """Order for books and products"""
    order_number = models.UUIDField(default=uuid.uuid4, editable=False, unique=True)
    user = models.ForeignKey(User, on_delete=models.SET_NULL, null=True, blank=True, related_name='orders')
    email = models.EmailField(help_text="Email for guest checkout")
    
    shipping_location = models.CharField(max_length=20, choices=ShippingLocation.choices)
    shipping_cost = models.DecimalField(max_digits=10, decimal_places=2, default=0)
    subtotal = models.DecimalField(max_digits=10, decimal_places=2, default=0)
    total = models.DecimalField(max_digits=10, decimal_places=2, default=0)
    
    payment_status = models.CharField(max_length=20, choices=PaymentStatus.choices, default=PaymentStatus.PENDING)
    payment_id = models.CharField(max_length=200, blank=True, null=True, help_text="MercadoPago payment ID")
    
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    class Meta:
        ordering = ['-created_at']

    def __str__(self):
        return f"Order {self.order_number} - {self.email}"

    def calculate_totals(self):
        """Calculate shipping cost, subtotal, and total"""
        # Calculate subtotal from order items
        self.subtotal = sum(item.get_total() for item in self.items.all())
        
        # Calculate shipping cost
        if self.shipping_location == ShippingLocation.BOGOTA:
            self.shipping_cost = settings.SHIPPING_COST_BOGOTA
        else:
            self.shipping_cost = settings.SHIPPING_COST_OUTSIDE
        
        self.total = self.subtotal + self.shipping_cost
        self.save()


class OrderItem(models.Model):
    """Items in an order - can be Books or CustomProducts"""
    order = models.ForeignKey(Order, on_delete=models.CASCADE, related_name='items')
    
    # Generic foreign key to support both Book and CustomProduct
    content_type = models.ForeignKey(ContentType, on_delete=models.CASCADE)
    object_id = models.PositiveIntegerField()
    content_object = GenericForeignKey('content_type', 'object_id')
    
    quantity = models.PositiveIntegerField(default=1)
    price = models.DecimalField(max_digits=10, decimal_places=2)
    
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return f"{self.quantity}x {self.content_object} in Order {self.order.order_number}"

    def get_total(self):
        return self.quantity * self.price


class ShippingAddress(models.Model):
    """Shipping address for an order"""
    order = models.OneToOneField(Order, on_delete=models.CASCADE, related_name='shipping_address')
    full_name = models.CharField(max_length=200)
    address = models.TextField()
    city = models.CharField(max_length=100)
    department = models.CharField(max_length=100, blank=True, null=True, help_text="Department/State if outside Bogotá")
    phone = models.CharField(max_length=20)
    additional_info = models.TextField(blank=True, null=True)
    
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return f"Shipping for Order {self.order.order_number}"
