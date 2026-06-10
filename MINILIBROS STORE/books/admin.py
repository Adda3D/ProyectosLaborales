from django.contrib import admin
from django import forms
from .models import Book


class BookAdminForm(forms.ModelForm):
    class Meta:
        model = Book
        fields = '__all__'

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['pdf_file'].label = 'Archivo Digital (PDF o ePub)'
        self.fields['pdf_file'].help_text = 'Sube el archivo en formato PDF o ePub'


@admin.register(Book)
class BookAdmin(admin.ModelAdmin):
    form = BookAdminForm
    list_display = ['title', 'author', 'price', 'is_available', 'created_at']
    list_filter = ['is_available', 'created_at']
    search_fields = ['title', 'author', 'description']
    prepopulated_fields = {'slug': ('title',)}
    list_editable = ['is_available', 'price']
    readonly_fields = ['created_at', 'updated_at']
