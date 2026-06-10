


def traducir_fechas(fecha):
    while(True):
        if "January" in fecha:
            return fecha.replace("January","Enero")
        elif "February" in fecha:
            return fecha.replace("February","Febrero")
        elif "March" in fecha:
            return fecha.replace("March","Marzo")
        elif "April" in fecha:
            return fecha.replace("April","Abril")
        elif "May" in fecha:
            return fecha.replace("May","Mayo")
        elif "June" in fecha:
            return fecha.replace("June","Junio")
        elif "July" in fecha:
            return fecha.replace("July","Julio")
        elif "August" in fecha:
            return fecha.replace("August","Agosto")
        elif "September" in fecha:
            return fecha.replace("September","Septiembre")
        elif "October" in fecha:
            return fecha.replace("October","Octubre")
        elif "November" in fecha:
            return fecha.replace("November","Noviembre")
        elif "December" in fecha:
            return fecha.replace("December","Diciembre")
        return fecha


def obtener_nombre_mes(numero_mes):
    while(True):
        if numero_mes==1:
            return "Enero"
        elif numero_mes==2:
            return "Febrero"
        elif numero_mes==3:
            return "Marzo"
        elif numero_mes==4:
            return "Abril"
        elif numero_mes==5:
            return "Mayo"
        elif numero_mes==6:
            return "Junio"
        elif numero_mes==7:
            return "Julio"
        elif numero_mes==8:
            return "Agosto"
        elif numero_mes==9:
            return "Septiembre"
        elif numero_mes==10:
            return "Octubre"
        elif numero_mes==11:
            return "Noviembre"
        elif numero_mes==12:
            return "Diciembre"
        return "None"


def colores_busqueda(num_busquedas):
    if num_busquedas>= 1 and num_busquedas<5:
        return "#DCFB8A"
    elif num_busquedas>= 5 and num_busquedas<10:
        return "#BBF023"
    elif num_busquedas>= 10 and num_busquedas<15:
        return "#DDF023"
    elif num_busquedas>= 15 and num_busquedas<20:
        return "#6C72E5"
    elif num_busquedas>= 20 and num_busquedas<25:
        return "#535576"
    elif num_busquedas>= 25 and num_busquedas<30:
        return "#C4A5D9"
    elif num_busquedas>= 30 and num_busquedas<35:
        return "#AF22B1"
    else:
        return "#CF077D"