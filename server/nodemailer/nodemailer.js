const nodemailer = require('nodemailer');
const utils = require('../utils/utils');
let transporter;

module.exports =
{
    connectNodemailer: (callback) =>
    {
        transporter = nodemailer.createTransport(
        {
            service: 'gmail',
            auth: {
                user: 'cicawanabe@gmail.com', // generated ethereal user
                pass: 'cicawanab3' // generated ethereal password
            }
        });

        callback(transporter);
    },

    sendMail: (mailOptions, callback) =>
    {
        const description = mailOptions.description;
        const title = mailOptions.title;
        const email = mailOptions.email;
        const answer = mailOptions.answer;

        if(description === undefined || email === undefined || title === undefined || answer === undefined)
            callback('Null description, title, email or answer');
        else if(description === '' || email === '' || title === '' || answer === '')
            callback('No description, email, title orr answer');
        else if(!utils.validateEmail(email))
            callback('Invalid email');
        else
        {
            const options =
            {
                from: '"Cica Wanabe" <' + transporter.options.auth.user + '>',
                to: email,
                subject: title,
                text: 'Your trouble ticket was solved see the question and an answer bellow: \n\n\n'
                + description + "\n\n\nANSWER: " + answer
            };

            transporter.sendMail(options, (err, info) =>
            {
                if(err !== null)
                    callback('Solved trouble ticket but failed to send email', null);
                else
                    callback(null, info);
            });
        }
    }

};