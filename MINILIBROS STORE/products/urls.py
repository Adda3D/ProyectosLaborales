from django.urls import path
from . import views

app_name = 'products'

urlpatterns = [
    path('create-cd/', views.create_cd, name='create_cd'),
    path('create-vinyl/', views.create_vinyl, name='create_vinyl'),
    path('upload-book/', views.upload_custom_book, name='upload_book'),
]
