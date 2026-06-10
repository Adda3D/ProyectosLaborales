from django.contrib import admin
from requests import models
from . import models as model_usuario
from .forms import UsuarioCreationForm, UsuarioChangeForm, UsuarioGestionAbiertaCreationForm, UsuarioGestionAbiertaChangeForm
from django.contrib.auth.admin import UserAdmin


@admin.register(model_usuario.Usuario)
class UsuarioAdmin(UserAdmin):
    add_form = UsuarioCreationForm
    form = UsuarioChangeForm
    model = model_usuario.Usuario
    list_display = ('correo', 'is_staff', 'is_active',)
    list_filter = ('correo', 'is_active',)
    fieldsets = (
        (None, {'fields': ('nombre','apellidos','correo','nacimiento','ocupacion', 'password', 'foto')}),
        ('Tipo', {'fields': ('is_staff', 'is_active','is_superuser')}),
        ('Permisos', {'fields': ('user_permissions', 'groups')}),
    )
    add_fieldsets = (
        (None, {
            'classes': ('wide',),
            'fields': ('nombre','apellidos','correo','nacimiento','ocupacion', 'password1', 'password2', 'foto', 'is_staff', 'is_active')}
         ),
        ('Tipo', {'fields': ('is_staff', 'is_active', 'is_superuser')}),
        ('Permisos', {'fields': ('user_permissions', 'groups')}),
    )
    search_fields = ('correo',)
    ordering = ('correo',)


@admin.register(model_usuario.UsuarioGestionAbierta)
class UsuarioGestionAbiertaAdmin(UsuarioAdmin):
    add_form = UsuarioGestionAbiertaCreationForm
    form = UsuarioGestionAbiertaChangeForm
    model = model_usuario.UsuarioGestionAbierta
    list_display = ('perfil','correo', 'is_staff', 'is_active','foto',)
    list_filter = ('correo', 'perfil', 'is_active','perfil',)
    fieldsets = (
        (None, {'fields': ('nombre','apellidos','correo','telefono','perfil','descripcion','objetivos','nacimiento','ocupacion', 'password', 'foto')}),
        ('Tipo', {'fields': ('is_staff', 'is_active','is_superuser')}),
        ('Permisos', {'fields': ('groups',)}),
    )
    add_fieldsets = (
        (None, {
            'classes': ('wide',),
            'fields': ('nombre','apellidos','correo','telefono','perfil','descripcion','objetivos','nacimiento','ocupacion', 'password1', 'password2', 'foto', 'is_staff', 'is_active')}
         ),
        ('Tipo', {'fields': ('is_staff', 'is_active', 'is_superuser')}),
        ('Permisos', {'fields': ('groups',)}),
    )
    search_fields = ('correo',)
    ordering = ('correo',)


@admin.register(model_usuario.PerfilGestionAbierta)
class PerfilGestionAbiertaModelAdmin(admin.ModelAdmin):
    pass