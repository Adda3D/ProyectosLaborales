from django.urls import path
from . import views

app_name = 'library'

urlpatterns = [
    path('', views.my_library, name='my_library'),
    path('reader/<str:content_type>/<int:object_id>/', views.pdf_reader, name='pdf_reader'),
    path('leer/<slug:slug>/', views.nfc_book_redirect, name='nfc_redirect'),   # ← NFC tag URL
    path('api/annotations/', views.save_annotation, name='save_annotation'),
    path('api/annotations/<int:annotation_id>/', views.delete_annotation, name='delete_annotation'),
    path('api/settings/', views.save_reader_settings, name='save_reader_settings'),
]
