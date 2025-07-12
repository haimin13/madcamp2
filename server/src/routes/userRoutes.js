const express = require('express');
const router = express.Router();

const userController = require('../controllers/userController');
const { validateuser } = require('../middleware/dataValidation');

router.post('/', userController.createUser);
router.get('/', userController.getAllUsers);
router.get('/verify', userController.verifyUser);
router.get('/:id', userController.getUserById);

module.exports = router