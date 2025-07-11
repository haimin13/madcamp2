require('dotenv').config();
const express = require('express');
const recordRoutes = require('./routes/recordRoutes');

const pool = require('./config/mariadb');

const app = express();

app.use(express.json());
app.use('/api', recordRoutes);

app.get('/', async (req, res) => {
    try {
        res.status(200).send("서버 실행중!");
    } catch (err) {
        res.status(500).send("오류: " + err.message);
    } 
});

module.exports = app;