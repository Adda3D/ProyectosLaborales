const AuthController = require('../controllers/Auth');
const express = require('express');
const VisitsController = require('../controllers/Visits');
const { upload } = require('../app');
const router = express.Router();

/* GET users listing. */
router.get('/', AuthController.isSignedIn, VisitsController.getVisits);
router.get('/:id', AuthController.isSignedIn, VisitsController.getVisits);
router.post('/', AuthController.isSignedIn, VisitsController.createVisit);

router.post('/:id', AuthController.isSignedIn, VisitsController.updateVisit);

router.delete('/:id', AuthController.isSignedIn, VisitsController.deleteVisit);

module.exports = router;
