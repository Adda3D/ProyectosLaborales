from django.db import models
from django.utils.text import slugify
from django.core.validators import FileExtensionValidator


class Book(models.Model):
    """Physical mini books available for purchase"""
    title = models.CharField(max_length=200)
    author = models.CharField(max_length=200)
    description = models.TextField()
    cover_image = models.ImageField(upload_to='books/covers/')
    pdf_file = models.FileField(
        upload_to='books/pdfs/',
        validators=[FileExtensionValidator(allowed_extensions=['pdf', 'epub'])],
        help_text='Sube el libro en formato PDF o ePub'
    )
    price = models.DecimalField(max_digits=10, decimal_places=2)
    is_available = models.BooleanField(default=True)
    slug = models.SlugField(unique=True, blank=True)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    class Meta:
        ordering = ['-created_at']

    def __str__(self):
        return self.title

    def save(self, *args, **kwargs):
        if not self.slug:
            self.slug = slugify(self.title)
        super().save(*args, **kwargs)
