const express = require('express');
const app = express();
const port = process.env.port || 3000;
const bodyParser = require('body-parser');
const routes = require('./controllers');
const mongo = require('./models/db');
const nodemailer = require('./nodemailer/nodemailer');


app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.use('/', routes);

mongo.connectToServer((err) =>
{
    if(err) console.error("Mongodb error: " + err);
    else
    {
        console.log("Connected to MongoDB");
        mongo.ensureUsersIndex();
    }
});
/*
nodemailer.connectNodemailer((err, account) =>
{
    if(err) console.error("Failed to connect NodeMailer" + err);
    else
    {
        console.log("Connected to nodemailer with account " + account.user + " " + account.pass);
        nodemailer.sendMail({'email':'nuno_mgl@hotmail.com', 'title':'ja foste mano', 'description':'como e que e'}, (err, info) =>
        {
           console.log(err, info);
        });
    }


});
*/

app.listen(port, (err) =>
{
    if(err) console.error(err);
    console.log("Listening in port 3000")
});