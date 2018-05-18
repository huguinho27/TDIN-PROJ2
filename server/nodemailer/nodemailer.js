const nodemailer = require('nodemailer');
const utils = require('../utils/utils');
let transporter;

module.exports =
{
    connectNodemailer: (callback) =>
    {
        nodemailer.createTestAccount((err, account) =>
        {
            // create reusable transporter object using the default SMTP transport
            transporter = nodemailer.createTransport(
            {
                host: 'smtp.ethereal.email',
                port: 587,
                secure: false, // true for 465, false for other ports
                auth: {
                    user: account.user, // generated ethereal user
                    pass: account.pass // generated ethereal password
                }
            });

            callback(err, account);
        });
    },

    sendMail: (mailOptions, callback) =>
    {
        const description = mailOptions.description;
        const title = mailOptions.title;
        const email = mailOptions.email;

        if(description === undefined || email === undefined || title === undefined )
            callback('Null description, title or email');
        else if(description === '' || email === '' || title === '')
            callback('No description, email or title');
        else if(!utils.validateEmail(email))
            callback('Invalid email');
        else
        {
            const options =
            {
                from: '"Cica Wanabe" <' + transporter.options.auth.user + '>',
                to: email,
                subject: 'RE: ' + title,
                text: 'Your trouble ticket was solved see the answer bellow \n\n' + description
            };

            transporter.sendMail(options, (err, info) =>
            {
                if(err !== null)
                    callback('Failed to send email', null);
                else
                    callback(null, info);
            });
        }
    }

};