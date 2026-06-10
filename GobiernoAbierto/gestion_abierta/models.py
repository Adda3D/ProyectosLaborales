from tabnanny import verbose
from django.db import models
from .choices import EstadoInformeChoice
from usuario.models import UsuarioGestionAbierta, Usuario



class ODS(models.Model):
    nombre        = models.CharField(max_length=300, null=True, blank=True, unique=True, verbose_name="nombre")
    descripcion   = models.TextField(null=True, blank=True, verbose_name="descripcion")
    link_onu      = models.URLField(null=True, blank=True, verbose_name="link de informacion de la ONU")
    imagen        = models.FileField(upload_to="gestion_abierta/informes/ods/",null=True, blank=True, verbose_name="imagen")
    estado        = models.BooleanField(default=True, verbose_name="estado")

    def __str__(self):
        return str(self.nombre) if self.nombre else ""

    class Meta:
        verbose_name = "Objetivo de desarrollo sostenible"
        verbose_name_plural = "Objetivos de desarrollo sostenible"


class LinkEvidencia(models.Model):
    nombre         = models.CharField(max_length=300, null=True, blank=True, verbose_name="nombre")
    descripcion    = models.TextField(null=True, blank=True, verbose_name="descripcion")
    link_evidencia = models.URLField(null=True, blank=True, verbose_name="link de evidencia")

    def __str__(self):
        return str(self.nombre) if self.nombre else ""

    class Meta:
        verbose_name = "Link de evidencia"
        verbose_name_plural = "Links de evidencias"


class Informe(models.Model):
    titulo          = models.CharField(max_length=300, null=True)
    descripcion     = models.TextField()
    usuario         = models.ForeignKey(Usuario,on_delete=models.SET_NULL,null=True,blank=True)
    evidencia       = models.FileField(upload_to="gestion_abierta/informes/evidencias/",null=True, blank=True, verbose_name="archivo")
    ods             = models.ManyToManyField(ODS, blank=True, verbose_name="Objetivos de desarrollo sostenible")
    link_evidencias = models.ManyToManyField(LinkEvidencia, blank=True, verbose_name="Links de evidencias")
    url_evidencia   = models.CharField(max_length=500, null=True, blank=True, verbose_name="url de evidencia")
    fecha_informe   = models.DateField(null=True)
    estado          = models.CharField(max_length=50, choices=EstadoInformeChoice, default=EstadoInformeChoice.sin_publicar, null=True)
    
    def __str__(self):
        return str(self.titulo) if self.titulo else ""


class Archivo(models.Model):
    fecha_creacion = models.DateField(auto_now_add=True, verbose_name="fecha de creacion")
    nombre         = models.CharField(max_length=300, null=True, blank=True, verbose_name="nombre")
    descripcion    = models.TextField(null=True, blank=True)
    archivo        = models.FileField(upload_to="gestion_abierta/informes/archivos/",null=True, blank=True)
    usuario        = models.ForeignKey(Usuario, on_delete=models.SET_NULL,null=True,blank=True)
    informe        = models.ForeignKey(Informe, on_delete=models.SET_NULL,null=True,blank=True, verbose_name="informe")
 
    def __str__(self):
        return str(self.nombre) if self.nombre else ""

    class Meta:
        verbose_name = "Evidencia"
        verbose_name_plural = "Evidencias"


class BackupGobiernoAbierto(models.Model):
    fecha_creacion = models.DateField(null=True)
    archivo        = models.FileField(upload_to="gestion_abierta/informes/evidencias/",null=True, blank=True)


class FraseBuscada(models.Model):
    frase        = models.CharField(max_length=200, unique=True, null=True, blank=True, verbose_name="frase buscada")
    estado       = models.BooleanField(default=False, verbose_name="aprobada")
    num_busqueda = models.PositiveBigIntegerField(default=1, verbose_name="numero de busquedas")
    color        = models.CharField(max_length=50, null=True, default="#DCFB8A", blank=True, verbose_name="color de busqueda")

    def __str__(self):
        return str(self.frase)