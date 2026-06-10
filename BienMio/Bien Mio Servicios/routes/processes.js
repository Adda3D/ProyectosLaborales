const AuthController = require('../controllers/Auth');
const express = require('express');
const ProcessesController = require('../controllers/Processes');
const router = express.Router();

/* GET users listing. */
router.get('/', AuthController.isSignedIn, ProcessesController.getProcesses);
router.get('/:id', AuthController.isSignedIn, ProcessesController.getProcesses);

router.post('/:id', AuthController.isSignedIn, ProcessesController.updateProcess);

//router.delete('/:id', AuthController.isSignedIn, ProcessesController.deleteVisit);

module.exports = router;
