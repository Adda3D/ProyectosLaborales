from django.db import models
from django.contrib.auth.models import User
from django.contrib.contenttypes.models import ContentType
from django.contrib.contenttypes.fields import GenericForeignKey
import json


class LibraryAccess(models.Model):
    """Tracks which digital content a user has access to"""
    user = models.ForeignKey(User, on_delete=models.CASCADE, related_name='library_items')
    
    # Generic foreign key to support both Book and CustomProduct
    content_type = models.ForeignKey(ContentType, on_delete=models.CASCADE)
    object_id = models.PositiveIntegerField()
    content_object = GenericForeignKey('content_type', 'object_id')
    
    purchased_at = models.DateTimeField(auto_now_add=True)
    last_accessed = models.DateTimeField(auto_now=True)

    class Meta:
        unique_together = ['user', 'content_type', 'object_id']
        ordering = ['-purchased_at']

    def __str__(self):
        return f"{self.user.username} - {self.content_object}"


class AnnotationType(models.TextChoices):
    HIGHLIGHT = 'HIGHLIGHT', 'Highlight'
    NOTE = 'NOTE', 'Note'


class PDFAnnotation(models.Model):
    """Annotations (highlights and notes) for PDFs"""
    library_access = models.ForeignKey(LibraryAccess, on_delete=models.CASCADE, related_name='annotations')
    page_number = models.PositiveIntegerField()
    annotation_type = models.CharField(max_length=20, choices=AnnotationType.choices)
    
    # For notes
    content = models.TextField(blank=True, null=True)
    
    # Position data stored as JSON (coordinates, dimensions, etc.)
    position_data = models.JSONField(blank=True, null=True)
    
    # For highlights
    color = models.CharField(max_length=20, default='#FFFF00')
    
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    class Meta:
        ordering = ['page_number', 'created_at']

    def __str__(self):
        return f"{self.annotation_type} on page {self.page_number}"


class ReaderTheme(models.TextChoices):
    LIGHT = 'LIGHT', 'Light'
    DARK = 'DARK', 'Dark'
    SEPIA = 'SEPIA', 'Sepia'


class ReaderSettings(models.Model):
    """User preferences for the PDF reader"""
    user = models.OneToOneField(User, on_delete=models.CASCADE, related_name='reader_settings')
    
    background_color = models.CharField(max_length=20, default='#FFFFFF')
    text_color = models.CharField(max_length=20, default='#000000')
    font_size = models.PositiveIntegerField(default=16)
    theme = models.CharField(max_length=20, choices=ReaderTheme.choices, default=ReaderTheme.LIGHT)
    
    updated_at = models.DateTimeField(auto_now=True)

    def __str__(self):
        return f"Reader settings for {self.user.username}"
