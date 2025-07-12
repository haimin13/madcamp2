const express = require('express');
const cors = require('cors');
const path = require('path');
const routes = require('./routes');

const app = express();

app.use(cors());
app.use(express.json({ limit: '50mb' }));
app.use(express.urlencoded({ extended: true }));

app.use((req, res, next) => {
    if (req.url.endsWith('.wasm')) {
        res.type('application/wasm');
    } else if (req.url.endsWith('.data')) {
        res.type('application/octet-stream');
    } else if (req.url.endsWith('.js')) {
        res.type('application/javascript');
    } else if (req.url.endsWith('.gz')) {
        res.set('Content-Encoding', 'gzip');
    }
    next();
});
app.use('/game', express.static(path.join(__dirname, './GameBuild')));

app.use('/api', routes);

app.get('/game', (req, res) => {
    res.sendFile(path.join(__dirname, "./GameBuild",'index.html'))
})

app.get('/', async (req, res) => {
    try {
        res.status(200).send("서버 실행중!");
    } catch (err) {
        res.status(500).send("오류: " + err.message);
    } 
});

module.exports = app;