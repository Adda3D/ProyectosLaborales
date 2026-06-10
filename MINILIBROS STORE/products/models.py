from django.db import models
from django.contrib.auth.models import User
from django.conf import settings
from django.core.validators import FileExtensionValidator


class ProductType(models.TextChoices):
    CD = 'CD', 'Mini CD'
    VINYL = 'VINYL', 'Mini Vinyl'
    CUSTOM_BOOK = 'CUSTOM_BOOK', 'Custom Book'


class CustomProduct(models.Model):
    """User-created custom products: CDs, Vinyls, or Custom Books"""
    product_type = models.CharField(max_length=20, choices=ProductType.choices)
    user = models.ForeignKey(User, on_delete=models.CASCADE, related_name='custom_products', null=True, blank=True)
    
    # For CDs and Vinyls
    case_color = models.CharField(max_length=50, blank=True, null=True)
    nfc_url = models.URLField(blank=True, null=True, help_text="URL for NFC/QR redirect")
    custom_message = models.TextField(blank=True, null=True)
    cover_image = models.ImageField(upload_to='products/covers/', blank=True, null=True)
    
    # For Custom Books
    pdf_file = models.FileField(
        upload_to='products/pdfs/',
        blank=True,
        null=True,
        validators=[FileExtensionValidator(allowed_extensions=['pdf', 'epub'])],
        help_text='Archivo del libro en formato PDF o ePub'
    )
    
    # Pricing
    base_price = models.DecimalField(max_digits=10, decimal_places=2)
    
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    class Meta:
        ordering = ['-created_at']

    def __str__(self):
        username = self.user.username if self.user else "Guest"
        return f"{self.get_product_type_display()} by {username}"

    def save(self, *args, **kwargs):
        # Set base price based on product type
        if not self.base_price:
            if self.product_type in [ProductType.CD, ProductType.VINYL]:
                self.base_price = settings.PRICE_MINI_CD
            elif self.product_type == ProductType.CUSTOM_BOOK:
                self.base_price = settings.PRICE_CUSTOM_BOOK
        super().save(*args, **kwargs)

    def get_file(self):
        """Return the appropriate file for this product"""
        if self.product_type == ProductType.CUSTOM_BOOK:
            return self.pdf_file
        return None
