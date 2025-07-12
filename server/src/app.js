require('dotenv').config();
const express = require('express');
const cors = require('cors');
const routes = require('./routes');

const app = express();

const corsOptions = {
    origin: [
        'http://localhost:3000',
        'http://16.176.11.76:3000',
        'http://127.0.0.1:5500'
    ],
    credentials: true,
    optionsSuccessStatus: 200
};

app.use(cors(corsOptions));
app.options('*', cors(corsOptions));
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