"""gobierno_abierto URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from argparse import Namespace
from django.contrib import admin
from django.urls import path, include
from . import views as views_gobierno_abierto
from django.contrib.staticfiles.urls import staticfiles_urlpatterns
from django.conf import settings
from django.conf.urls.static import static
from django.views.static import serve
from django.conf.urls import url
from django.views.static import serve
from .task import realizar_backup

from django.conf.urls.i18n import i18n_patterns

admin.site.site_header = 'Gobierno abierto'                    # default: "Django Administration"
admin.site.index_title = 'Panel administrativo'                 # default: "Site administration"
admin.site.site_title = 'Descrubre la gestion de tus informes'



urlpatterns = [
    url(r'^i18n/', include('django.conf.urls.i18n')),
    path('admin/', admin.site.urls),
    path('', include(('gestion_abierta.urls', 'gestion_abierta'),  namespace='gestion_abierta')),
    #path('',views_gobierno_abierto.index, name="index"),
    path('quienes_somos/',views_gobierno_abierto.quienes_somos, name="quienes_somos"),
    path('contratacion/', include(('contratacion_abierta.urls', 'contratacion_abierta'),  namespace='contratacion_abierta')),
    path('gestion/', include(('gestion_abierta.urls', 'gestion_abierta'),  namespace='gestion_abierta')),
    url(r'^media/(?P<path>.*)$', serve, { 'document_root': settings.MEDIA_ROOT}), 
    url(r'^static/(?P<path>.*)$', serve, { 'document_root': settings.STATIC_FILE_ROOT}),
] + static(settings.STATIC_URL, document_root=settings.STATIC_ROOT)

handler404 = 'gestion_abierta.views.handler_404'

#urlpatterns += i18n_patterns(url(r'^admin/', admin.site.urls))