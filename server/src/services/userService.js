const pool = require('../config/mariadb');

const createUser = async (user) => {
    const query = "INSERT INTO users (id_google) " +
    "VALUES (?)";
    const [result] = await pool.query(query, [
        user.id_google
    ]);
    return { id: result.insertId, ...user};
};

const getAllUsers = async () => {
    const query = 'SELECT * FROM users';
    const [rows] = await pool.query(query);
    return rows;
};

const getUserById = async (id) => {
    const query = 'SELECT * FROM users WHERE id_google = ?';
    const [rows] = await pool.query(query, [id]);
    return rows;
}

const verifyUser = async (id) => {
    
}

module.exports = {
    createUser,
    getAllUsers,
    getUserById
};