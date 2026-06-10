# MercadoPago Setup Guide

## Getting Your API Credentials

### 1. Create/Login to MercadoPago Account

1. Visit: https://www.mercadopago.com.co
2. Create an account or login with existing credentials

### 2. Access Developer Dashboard

1. Go to: https://www.mercadopago.com.co/developers/panel/credentials
2. You'll see two sets of credentials:
   - **Credenciales de prueba** (Test credentials)
   - **Credenciales de producción** (Production credentials)

### 3. Copy Test Credentials

For development and testing, use the TEST credentials:

1. Find **Public Key** - starts with `TEST-`
   - Example: `TEST-12345678-abcd-1234-abcd-123456789012`
2. Find **Access Token** - starts with `TEST-`
   - Example: `TEST-1234567890123456-012345-abcdefgh1234567890abcdefgh-123456789`

### 4. Update .env File

Open `c:\Users\adda_\minilibros\.env` and update:

```env
MERCADOPAGO_PUBLIC_KEY=TEST-your-public-key-here
MERCADOPAGO_ACCESS_TOKEN=TEST-your-access-token-here
```

**Example:**
```env
MERCADOPAGO_PUBLIC_KEY=TEST-12345678-abcd-1234-abcd-123456789012
MERCADOPAGO_ACCESS_TOKEN=TEST-1234567890123456-012345-abcdefgh1234567890abcdefgh-123456789
```

## Test Cards

### Approved Transactions

**Card Number:** `4509 9535 6623 3704`
- CVV: `123`
- Expiration: `11/25` (any future date)
- Cardholder Name: APRO

### Rejected Transactions

**Card Number:** `4000 0000 0000 0010`
- CVV: `123`
- Expiration: `11/25`
- Cardholder Name: Any name

### Pending Transactions

**Card Number:** `4509 9535 6623 3704`
- CVV: `123`
- Expiration: `11/25`
- Cardholder Name: CONT (wait status)

### More Test Scenarios

Full list: https://www.mercadopago.com.co/developers/es/docs/checkout-api/testing

## Webhook Configuration (Optional)

For production, configure webhook URL:

1. Go to: https://www.mercadopago.com.co/developers/panel/webhooks
2. Add your webhook URL: `https://yourdomain.com/payments/webhook/`
3. Select "Payments" as the event type

**Note:** Webhooks require a publicly accessible URL. For local testing, use ngrok or similar tools.

## Production Setup

### When Ready for Production:

1. Get **Production Credentials** from the same page
2. Update `.env` with production keys (without TEST- prefix)
3. Set `DEBUG=False` in `.env`
4. Configure proper domain in `ALLOWED_HOSTS`

**Production Example:**
```env
MERCADOPAGO_PUBLIC_KEY=APP_USR-12345678-abcd-1234-abcd-123456789012
MERCADOPAGO_ACCESS_TOKEN=APP_USR-1234567890123456-012345-abcdefgh1234567890abcdefgh-123456789
DEBUG=False
ALLOWED_HOSTS=minilibros.com,www.minilibros.com
```

## Troubleshooting

### "Invalid credentials" error

- Verify you copied the entire key (they're very long)
- Make sure there are no extra spaces
- Confirm you're using TEST credentials in development

### Payment not completing

- Check Docker logs: `docker-compose logs web`
- Verify test card number is correct
- Ensure MercadoPago is in test mode

### Webhook not receiving notifications

- Webhook URL must be publicly accessible
- Check firewall settings
- Verify webhook is configured in MercadoPago dashboard

## Support

- MercadoPago Docs: https://www.mercadopago.com.co/developers
- Forum: https://www.mercadopago.com.co/developers/es/support
