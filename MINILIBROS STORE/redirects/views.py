from django.shortcuts import redirect, get_object_or_404
from django.contrib.auth.decorators import login_required
from django.urls import reverse
from .models import RedirectCode


def redirect_handler(request, code):
    """Handle NFC/QR code redirects"""
    redirect_code = get_object_or_404(RedirectCode, code=code, is_active=True)
    
    # Check if user is authenticated
    if not request.user.is_authenticated:
        # Redirect to login with next parameter
        login_url = reverse('core:login')
        return redirect(f'{login_url}?next=/{code}/')
    
    # Check if user has access to this content
    if redirect_code.user != request.user:
        # User doesn't own this content
        return redirect('core:home')
    
    # Increment access count
    redirect_code.increment_access()
    
    # Redirect to the PDF reader
    content_type = redirect_code.content_type.model
    object_id = redirect_code.object_id
    
    return redirect('library:pdf_reader', content_type=content_type, object_id=object_id)
