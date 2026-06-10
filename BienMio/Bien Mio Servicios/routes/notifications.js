const AuthController = require('../controllers/Auth');
const express = require('express');
const NotificationsController = require('../controllers/Notifications');
 const router = express.Router();


router.post('/subscribe', AuthController.isSignedIn, NotificationsController.suscribe);

// router.post('/:id', AuthController.isSignedIn, RolesController.updateRole);

// router.delete('/:id', AuthController.isSignedIn, RolesController.deleteRole);

module.exports = router;
