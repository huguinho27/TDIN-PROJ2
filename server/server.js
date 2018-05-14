const express = require('express');
const app = express();
const port = process.env.port || 3000;
const bodyParser = require('body-parser');
const routes = require('./controllers');
const mongo = require('./models/db');


app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.use('/', routes);

mongo.connectToServer((err) =>
{
    if(err) console.log("Mongodb error: " + err);
    else
    {
        console.log("Connected to MongoDB");
        mongo.ensureUsersIndex();
    }
});

app.listen(port, (err) =>
{
    if(err) console.log(err);
    console.log("Listening in port 3000")
});