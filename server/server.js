require('dotenv').config();
const fs = require('fs');
const app = require('./src/app');
const HTTP_PORT = process.env.PORT || 3000;

app.listen(HTTP_PORT, '0.0.0.0', () => {
    console.log(`서버 실행 중: ${HTTP_PORT}`)
});