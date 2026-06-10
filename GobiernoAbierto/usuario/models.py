from datetime import datetime
from enum import unique
from statistics import mode
from django.utils.translation import ugettext_lazy as _
from django.db import models
from django.contrib.auth.models import (
    BaseUserManager, AbstractBaseUser,
    PermissionsMixin)

from usuario.managers import MyUserManager
from .choices import SecretariaChoice
#from gobierno_abierto.settings import STATIC_ROOT


class PerfilGestionAbierta(models.Model):
    nombre = models.CharField(max_length=80, unique=True)
    estado = models.BooleanField(default=True)

    def __unicode__(self):
        return self.nombre

    def __str__(self):
        return self.nombre

    class Meta:
        verbose_name_plural = 'Perfil de gestion abierta'
        verbose_name = 'Perfiles de gestion abierta'


class Usuario(AbstractBaseUser, PermissionsMixin):
    correo = models.EmailField(_('Correo'),
        max_length=255,
        unique=True,)
    is_staff = models.BooleanField(default=True)
    is_active = models.BooleanField(default=True)
    date_joined = models.DateTimeField(default=datetime.now)
    ultima_conexicon = models.DateTimeField(auto_now_add=True)
    nacimiento = models.DateField(_('Cumpleaños'),blank=True, null=True)
    nombre = models.CharField(max_length=50)
    apellidos = models.CharField(max_length=50, blank=True, null=True)
    ocupacion = models.CharField(max_length=50, blank=True, null=True)
    telefono  = models.BigIntegerField(blank=True, null=True)
    foto = models.ImageField(upload_to="static/gestion_abierta/foto_perfil/", blank=True, null=True)
    password = models.CharField(_('password'), max_length=128 , blank=True, null=True)
    #empresa = models.ForeignKey(Empresa, blank=True, null=True, on_delete=models.SET_NULL)
    USERNAME_FIELD = 'correo'
    REQUIRED_FIELDS = []

    objects = MyUserManager()

    @property
    def full_name(self):
        return '{} {}'.format(self.nombre or '', self.apellidos  or '')

    def __str__(self):
        return self.correo

    def __unicode__(self):
        return '{} {} / {}'.format(self.nombre, self.apellidos, self.correo)


class UsuarioGestionAbierta(Usuario):
    perfil      = models.ForeignKey(PerfilGestionAbierta, on_delete=models.SET_NULL, null=True, unique=True)
    descripcion = models.TextField(null=True, blank=True, verbose_name="descripcion del usuario")
    objetivos   = models.TextField(null=True, blank=True, verbose_name="objetivos del usuario")

    class Meta:
        verbose_name_plural = 'Usuario de gestion abierta'
        verbose_name = 'Usuarios de gestion abierta'

    def __str__(self):
        return self.perfil.nombre if self.perfil is not None else "Ninguno"