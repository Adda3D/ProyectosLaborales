from django.shortcuts import render, redirect
from django.http import HttpResponse
from django.template import context, loader
from usuario.models import UsuarioGestionAbierta
from .models import Archivo, FraseBuscada, Informe, ODS, LinkEvidencia
from django.db.models import Count
from .utils import traducir_fechas, obtener_nombre_mes, colores_busqueda
from django.db.models.functions import ExtractYear, ExtractMonth
from .forms import ExampleForm
from django.contrib.sites.shortcuts import get_current_site



def handler_404(request,exception=None):
    return redirect('gestion_abierta:index')


def index(request):
    template = loader.get_template('gestion_abierta/index.html')
    form = ExampleForm()
    lista_secretarios = UsuarioGestionAbierta.objects.all().values(
        'id',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'foto',
    )
    frases_buscadas = FraseBuscada.objects.filter(estado=True).values(
        "frase",
        "num_busqueda",
        "color",
    )
    ultimos_informes = Informe.objects.all().order_by('fecha_informe')[:20]
    num_actividades = Informe.objects.all().count()
    num_informes    = Informe.objects.all()\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()
    for secretario in lista_secretarios:
        secretario["num_actividades"] = Informe.objects.filter(usuario__id = secretario["id"]).count()
        secretario["num_informes"]    = Informe.objects.filter(usuario__id = secretario["id"])\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()
    context = {
        'form'             : form,
        'lista_secretarios': lista_secretarios,
        'frases_buscadas'  : frases_buscadas,
        'num_actividades'  : num_actividades,
        'num_informes'     : num_informes,
        'ultimos_informes' : ultimos_informes,
    }
    return HttpResponse(template.render(context, request))


def informe_usuario_gestion(request, usuario_gestion_id, mes_informe=None,anio_informe=None):
    
    template = loader.get_template('gestion_abierta/informe_usuario_gestion.html')
    form = ExampleForm()
    
    informacion_secretario = UsuarioGestionAbierta.objects.filter(id=usuario_gestion_id).values(
        'id',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'foto',
        'descripcion',
        'objetivos',
        'correo',
        'telefono',
    ).first()

    informes = Informe.objects.filter(usuario__id = usuario_gestion_id).values(
            'id',
            'titulo',
            'descripcion',
            'fecha_informe',
            'usuario__nombre',
            'usuario__apellidos',
        )

    anio_informes = {}

    for aux in informes:
        if aux["fecha_informe"].year not in anio_informes:
            anio_informes[aux["fecha_informe"].year] = {aux["fecha_informe"].month : [obtener_nombre_mes(aux["fecha_informe"].month),1]}
        else:
            if aux["fecha_informe"].month in anio_informes[aux["fecha_informe"].year]:
                anio_informes[aux["fecha_informe"].year][aux["fecha_informe"].month][1] = anio_informes[aux["fecha_informe"].year][aux["fecha_informe"].month][1]+1
            else:
                anio_informes[aux["fecha_informe"].year].update({aux["fecha_informe"].month : [obtener_nombre_mes(aux["fecha_informe"].month),1]})
    
    if mes_informe!=None and anio_informe!=None:
        informes = Informe.objects.filter(
            usuario__id          = usuario_gestion_id,
            fecha_informe__year  = anio_informe,
            fecha_informe__month = mes_informe,
        ).values(
            'id',
            'titulo',
            'descripcion',
            'fecha_informe',
            'usuario__nombre',
            'usuario__apellidos',
        )

    for aux_informe in informes:
        aux_informe["fecha_informe"] = traducir_fechas(aux_informe["fecha_informe"].strftime("%d de %B del %Y"))
    
    num_actividades = Informe.objects.all().count()
    num_informes    = Informe.objects.all()\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()
    lista_secretarios = UsuarioGestionAbierta.objects.all().values(
        'id',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'foto',
    )
    ultimos_informes = Informe.objects.all().order_by('fecha_informe')[:20]
    context = {
        'form'                   : form,
        'informacion_secretario' : informacion_secretario,
        'informes'               : informes,
        'anio_informes'          : anio_informes,
        'num_actividades'        : num_actividades,
        'num_informes'           : num_informes,
        'lista_secretarios'      : lista_secretarios,
        'ultimos_informes'       : ultimos_informes,
    }

    return HttpResponse(template.render(context, request))


