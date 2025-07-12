const express = require('express');
const router = express.Router();

const recordRoutes = require('./recordRoutes');
const userRoutes = require('./userRoutes');

router.use('/records', recordRoutes);
router.use('/users', userRoutes);

module.exports = router;