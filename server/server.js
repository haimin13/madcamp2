require('dotenv').config();
const fs = require('fs');
const http = require('http');
const https = require('https');
const app = require('./src/app');

const HTTP_PORT = process.env.PORT || 3000;
const HTTPS_PORT = 3443;

const options = {
    key: fs.readFileSync('./server.key'),
    cert: fs.readFileSync('./server.cert')
};

http.createServer(app).listen(HTTP_PORT, '0.0.0.0', () => {
  console.log(`HTTP 서버 실행 중: ${HTTP_PORT}`);
});

https.createServer(options, app).listen(HTTPS_PORT, '0.0.0.0', () => {
  console.log(`HTTPS 서버 실행 중: ${HTTPS_PORT}`);
});

// app.listen(PORT, '0.0.0.0', () => {
//     console.log(`서버 실행 중: ${PORT}`)
// });