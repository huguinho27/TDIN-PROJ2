const mongo = require('../../models/db');

module.exports =
    {
        post: (req, res) =>
        {
            const email = req.body.email;
            const name = req.body.email;
            const title = req.body.email;
            const description = req.body.email;
            const troubleTicketId = req.body.troubleTicketId;

            if(email === undefined || name === undefined || title === undefined || description === undefined || troubleTicketId === undefined) {
                res.send({'error': 1, 'message': 'Missing parameters' });
            }
            else if(email === '' || name === '' || title === '' || description === '' || troubleTicketId === '') {
                res.send({'error': 1, 'message': 'Cant have empty parameters' });
            }

            mongo.createSecondaryQuestion(req.body, (err, result) =>
            {
                if(err !== null)
                    res.send({'error': 1, 'message': err });
                else
                {
                    //console.log(result.insertedId); //this is how u get the insertedId
                    res.send({'error': 0, 'message': 'OK', 'insertedId': result.insertedId});
                }
            });
        }
    };