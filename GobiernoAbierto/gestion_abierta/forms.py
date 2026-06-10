
from cuser.middleware import CuserMiddleware
from django import forms
from .models import *



class InformeAdminForm(forms.ModelForm):
    class Meta:
        model = Informe
        fields = ['titulo','descripcion','evidencia', 'link_evidencias', 'ods', 'url_evidencia','fecha_informe','usuario']
        exclude = ['evidencia']

    def __init__(self, *args, **kwargs):
        self.request = kwargs.get('request', None)
        super(InformeAdminForm, self).__init__(*args, **kwargs)

    def clean(self):
        data = super(InformeAdminForm, self).clean()
        #if data.get('evidencia', None) is None:
        #    self.add_error('evidencia', 'Debe ingresar un archivo')
        return data
    
    def save(self, commit=True):
        informe = super(InformeAdminForm, self).save(commit)
        #informe.usuario = CuserMiddleware.get_user()
        return informe


class InformeForm(forms.ModelForm):
    class Meta:
        model = Informe
        fields = ['titulo','descripcion', 'evidencia', 'link_evidencias', 'ods', 'url_evidencia','fecha_informe']
        exclude = ['usuario','evidencia']

    def __init__(self, *args, **kwargs):
        self.request = kwargs.get('request', None)
        super(InformeForm, self).__init__(*args, **kwargs)

    def clean(self):
        data = super(InformeForm, self).clean()
        #if data.get('evidencia', None) is None:
        #    self.add_error('evidencia', 'Debe ingresar un archivo')
        return data
    
    def save(self, commit=True):
        informe = super(InformeForm, self).save(commit)
        secretario = CuserMiddleware.get_user()
        secretario = UsuarioGestionAbierta.objects.get(correo = secretario.correo)
        informe.usuario = secretario
        return informe


class ArchivoAdminForm(forms.ModelForm):
    class Meta:
        model = Archivo
        fields = ['nombre','descripcion','archivo','informe']
        #exclude = ['usuario']

    def __init__(self, *args, **kwargs):
        self.request = kwargs.get('request', None)
        super(ArchivoAdminForm, self).__init__(*args, **kwargs)

    def clean(self):
        data = super(ArchivoAdminForm, self).clean()
        #if data.get('evidencia', None) is None:
        #    self.add_error('evidencia', 'Debe ingresar un archivo')
        return data
    
    #def save(self, commit=True):
    #    informe = super(ArchivoAdminForm, self).save(commit)
    #    #informe.usuario = CuserMiddleware.get_user()
    #    return informe


class ArchivoForm(forms.ModelForm):
    class Meta:
        model = Archivo
        fields = ['nombre','descripcion','archivo']
        exclude = ['usuario','informe']

    def __init__(self, *args, **kwargs):
        self.request = kwargs.get('request', None)
        super(ArchivoForm, self).__init__(*args, **kwargs)

    def clean(self):
        data = super(ArchivoForm, self).clean()
        #if data.get('evidencia', None) is None:
        #    self.add_error('evidencia', 'Debe ingresar un archivo')
        return data
    
    #def save(self, commit=True):
    #    archivo = super(ArchivoForm, self).save(commit)
    #    usuario = CuserMiddleware.get_user()
    #    secretario = UsuarioGestionAbierta.objects.get(correo = archivo.correo)
    #    informe.usuario = secretario
    #    return informe


class ExampleForm(forms.Form):
    busqueda = forms.CharField(label='Encuentra el tema de tu interes', max_length=80)