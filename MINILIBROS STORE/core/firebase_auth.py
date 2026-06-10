import firebase_admin
from firebase_admin import auth
from django.contrib.auth.backends import ModelBackend
from django.contrib.auth.models import User

class FirebaseAuthenticationBackend(ModelBackend):
    def authenticate(self, request, id_token=None, **kwargs):
        if not id_token:
            return None
        
        try:
            # Verify the Firebase token
            decoded_token = auth.verify_id_token(id_token)
            uid = decoded_token.get('uid')
            email = decoded_token.get('email')
            name = decoded_token.get('name', '')
            
            if not email:
                return None
                
            # Get or create the user in Django
            user, created = User.objects.get_or_create(username=uid, defaults={
                'email': email,
                'first_name': name.split(' ')[0] if name else '',
                'last_name': ' '.join(name.split(' ')[1:]) if name else '',
            })
            
            # Update email if changed (rare but possible in Firebase)
            if not created and user.email != email:
                user.email = email
                user.save()
                
            return user
        except Exception as e:
            print(f"Error validating Firebase token: {e}")
            return None

    def get_user(self, user_id):
        try:
            return User.objects.get(pk=user_id)
        except User.DoesNotExist:
            return None
