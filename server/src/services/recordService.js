const pool = require('../config/mariadb');

const createRecord = async (record) => {
    const query = "INSERT INTO records (user_id, username1, username2, map_id, time_record) " +
    "VALUES (?, ?, ?, ?, ?)";
    const [result] = await pool.query(query, [
        record.user_id, 
        record.username1 || 'user1', 
        record.username2 || 'user2', 
        record.map_id, 
        record.time_record
    ]);
    return { id: result.insertId, ...record};
};

const getAllRecords = async () => {
    const query = 'SELECT * FROM records';
    const [rows] = await pool.query(query);
    return rows;
};

const getRecordById = async (id) => {
    const query = 'SELECT * FROM records WHERE id = ?';
    const [rows] = await pool.query(query, [id]);
    return rows;
}

module.exports = {
    createRecord,
    getAllRecords,
    getRecordById
}