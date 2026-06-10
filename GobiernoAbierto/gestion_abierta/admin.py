from django.contrib import admin
from requests import request
from . import models as model_gestion_abierta
from .forms import ArchivoAdminForm, ArchivoForm, InformeAdminForm, InformeForm
from import_export.admin import  ImportExportModelAdmin
from .resource.informe import InformeResource
from usuario.models import Usuario



class ArchivoTabularInlineAdmin(admin.TabularInline):
    model = model_gestion_abierta.Archivo 
    fields = ['informe','nombre', 'descripcion', 'archivo']
    extra = 1


@admin.register(model_gestion_abierta.Informe)
class InformeModelAdmin(ImportExportModelAdmin, admin.ModelAdmin):
    inlines = [ArchivoTabularInlineAdmin]
    resource_class = InformeResource
    search_fields  = ("titulo",)
    list_filter    = ("usuario__usuariogestionabierta",)
    list_display   = ["titulo","get_perfil","fecha_informe"]
    form = InformeAdminForm

    def get_perfil(self, obj):
        return obj.usuario.usuariogestionabierta if obj.usuario is not None and obj.usuario.usuariogestionabierta is not None else ''
    get_perfil.short_description = 'Perfil'

    def save_formset(self, request, form, formset, change):
        instances = formset.save(commit=False)
        for obj in formset.deleted_objects:
            obj.delete()
        for instance in instances:
            instance.usuario = request.user
            instance.save()
        formset.save_m2m()

    def save_model(self, request, obj, form, change):
        if not request.user.is_superuser: 
            obj.usuario = request.user
        return super().save_model(request, obj, form, change)

    def get_form(self, request, obj=None, **kwargs):
        if request.user.is_superuser: 
            kwargs['form'] = InformeAdminForm
        else:
            kwargs['form'] = InformeForm
        return super().get_form(request, obj, **kwargs)

    def get_queryset(self, request):
        qs = super(InformeModelAdmin, self).get_queryset(request)
        if request.user.is_superuser:
            return qs
        return qs.filter(usuario = request.user)


@admin.register(model_gestion_abierta.Archivo)
class ArchivoModelAdmin(admin.ModelAdmin):
    search_fields = ("nombre",)
    list_display  = ["nombre","descripcion","archivo","fecha_creacion"]

    def get_form(self, request, obj=None, **kwargs):
        if request.user.is_superuser: 
            kwargs['form'] = ArchivoAdminForm
        else:
            kwargs['form'] = ArchivoForm
        return super().get_form(request, obj, **kwargs)

    def get_queryset(self, request):
        qs = super(ArchivoModelAdmin, self).get_queryset(request)
        if request.user.is_superuser:
            return qs
        return qs.filter(informe__usuario = request.user)

    def save_model(self, request, obj, form, change):
        if not request.user.is_superuser: 
            obj.usuario = request.user
        return super().save_model(request, obj, form, change)


@admin.register(model_gestion_abierta.FraseBuscada)
class FraseBuscadaModelAdmin(admin.ModelAdmin):
    search_fields = ("frase",)
    list_display  = ["frase","estado",]


@admin.register(model_gestion_abierta.ODS)
class ODSModelAdmin(admin.ModelAdmin):
    search_fields = ("nombre","descripcion",)
    list_display  = ["nombre","link_onu","estado"]


@admin.register(model_gestion_abierta.LinkEvidencia)
class ODSModelAdmin(admin.ModelAdmin):
    search_fields = ("nombre","descripcion",)
    list_display  = ["nombre","link_evidencia"]