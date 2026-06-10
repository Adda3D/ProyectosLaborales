const AuthController = require('../controllers/Auth');
const DocumentsController = require('../controllers/Documents');
const express = require('express');
const router = express.Router();

/* GET Documents listing. */
router.get('/',  AuthController.isSignedIn, DocumentsController.getDocuments);
router.get('/:id',  AuthController.isSignedIn, DocumentsController.getDocuments);

module.exports = router;
