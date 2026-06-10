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
from django.contrib import admin
from django.urls import path
from . import views as views_gestion_abierta
from django.contrib.staticfiles.urls import staticfiles_urlpatterns
from django.conf import settings
from django.conf.urls.static import static



urlpatterns = [
    path('',views_gestion_abierta.index, name="index"),
    path('informacion_gestores/',views_gestion_abierta.informacion_gestores, name="informacion_gestores"),
    path('informe/<int:id_informe>/',views_gestion_abierta.informe, name="informe"),
    path('informe/busqueda/',views_gestion_abierta.busqueda_informe, name="busqueda_informe"),
    path('<int:usuario_gestion_id>/',views_gestion_abierta.informe_usuario_gestion, name="informe_usuario_gestion"),
    path('<int:usuario_gestion_id>/<int:anio_informe>/',views_gestion_abierta.informe_usuario_gestion, name="informe_usuario_gestion_month"),
    path('<int:usuario_gestion_id>/<int:anio_informe>/<int:mes_informe>/',views_gestion_abierta.informe_usuario_gestion, name="informe_usuario_gestion_month_year"),
]# + static(settings.STATIC_URL, document_root=settings.STATIC_ROOT)