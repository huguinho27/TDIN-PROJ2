const mongo = require('../../models/db');

module.exports =
{
    post: (req, res) =>
    {
        const email = req.body.email;
        const password = req.body.password;

        mongo.checkUserLogin({'email':email, 'password':password}, (err1, res1) =>
        {
            if(err1 !== null)
                res.send({'error':1, 'string': err1});
            else
            {
                if(res1.department === '1')
                {
                    //IT Solvers
                    mongo.getTroubleTicketsBySolver({'email':email}, (err3, res3) =>
                    {
                        if(err3) res.send({'error':1, 'string': 'Error getting solver tickets'});
                        else
                            mongo.getTroubleTicketsNotAssigned((err4, res4) =>
                            {
                                if(err4) res.send({'error':1, 'string': 'Error getting solver not assigned tickets'});
                                else res.send({'error': 0, 'string':'OK', 'solverTickets':res3, 'unassignedTickets': res4});
                            });
                    });
                }
                else if(res1.department === '2')
                {
                    //Department Users
                    mongo.getTroubleTicketsByAuthor({'email':email}, (err2, res2) =>
                    {
                        if(err2) res.send({'error':1, 'string': 'Error getting user tickets'});
                        else res.send({'error':0, 'string': 'OK', 'userTickets': res2});
                    });
                }
                else
                    res.send({'error':1, 'string': 'Invalid Department'});
            }
        });
    }
};