const Record = require('../models/Record');

const validateRecord = (req, res, next) => {
  const errors = Record.validate(req.body);
  if (errors.length > 0) {
    return res.status(400).json({ errors });
  }
  next();
};

module.exports = {
    validateRecord
};