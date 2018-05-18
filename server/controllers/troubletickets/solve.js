const mongo = require('../../models/db');

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
                return res.send({'error': 0, 'message': 'OK'});
                //send mail here
            }
        });
    }
};