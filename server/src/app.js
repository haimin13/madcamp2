require('dotenv').config();
const express = require('express');
const cors = require('cors');
const routes = require('./routes');

const app = express();


app.use(cors());
app.use(express.json({ limit: '50mb' }));
app.use(express.urlencoded({ extended: true }));
app.use('/api', routes);

app.get('/', async (req, res) => {
    try {
        res.status(200).send("서버 실행중!");
    } catch (err) {
        res.status(500).send("오류: " + err.message);
    } 
});

module.exports = app;