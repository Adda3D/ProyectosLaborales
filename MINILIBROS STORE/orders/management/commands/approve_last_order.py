from django.core.management.base import BaseCommand
from orders.models import Order, PaymentStatus
from library.models import LibraryAccess
from redirects.models import RedirectCode
from django.contrib.contenttypes.models import ContentType

class Command(BaseCommand):
    help = 'Approves the last pending order locally (for development testing)'

    def handle(self, *args, **options):
        # Find the last order (regardless of status, but ideally pending)
        order = Order.objects.last()
        
        if not order:
            self.stdout.write(self.style.ERROR('No orders found'))
            return

        self.stdout.write(f'Processing order: {order.order_number} (Current status: {order.payment_status})')

        # Approve order
        order.payment_status = PaymentStatus.COMPLETED
        order.payment_id = 'MANUAL_APPROVAL_DEV'
        order.save()

        # Grant library access to all items
        for item in order.items.all():
            if order.user:
                LibraryAccess.objects.get_or_create(
                    user=order.user,
                    content_type=item.content_type,
                    object_id=item.object_id
                )
                
                # Create redirect code for this item
                RedirectCode.objects.get_or_create(
                    content_type=item.content_type,
                    object_id=item.object_id,
                    user=order.user
                )
                self.stdout.write(f'  Granted access to: {item}')
            else:
                self.stdout.write(f'  Skipped library access (Guest user). Will be assigned on registration.')

        self.stdout.write(self.style.SUCCESS(f'Successfully approved order {order.order_number}'))
