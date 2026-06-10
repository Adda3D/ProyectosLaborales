from celery.schedules import crontab
from celery import shared_task
from gobierno_abierto.service import enviar_backup



@shared_task()
def my_task():
    enviar_backup.Backup.dumpdatabase()