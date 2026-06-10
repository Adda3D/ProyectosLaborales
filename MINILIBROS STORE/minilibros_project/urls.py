"""
URL configuration for minilibros_project project.
"""
from django.contrib import admin
from django.urls import path, include
from django.conf import settings
from django.conf.urls.static import static
from redirects.views import redirect_handler

urlpatterns = [
    path('admin/', admin.site.urls),
    path('', include('core.urls')),
    path('books/', include('books.urls')),
    path('products/', include('products.urls')),
    path('orders/', include('orders.urls')),
    path('library/', include('library.urls')),
    path('payments/', include('payments.urls')),
    # Accounts (allauth removed)
    # Dynamic redirect - must be last
    path('<str:code>/', redirect_handler, name='redirect_handler'),
]

if settings.DEBUG:
    urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
    urlpatterns += static(settings.STATIC_URL, document_root=settings.STATIC_ROOT)
