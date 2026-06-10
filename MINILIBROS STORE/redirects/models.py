from django.db import models
from django.contrib.auth.models import User
from django.contrib.contenttypes.models import ContentType
from django.contrib.contenttypes.fields import GenericForeignKey
import secrets
import string


def generate_redirect_code():
    """Generate a random 8-character alphanumeric code"""
    return ''.join(secrets.choice(string.ascii_uppercase + string.digits) for _ in range(8))


class RedirectCode(models.Model):
    """NFC/QR redirect codes for physical products"""
    code = models.CharField(max_length=50, unique=True, db_index=True, default=generate_redirect_code)
    
    # Generic foreign key to support both Book and CustomProduct
    content_type = models.ForeignKey(ContentType, on_delete=models.CASCADE)
    object_id = models.PositiveIntegerField()
    content_object = GenericForeignKey('content_type', 'object_id')
    
    user = models.ForeignKey(User, on_delete=models.CASCADE, related_name='redirect_codes')
    is_active = models.BooleanField(default=True)
    
    accessed_count = models.PositiveIntegerField(default=0)
    created_at = models.DateTimeField(auto_now_add=True)
    last_accessed = models.DateTimeField(blank=True, null=True)

    class Meta:
        ordering = ['-created_at']

    def __str__(self):
        return f"{self.code} -> {self.content_object}"

    def increment_access(self):
        """Increment access count"""
        from django.utils import timezone
        self.accessed_count += 1
        self.last_accessed = timezone.now()
        self.save()
