const mongo = require('../../models/db');
const rabbitmq = require('../../rabbitmq/rabbitmq');

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
                return res.send({'error': 1, 'message': 'Missing parameters' });
            }
            else if(email === '' || name === '' || title === '' || description === '' || troubleTicketId === '') {
                return res.send({'error': 1, 'message': 'Cant have empty parameters' });
            }

            else mongo.createSecondaryQuestion(req.body, (err, result) =>
            {
                if(err !== null)
                    return res.send({'error': 1, 'message': err });
                else
                {
                    //console.log(result.insertedId); //this is how u get the insertedId
                    rabbitmq.send(JSON.stringify(result));
                    return res.send({'error': 0, 'message': 'OK', 'insertedId': result.insertedId});
                }
            });
        }
    };