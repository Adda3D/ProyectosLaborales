from django.contrib import admin
from .models import RedirectCode
from django.utils.html import format_html


@admin.register(RedirectCode)
class RedirectCodeAdmin(admin.ModelAdmin):
    list_display = ['code', 'content_object', 'user', 'is_active', 'accessed_count', 'created_at']
    list_filter = ['is_active', 'content_type', 'created_at']
    search_fields = ['code', 'user__username']
    readonly_fields = ['code', 'accessed_count', 'last_accessed', 'created_at']
    list_editable = ['is_active']
    
    def get_queryset(self, request):
        queryset = super().get_queryset(request)
        return queryset.select_related('user', 'content_type')
    
    fieldsets = (
        ('Code Information', {
            'fields': ('code', 'is_active')
        }),
        ('Content', {
            'fields': ('content_type', 'object_id', 'user')
        }),
        ('Statistics', {
            'fields': ('accessed_count', 'last_accessed', 'created_at')
        }),
    )
