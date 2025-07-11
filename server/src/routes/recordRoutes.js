const express = require('express');
const router = express.Router();

const recordController = require('../controllers/recordController');
const { validateRecord } = require('../middleware/dataValidation');

router.post('/', validateRecord, recordController.createRecord);
router.get('/', recordController.getAllRecords);
router.get('/:id', recordController.getRecordById);

module.exports = router