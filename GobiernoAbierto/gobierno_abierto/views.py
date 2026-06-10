from django.shortcuts import render
from django.http import HttpResponse
from django.template import loader



def index(request):
    template = loader.get_template('gobierno_abierto/index_antiguo.html')
    context = {
        'latest_question_list': ["hola","mundo"],
    }
    return HttpResponse(template.render(context, request))


def quienes_somos(request):
    template = loader.get_template('gobierno_abierto/quienes_somos.html')
    context = {
        'latest_question_list': ["hola","mundo"],
    }
    return HttpResponse(template.render(context, request))