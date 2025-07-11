const express = require('express');
const router = express.Router();

const recordController = require('../controllers/recordController');

router.post('/records', recordController.createRecord);
router.get('/records', recordController.getAllRecords);
router.get('/records/:id', recordController.getRecordById);

module.exports = router