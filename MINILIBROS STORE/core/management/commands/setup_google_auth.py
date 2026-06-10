from django.core.management.base import BaseCommand
from allauth.socialaccount.models import SocialApp
from django.contrib.sites.models import Site

class Command(BaseCommand):
    help = 'Creates a placeholder Google SocialApp to prevent template errors'

    def handle(self, *args, **options):
        # Ensure Site exists
        site, created = Site.objects.get_or_create(id=1, defaults={'domain': 'localhost:8000', 'name': 'MiniLibros Local'})
        if created:
            self.stdout.write(f'Created default Site: {site}')
        
        # Check if Google app exists
        if not SocialApp.objects.filter(provider='google').exists():
            app = SocialApp.objects.create(
                provider='google',
                name='Google Local',
                client_id='PLACEHOLDER_CLIENT_ID',
                secret='PLACEHOLDER_SECRET',
                key=''
            )
            app.sites.add(site)
            self.stdout.write(self.style.SUCCESS('Successfully created placeholder Google SocialApp'))
        else:
            self.stdout.write('Google SocialApp already exists')
