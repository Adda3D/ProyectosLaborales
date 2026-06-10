const AuthController = require('../controllers/Auth');
const UsersController = require('../controllers/Users');
const express = require('express');
const router = express.Router();

/* GET users listing. */
router.get('/',  AuthController.isSignedIn, UsersController.getUsers);
router.get('/:id',  AuthController.isSignedIn, UsersController.getUsers);

router.post('/:id', AuthController.isSignedIn, UsersController.updateUser);

router.delete('/:id', AuthController.isSignedIn, UsersController.deleteUser);

module.exports = router;
