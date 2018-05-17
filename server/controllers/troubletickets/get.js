const mongo = require('../../models/db');

module.exports =
{
    post: (req, res) =>
    {
        const id = req.body.id;

        if(id === undefined || id === '')
            res.send({'error':1, 'message':'Invalid given id'});

        mongo.getTroubleTicketById(req.body, (err1, result1) =>
        {
            if(err1 !== null)
                res.send({'error':1, 'message':'Failed to get trouble ticket by id'});
            else
            {
                result1.id = result1._id;
                delete result1._id;
                result1.error = '0';
                result1.message = 'OK';
                res.send(result1);
            }
        });
    }
};