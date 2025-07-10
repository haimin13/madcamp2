require('dotenv').config();
const express = require('express');
const pool = require('./config/mariadb');

const app = express();

app.get('/', async (req, res) => {
    try {
        const [rows] = await pool.query('SELECT * FROM users');
        res.json(rows);
    } catch (err) {
        res.status(500).send("db 오류: " + err.message);
    } 
});

module.exports = app;