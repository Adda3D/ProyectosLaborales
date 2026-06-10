from __future__ import absolute_import
import os
from celery import Celery, shared_task
from django.conf import settings

from celery.schedules import crontab

# set the default Django settings module for the 'celery' program.
os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'gobierno_abierto.settings')

app = Celery('gobierno_abierto')

# Using a string here means the worker will not have to
# pickle the object when using Windows.
app.config_from_object('django.conf:settings')
app.autodiscover_tasks(packages=settings.INSTALLED_APPS)


from celery.schedules import crontab


app.conf.beat_schedule = {
    'add-every-30-seconds': {
        'task': 'gobierno_abierto.task.realizar_backup.my_task',
        'schedule': 30.0,
        'args': (),
    },
}

@app.task(bind=True)
def debug_task(self):
    print('Request: {0!r}'.format(self.request))
