from django.test import TestCase
from usuario.models import Usuario, UsuarioGestionAbierta
from django.test import TestCase
from gestion_abierta.models import Informe, EstadoInformeChoice
from django.contrib.auth.models import Permission



class LogInTest(TestCase):
    def setUp(self):
        self.credentials = {
            'correo': 'cpadillar1995@gmail.com',
            'password': 'loquillo1995'
        }
        Usuario.objects.create_user(**self.credentials)
    def test_login(self):
        # send login data
        response = self.client.post('/admin/', self.credentials, follow=True)
        # should be logged in now
        self.assertTrue(response.context['user'] != "AnonymousUser")


class GestionAbiertaTest(TestCase):

    @classmethod
    def setUpTestData(cls):

        #Set up non-modified objects used by all test methods
        usuario1 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal1', 
            apellidos='Padilla1', 
            correo="cpadillar1991@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario1,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario2 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal2', 
            apellidos='Padilla2', 
            correo="cpadillar1992@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario2,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario3 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal3', 
            apellidos='Padilla3', 
            correo="cpadillar1993@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario3,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario4 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal4', 
            apellidos='Padilla4', 
            correo="cpadillar1994@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario4,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario5 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal5', 
            apellidos='Padilla5', 
            correo="cpadillar1995@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario5,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario6 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal6', 
            apellidos='Padilla6', 
            correo="cpadillar1996@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario6,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario7 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal7', 
            apellidos='Padilla7',  
            correo="cpadillar1997@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario7,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario8 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal8', 
            apellidos='Padilla8',  
            correo="cpadillar1998@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario8,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario9 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal9', 
            apellidos='Padilla9', 
            correo="cpadillar1999@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario9,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )
        usuario10 = UsuarioGestionAbierta.objects.create(
            nombre='Cristobal10', 
            apellidos='Padilla10',  
            correo="cpadillar2000@gmail.com", 
            password="adasdadsdf"
        )
        Informe.objects.create(
            usuario = usuario10,
            titulo  = "titulo de prueba",
            descripcion = "descripcion de prueba",
            fecha_informe = "2021-10-10",
        )

    def test_titulo(self):
        informe=Informe.objects.get(id=1)
        titulo = informe.titulo
        self.assertEquals(titulo,'titulo de prueba')

    def test_usuario(self):
        informe=Informe.objects.get(id=1)
        correo = informe.usuario.correo
        self.assertEquals(correo,'cpadillar1991@gmail.com')

    def test_descripcion(self):
        informe=Informe.objects.get(id=1)
        descripcion = informe.descripcion
        self.assertEquals(descripcion,"descripcion de prueba")

    def test_fecha_informe(self):
        informe = Informe.objects.get(id=1)
        fecha_informe = str(informe.fecha_informe)
        self.assertEquals(fecha_informe,"2021-10-10")

    def test_first_name_label(self):
        author=Usuario.objects.get(id=1)
        field_label = author.nombre 
        self.assertEquals(field_label,'Cristobal1')

    def test_date_of_last_name(self):
        author=Usuario.objects.get(id=1)
        apellidos = author.apellidos
        self.assertEquals(apellidos,'Padilla1')

    def test_correo(self):
        author=Usuario.objects.get(id=1)
        correo = author.correo
        self.assertEquals(correo,"cpadillar1991@gmail.com")

    def test_add_permission_informe_to_usuariogestionabierta(self):
        author=Usuario.objects.get(id=1)
        author.user_permissions.add(Permission.objects.get(codename='add_informe'))
        author.user_permissions.add(Permission.objects.get(codename='view_informe'))
        author = UsuarioGestionAbierta.objects.get(pk=author.pk)
        self.assertTrue(author.has_perm('gestion_abierta.add_informe'))
        self.assertTrue(author.has_perm('gestion_abierta.view_informe'))