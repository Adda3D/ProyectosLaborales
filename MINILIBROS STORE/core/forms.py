from django import forms
from django.contrib.auth.models import User
from django.contrib.auth.forms import UserCreationForm

class UserRegistrationForm(UserCreationForm):
    email = forms.EmailField(required=True, help_text="Requerido. Se usará para recuperar tu cuenta y vincular compras previas.")
    
    class Meta:
        model = User
        fields = ['username', 'email']
