const AuthController = require('../controllers/Auth');
const express = require('express');
const FilesController = require('../controllers/Files');
const router = express.Router();
const path = require('path');

/* GET files listing. */
router.post('/', AuthController.isSignedIn, FilesController.uploadFile);
router.post('/:type', AuthController.isSignedIn, FilesController.uploadFile);
//express().use('/uploads',  AuthController.isSignedIn,express.static(path.join(__dirname, 'uploads')));
//router.get('/uploads', AuthController.isSignedIn ,express.static('uploads'))//path.join(__dirname, 'uploads')

module.exports = router;
