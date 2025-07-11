const recordService = require('../services/recordService');

const createRecord = async (req, res) => {
    try {
        const record = await recordService.createRecord(req.body);
        res.status(201).json(record);
    } catch (error) {
        res.status(500).json({error: error.message});
    }
};

const getAllRecords = async (req, res) => {
  try {
    const records = await recordService.getAllRecords();
    res.json(records);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

const getRecordById = async (req, res) => {
  try {
    const record = await recordService.getRecordById(req.params.id);
    if (!record) {
      return res.status(404).json({ error: 'Record not found' });
    }
    res.json(record);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

module.exports = {
    createRecord,
    getAllRecords,
    getRecordById
}