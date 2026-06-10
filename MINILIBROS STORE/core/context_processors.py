def cart_count(request):
    """Add cart item count to all templates"""
    cart = request.session.get('cart', {})
    count = sum(item['quantity'] for item in cart.values())
    return {'cart_count': count}

import os
def firebase_config(request):
    """Add Firebase config to templates"""
    return {
        'firebase_config': {
            'apiKey': os.getenv('FIREBASE_API_KEY', ''),
            'authDomain': os.getenv('FIREBASE_AUTH_DOMAIN', ''),
            'projectId': os.getenv('FIREBASE_PROJECT_ID', ''),
            'storageBucket': os.getenv('FIREBASE_STORAGE_BUCKET', ''),
            'messagingSenderId': os.getenv('FIREBASE_MESSAGING_SENDER_ID', ''),
            'appId': os.getenv('FIREBASE_APP_ID', ''),
        }
    }
