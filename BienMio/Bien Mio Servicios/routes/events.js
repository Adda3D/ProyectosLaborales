const AuthController = require('../controllers/Auth');
const EventsController = require('../controllers/Events');
const express = require('express');
const router = express.Router();

/* GET users listing. */
router.get('/',  AuthController.isSignedIn, EventsController.getEvents);
router.get('/:id',  AuthController.isSignedIn, EventsController.getEvents);

module.exports = router;
