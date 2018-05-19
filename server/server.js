const express = require('express');
const app = express();
const port = process.env.port || 3000;
const bodyParser = require('body-parser');
const routes = require('./controllers');
const mongo = require('./models/db');
const nodemailer = require('./nodemailer/nodemailer');
const rabbit = require('./rabbitmq/rabbitmq');


app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.use('/', routes);

mongo.connectToServer((err1) =>
{
    if(err1) console.error("Mongodb error: " + err1);
    else
    {
        console.log("Connected to MongoDB");
        mongo.ensureUsersIndex();
    }
});

nodemailer.connectNodemailer((account) =>
{
    if(account === null) console.error("Failed to connect NodeMailer");
    else console.log("Connected to nodemailer with account " + account.user + " " + account.pass);
});

rabbit.connect((err2, conn) =>
{
    if(err2 !== null && conn === null) console.error("Failed to create Rabbit channel");
    else console.log("Connected to RabbitMQ");
    rabbit.send("general kenobi", (fail, sent) => {});
});

app.listen(port, (err) =>
{
    if(err) console.error(err);
    console.log("Listening in port 3000")
});