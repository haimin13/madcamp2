const pool = require('../config/mariadb');

const createUser = async (sub) => {
    const query = "INSERT INTO users (id_google) VALUES (?)";
    const [result] = await pool.query(query, [sub]);

    return { id: result.insertId, id_google: sub };
};

const getAllUsers = async () => {
    const query = 'SELECT id, username1, username2 FROM users';
    const [rows] = await pool.query(query);
    return rows;
};

const getUserBySub = async (sub) => {
    const query = 'SELECT id, username1, username2 FROM users WHERE id_google = ?';
    const [rows] = await pool.query(query, [sub]);
    return rows[0];
};

const verifyUser = async (jwtToken) => {
    try {
        const tokenParts = jwtToken.split('.');
        const payload = tokenParts[1];
        const decodedPayload = Buffer.from(payload, 'base64').toString('utf8');
        console.log(decodedPayload);

        const userInfo = JSON.parse(decodedPayload);
        const result = {
            sub: userInfo.sub,
            email: userInfo.email,
        }
        return result;
    } catch (e) {
        return false
    }
};

const getUserById = async (id) => {
    const query = 'SELECT * FROM users WHERE id = ?';
    const [rows] = await pool.query(query, [id]);
    return rows[0];
};

const updateUser = async (userId, username1, username2) => {
    const query = "UPDATE users SET username1 = ?, username2 = ? WHERE id = ?";
    const [result] = await pool.query(query, [username1, username2, userId]);
    
    return {
        id: userId,
        username1: username1,
        username2: username2,
        updated: true
    };
};

module.exports = {
    createUser,
    getAllUsers,
    getUserBySub,
    verifyUser,
    getUserById,
    updateUser
};