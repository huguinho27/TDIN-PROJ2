const mongo = require('../../models/db');

module.exports =
{
    post: (req, res) =>
    {
        const id = req.body.id;

        if(id === undefined || id === '')
            return res.send({'error':1, 'message':'Invalid given id'});

        else mongo.getSecondaryQuestionByTroubleTicketId(req.body, (err, result) =>
        {
           if(err !== null)
               return res.send({'error':1, 'message':'Failed to retrieve secondary Tickets'});
           else
           {
               result.forEach((sq) =>
               {
                  sq.id = sq._id;
                  delete sq._id;
               });

               return res.send({
                   'error':0,
                   'message':'OK',
                   'secondaryQuestions': result
               });
           }
        });
    }
};