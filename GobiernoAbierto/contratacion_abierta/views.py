from django.shortcuts import render
from django.http import HttpResponse
from django.template import loader



def index(request):
    template = loader.get_template('contratacion_abierta/index.html')
    context = {
        'datos_graficos_ipcc': """{"valor": 3004993138, "modalidad": "Contratacion directa 45", "anio": "2022", "Valor": "30049931382", "color":"#B9BF04", "porcentaje":"100,00%"}""",
    }
    #input(context)
    return HttpResponse(template.render(context, request))