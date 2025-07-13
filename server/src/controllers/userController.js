const userService = require('../services/userService');
const validateUser = require('../middleware/dataValidation')

const createUser = async (req, res) => {
    try {
        const user = await userService.createUser(req.params.sub);
        res.status(201).send('User created successfully');
    } catch (error) {
        res.status(500).send(`Failed to create user: ${error.message}`);
    }
};

const getAllUsers = async (req, res) => {
    try {
        const users = await userService.getAllUsers();
        res.json(users);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
};

const getUserBySub = async (req, res) => {
    try {
        const user = await userService.getUserBySub(req.params.sub);
        if (!user) {
            return res.status(404).json({ error: 'User not found' });
        }
        res.json(user);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
};

const verifyUser = async (req, res) => {
    try {
        const user = await userService.verifyUser(req.query.jwtToken);
        if (!user) {
            return res.status(404).json({ error: 'User not found' });
        }
        res.send(user);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const getUserById = async (req, res) => {
    try {
        const user = await userService.getUserById(req.params.id);
        if (!user) {
            return res.status(404).json({ error: 'User not found' });
        }
        res.json(user);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
};

const updateUser = async (req, res) => {
    try {
        const userId = req.params.id;
        const { username1, username2 } = req.body;
        
        const user = await userService.updateUser(userId, username1, username2);
        res.json(user);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
};

module.exports = {
    createUser,
    getAllUsers,
    getUserBySub,
    verifyUser,
    getUserById,
    updateUser
}