const mongo = require('../../models/db');
const nodemailer = require('../../nodemailer/nodemailer');

module.exports =
{
    post: (req, res) =>
    {
        const id = req.body.id;
        const answer = req.body.answer;

        if(id === '' || answer === '' || id === undefined || answer === undefined)
            return res.send({'error':1, 'message':'Invalid trouble ticket id or answer'});

        else mongo.solveTroubleTicket(req.body, (err, result) =>
        {
            if(err !== null)
                return res.send({'error':1, 'message':err});
            else
            {
                mongo.getTroubleTicketById(req.body, (err1, result1) =>
                {
                    if(err1 !== null)
                        return res.send({'error':1, 'message':'Failed to get trouble ticket from db in order to send mail'});
                    else
                    {
                        nodemailer.sendMail(
                            {
                                'description':result1.description,
                                'answer':result1.answer,
                                'title':result1.title,
                                'email':result1.email
                            },
                            (err2, res2) => {if(err2 !== null) console.log(err2);});

                        return res.send({'error': 0, 'message': 'OK'});
                    }
                });

            }
        });
    }
};