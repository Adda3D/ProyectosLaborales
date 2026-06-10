from django.contrib import admin
from django.utils.html import format_html
from .models import Order, OrderItem, ShippingAddress
from products.models import CustomProduct, ProductType


class OrderItemInline(admin.TabularInline):
    model = OrderItem
    extra = 0
    readonly_fields = ['content_type', 'object_id', 'price', 'created_at', 'item_preview']

    @admin.display(description='Detalle del producto')
    def item_preview(self, obj):
        content_object = obj.content_object
        if content_object is None:
            return '—'

        if isinstance(content_object, CustomProduct):
            parts = []
            ptype = content_object.product_type

            # --- Mini CD / Vinyl ---
            if ptype in [ProductType.CD, ProductType.VINYL]:
                if content_object.cover_image:
                    parts.append(format_html(
                        '<img src="{}" style="height:44px;width:44px;object-fit:cover;'
                        'border-radius:4px;vertical-align:middle;margin-right:6px;">',
                        content_object.cover_image.url
                    ))
                if content_object.case_color:
                    parts.append(format_html(
                        '<span style="font-size:12px;color:#555;">🎨 {}</span> ',
                        content_object.case_color
                    ))
                if content_object.nfc_url:
                    parts.append(format_html(
                        '<a href="{}" target="_blank" style="font-size:12px;">🔗 NFC</a> ',
                        content_object.nfc_url
                    ))

            # --- Minilibro (Custom Book) ---
            elif ptype == ProductType.CUSTOM_BOOK:
                if content_object.pdf_file:
                    parts.append(format_html(
                        '<a href="{}" target="_blank" style="background:#4A90D9;color:#fff;'
                        'padding:3px 10px;border-radius:4px;text-decoration:none;'
                        'font-size:12px;margin-right:6px;">📄 PDF</a>',
                        content_object.pdf_file.url
                    ))
                if content_object.cover_image:
                    parts.append(format_html(
                        '<img src="{}" style="height:44px;width:44px;object-fit:cover;'
                        'border-radius:4px;vertical-align:middle;margin-right:6px;">',
                        content_object.cover_image.url
                    ))
                if content_object.custom_message:
                    parts.append(format_html(
                        '<div style="margin-top:4px;font-size:12px;color:#333;'
                        'background:#f9f9f9;padding:4px 8px;border-radius:4px;'
                        'border-left:3px solid #7B5EA7;max-width:380px;">'
                        '💬 <em>{}</em></div>',
                        content_object.custom_message[:200]
                    ))

            return format_html(''.join(['{}'] * len(parts)), *parts) if parts else str(content_object)

        return str(content_object)


class ShippingAddressInline(admin.StackedInline):
    model = ShippingAddress
    extra = 0


@admin.register(Order)
class OrderAdmin(admin.ModelAdmin):
    list_display = ['order_number', 'email', 'payment_status', 'total', 'created_at']
    list_filter = ['payment_status', 'shipping_location', 'created_at']
    search_fields = ['order_number', 'email', 'user__username']
    readonly_fields = ['order_number', 'created_at', 'updated_at']
    inlines = [OrderItemInline, ShippingAddressInline]

    def get_queryset(self, request):
        return super().get_queryset(request).select_related('user').prefetch_related('items')
