from djchoices import DjangoChoices, ChoiceItem



class SecretariaChoice(DjangoChoices):
    secretaria_educacion  = ChoiceItem("Secretaria de Educacion")