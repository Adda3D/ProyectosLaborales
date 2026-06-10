const AuthController = require('../controllers/Auth');
const express = require('express');
const { response } = require('../Utils/httpResponses');
const router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});
/* Signup */

router.post('/signup', AuthController.signup);

/* Login */
router.post('/signin', AuthController.signin);


module.exports = router;
