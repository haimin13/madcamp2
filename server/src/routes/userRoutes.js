const express = require('express');
const router = express.Router();

const userController = require('../controllers/userController');
const { validateuser } = require('../middleware/dataValidation');

router.post('/', userController.createUser);
router.get('/', recordController.getAllUsers);
router.get('/:id', recordController.getUserById);
router.get('/verify', userController.verifyUser);

module.exports = router