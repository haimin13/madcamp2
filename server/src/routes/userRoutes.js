const express = require('express');
const router = express.Router();

const userController = require('../controllers/userController');
const { validateuser } = require('../middleware/dataValidation');

router.post('/:sub', userController.createUser);
router.get('/', userController.getAllUsers);
router.get('/verify', userController.verifyUser);
router.get('/sub/:sub', userController.getUserBySub);
router.get('/id/:id', userController.getUserById);
router.put('/:id', userController.updateUser);

module.exports = router