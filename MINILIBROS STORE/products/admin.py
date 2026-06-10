from django.contrib import admin
from django.utils.html import format_html
from .models import CustomProduct, ProductType


@admin.register(CustomProduct)
class CustomProductAdmin(admin.ModelAdmin):
    list_display = ['id', 'product_type', 'user', 'base_price', 'created_at',
                    'preview_image', 'download_pdf']
    list_filter = ['product_type', 'created_at']
    search_fields = ['user__username', 'user__email', 'custom_message']
    readonly_fields = [
        'created_at', 'updated_at',
        'preview_image_large', 'download_pdf_link',
    ]

    fieldsets = (
        ('General', {
            'fields': ('product_type', 'user', 'base_price', 'created_at', 'updated_at')
        }),
        ('Mini CD / Vinyl', {
            'fields': ('case_color', 'nfc_url', 'cover_image', 'preview_image_large'),
            'description': 'Aplica solo para Mini CD y Mini Vinyl.',
            'classes': ('collapse',),
        }),
        ('Minilibro Personalizado', {
            'fields': ('pdf_file', 'download_pdf_link', 'custom_message'),
            'description': 'Aplica solo para libros personalizados.',
            'classes': ('collapse',),
        }),
    )

    def get_queryset(self, request):
        return super().get_queryset(request).select_related('user')

    # --- Columnas en el listado ---

    @admin.display(description='Imagen')
    def preview_image(self, obj):
        if obj.cover_image:
            return format_html(
                '<img src="{}" style="height:48px;width:48px;object-fit:cover;border-radius:6px;">',
                obj.cover_image.url
            )
        return '—'

    @admin.display(description='PDF')
    def download_pdf(self, obj):
        if obj.pdf_file:
            return format_html(
                '<a href="{}" target="_blank" style="background:#4A90D9;color:#fff;'
                'padding:3px 10px;border-radius:4px;text-decoration:none;font-size:12px;">'
                '⬇ Descargar</a>',
                obj.pdf_file.url
            )
        return '—'

    # --- Campos de detalle readonly ---

    @admin.display(description='Vista previa portada')
    def preview_image_large(self, obj):
        if obj.cover_image:
            return format_html(
                '<img src="{}" style="max-width:300px;max-height:300px;'
                'border-radius:8px;border:1px solid #ddd;">',
                obj.cover_image.url
            )
        return 'Sin imagen'

    @admin.display(description='Descargar PDF')
    def download_pdf_link(self, obj):
        if obj.pdf_file:
            return format_html(
                '<a href="{}" target="_blank" style="background:#4A90D9;color:#fff;'
                'padding:6px 16px;border-radius:6px;text-decoration:none;font-weight:bold;">'
                '📄 Abrir / Descargar PDF</a>',
                obj.pdf_file.url
            )
        return 'Sin archivo PDF'