def informe(request, id_informe):
    url_dominio = "http://" + get_current_site(request).domain + "/media/"
    template = loader.get_template('gestion_abierta/informe.html')
    form = ExampleForm()
    informe  = Informe.objects.filter(id=id_informe).values(
        'id',
        'usuario__id',
        'usuario__nombre',
        'usuario__apellidos',
        'fecha_informe',
        'titulo',
        'descripcion',
        'url_evidencia',
    ).first()
    frases_buscadas = FraseBuscada.objects.filter(estado=True).values(
        "frase",
        "num_busqueda",
        "color",
    )
    ods = ODS.objects.filter(
        informe__id = id_informe
    ).values(
        "nombre",
        "link_onu",
        "imagen",
    )
    link_evidencia = LinkEvidencia.objects.filter(
        informe__id = id_informe
    ).values(
        "nombre",
        "link_evidencia",
    )
    lista_secretarios = UsuarioGestionAbierta.objects.all().values(
        'id',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'foto',
    )
    ultimos_informes = Informe.objects.all().order_by('fecha_informe')[:20]
    num_actividades = Informe.objects.all().count()
    num_informes    = Informe.objects.all()\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()

    evidencias = Archivo.objects.filter(
        informe__id=id_informe
    ).values(
        "nombre",
        "archivo",
        "descripcion",
    )

    informe["fecha_informe"] = traducir_fechas(informe["fecha_informe"].strftime("%d de %B del %Y"))

    informacion_secretario = UsuarioGestionAbierta.objects.filter(id = informe["usuario__id"]).values(
        'id',
        'foto',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'descripcion',
        'objetivos',
        'correo',
        'telefono',
    ).first()

    informes = Informe.objects.filter(
        usuario__id= informe["usuario__id"]
    ).values(
            'id',
            'titulo',
            'descripcion',
            'fecha_informe',
            'usuario__nombre',
            'usuario__apellidos',
        )

    #replace here
    anio_informes = {}

    for aux in informes:
        if aux["fecha_informe"].year not in anio_informes:
            anio_informes[aux["fecha_informe"].year] = {aux["fecha_informe"].month : [obtener_nombre_mes(aux["fecha_informe"].month),1]}
        else:
            if aux["fecha_informe"].month in anio_informes[aux["fecha_informe"].year]:
                anio_informes[aux["fecha_informe"].year][aux["fecha_informe"].month][1] = anio_informes[aux["fecha_informe"].year][aux["fecha_informe"].month][1]+1
            else:
                anio_informes[aux["fecha_informe"].year].update({aux["fecha_informe"].month : [obtener_nombre_mes(aux["fecha_informe"].month),1]})
    
    for aux_informe in informes:
        aux_informe["fecha_informe"] = traducir_fechas(aux_informe["fecha_informe"].strftime("%d de %B del %Y"))
    
    context = {
        'form'                   : form,
        'informacion_secretario' : informacion_secretario,
        'informe'                : informe,
        'anio_informes'          : anio_informes,
        'evidencias'             : evidencias,
        'url_dominio'            : url_dominio,
        'num_actividades'        : num_actividades,
        'num_informes'           : num_informes,
        'frases_buscadas'        : frases_buscadas,
        'ods'                    : ods,
        'link_evidencia'         : link_evidencia,
        'lista_secretarios'      : lista_secretarios,
        'ultimos_informes'       : ultimos_informes,
    }

    return HttpResponse(template.render(context, request))


