#from shareplum import Site
#from shareplum import Office365
#from shareplum.site import Version
#import hashlib
import datetime
from threading import local
from gobierno_abierto import settings
import os
import environ
from subprocess import PIPE,Popen
import shlex
import os
from datetime import datetime
import boto3

from gobierno_abierto import settings



class Backup:

    @staticmethod
    def enviar_backup(ruta_archivo,nombre_archivo,key,secret_key):
        s3 = boto3.resource('s3',
            aws_access_key_id=key,
            aws_secret_access_key= secret_key
        )
        for bucket in s3.buckets.all():
            print(bucket.name)
        data = open(ruta_archivo, 'rb')
        s3.Bucket('gobiernoabiertobucket').put_object(Key=nombre_archivo, Body=data)

    @staticmethod
    def dumpdatabase():
        now = datetime.now()
        usuario  = settings.DATABASES["default"]["USER"]
        password = settings.DATABASES["default"]["PASSWORD"]
        nombre_archivo = str(now.strftime("%d_%m_%Y%H_%M_%S"))+".sql"
        ruta_archivo = str(settings.BASE_DIR)+"/"+nombre_archivo
        backup_command = "pg_dump --dbname=postgresql://{}:{}@{}:{}/{} -F c --file {}".format(usuario,password, "127.0.0.1", "5432", "gobierno_abierto", ruta_archivo)
        p = Popen(backup_command,shell=True,stdin=PIPE,stdout=PIPE,stderr=PIPE)
        salida = p.communicate()
        Backup.enviar_backup(ruta_archivo,nombre_archivo,str(settings.AWS_ACCESS_KEY_ID),str(settings.AWS_SECRET_ACCESS_KEY_ID))
        print(backup_command)
        os.unlink(ruta_archivo)
            
        



"""nombre_archivo  = str("{}-{}".format(str("backup_gobierno_abierto"), str(datetime.datetime.today())))
for x in ["@",".",":","-","_"," "]:
    nombre_archivo = nombre_archivo.replace(x,"")
nombre_archivo = str(nombre_archivo + ".xlsx")
nombre_archivo = "hola.txt"
ruta_archivo    = settings.BASE_DIR+"/"+nombre_archivo
authcookie = Office365('{}/'.format("https://alcart.sharepoint.com"), username="desarrollo7oai@cartagena.gov.co", password="Loquillo1995").GetCookies()
site = Site('{}/sites/{}/'.format("https://alcart.sharepoint.com/","backup"), version=Version.v365, authcookie=authcookie)
print(site)
print("hola")
#url_shared_point = "{}".format("https://alcart.sharepoint.com/sites/backup/Documentos%20compartidos/Forms/AllItems.aspx?id=%2Fsites%2Fbackup%2FDocumentos%20compartidos%2Fbackup%5Fgobierno%5Fabierto&viewid=15425496%2D7c9b%2D49b9%2Daf21%2Dd4f25c687ee2")
#print(url_shared_point)
folder = site.Folder("Documentos compartidos/backup_gobierno_abierto")
#with open(ruta_archivo, mode='rb') as file:
#    fileContent = file.read()
#nombre_temporal = str(datetime.date.today())+str(random.random())+".xlsx"
#folder.upload_file(fileContent,"{}".format(nombre_archivo))
#os.unlink(ruta_archivo)"""