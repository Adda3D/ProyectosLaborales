from djchoices import DjangoChoices, ChoiceItem


class EstadoInformeChoice(DjangoChoices):
    publicado     = ChoiceItem("Publicado")
    descartado    = ChoiceItem("Descartado")
    sin_publicar  = ChoiceItem("Sin publicar")