def busqueda_informe(request):
    
    template = loader.get_template('gestion_abierta/busqueda_informe.html')
    form = ExampleForm()
    frases_buscadas = FraseBuscada.objects.filter(estado=True).values(
        "frase",
        "num_busqueda",
        "color",
    )
    lista_secretarios = UsuarioGestionAbierta.objects.all().values(
        'id',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'foto',
    )
    ultimos_informes = Informe.objects.all().order_by('fecha_informe')[:20]
    num_actividades = Informe.objects.all().count()
    num_informes    = Informe.objects.all()\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()
    if request.method == 'POST':
        form = ExampleForm(request.POST)
        if form.is_valid():
            busqueda = str(form.cleaned_data['busqueda'])
            informes  = Informe.objects.filter(descripcion__icontains=busqueda).values(
                'id',
                'usuario__id',
                'usuario__nombre',
                'usuario__apellidos',
                'fecha_informe',
                'titulo',
                'descripcion',
                'url_evidencia',
            )
            try:
                frase_buscada, created = FraseBuscada.objects.get_or_create(
                    frase=busqueda,
                )
                if not created:
                    frase_buscada.num_busqueda = frase_buscada.num_busqueda+1
                    frase_buscada.color = colores_busqueda(frase_buscada.num_busqueda)
                    frase_buscada.save()
            except Exception as e:
                pass
            for aux in informes:
                aux["fecha_informe"] = traducir_fechas(aux["fecha_informe"].strftime("%d de %B del %Y"))
            context = {
                'informe'                : informes,
                'form'                   : form,
                'frases_buscadas'        : frases_buscadas,
                'lista_secretarios'      : lista_secretarios,
                'ultimos_informes'       : ultimos_informes,
            }
            return HttpResponse(template.render(context, request))
    else:
        context = {
            'informacion_secretario' : "hola",
            'informe'                : {},
            'form'                   : form,
            'num_actividades'        : num_actividades,
            'num_informes'           : num_informes,
            'frases_buscadas'        : frases_buscadas,
            'lista_secretarios': lista_secretarios,
            'num_informes'     : num_informes,
        }
        return HttpResponse(template.render(context, request))


def informacion_gestores(request):
    
    template             = loader.get_template('gestion_abierta/informacion_gestores.html')
    form                 = ExampleForm()
    frases_buscadas = FraseBuscada.objects.filter(estado=True).values(
        "frase",
        "num_busqueda",
        "color",
    )
    informacion_gestores = UsuarioGestionAbierta.objects.all().values(
            'id',
            'foto',
            'perfil__nombre',
            'descripcion',
            'objetivos',
            'nombre',
            'apellidos',
        )
    lista_secretarios = UsuarioGestionAbierta.objects.all().values(
        'id',
        'nombre',
        'apellidos',
        'perfil__nombre',
        'foto',
    )
    for secretario in informacion_gestores:
        secretario["num_actividades"] = Informe.objects.filter(usuario__id = secretario["id"]).count()
        secretario["num_informes"]    = Informe.objects.filter(usuario__id = secretario["id"])\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()
    ultimos_informes = Informe.objects.all().order_by('fecha_informe')[:20]
    num_actividades = Informe.objects.all().count()
    num_informes    = Informe.objects.all()\
                       .annotate(year=ExtractYear('fecha_informe'), month = ExtractMonth('fecha_informe'))\
                       .values('year', 'month')\
                       .distinct()\
                       .count()
    context = {
        'informacion_gestores'   : informacion_gestores,
        'informe'                : {},
        'form'                   : form,
        'num_actividades'        : num_actividades,
        'num_informes'           : num_informes,
        'frases_buscadas'        : frases_buscadas,
        'lista_secretarios'      : lista_secretarios,
        'ultimos_informes'       : ultimos_informes,
    }
    return HttpResponse(template.render(context, request))