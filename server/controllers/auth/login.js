const mongo = require('../../models/db');

module.exports =
{
    post: (req, res) =>
    {
        const email = req.body.email;
        const password = req.body.password;

        if(email === undefined || email === '' || password === undefined || password === '')
            return res.send({'error': 1, 'message': 'Invalid email or password' });
        else mongo.checkUserLogin(req.body, (err1, res1) =>
        {
            if(err1 !== null)
                return res.send({'error':1, 'message': err1});
            else
            {
                if(res1.department === '2')
                {
                    //Department Users
                    mongo.getTroubleTicketsByEmail({'email':res1.email}, (err2, res2) =>
                    {
                        if(err2) return res.send({'error':1, 'message': 'Error getting user tickets'});
                        else
                        {

                            res2.forEach((tt) =>
                            {
                                tt.id = tt._id;
                                delete tt._id;
                            });

                            return res.send({
                                'error':0,
                                'message': 'OK',
                                'email':res1.email,
                                'name':res1.name,
                                'department':res1.department,
                                'id':res1._id,
                                'userTickets': res2});
                        }
                    });
                }
                else if(res1.department === '1')
                {
                    //IT Solvers
                    mongo.getTroubleTicketsBySolver({'solverId':res1._id}, (err3, res3) =>
                    {
                        if(err3) return res.send({'error':1, 'message': 'Error getting solver tickets'});
                        else
                            mongo.getTroubleTicketsNotAssigned((err4, res4) =>
                            {
                                if(err4) return res.send({'error':1, 'message': 'Error getting solver not assigned tickets'});
                                else
                                {
                                    res3.forEach((tt) =>
                                    {
                                        tt.id = tt._id;
                                        delete tt._id;
                                    });

                                    res4.forEach((tt) =>
                                    {
                                        tt.id = tt._id;
                                        delete tt._id;
                                    });


                                    return res.send({
                                        'error': 0,
                                        'message':'OK',
                                        'email':res1.email,
                                        'name':res1.name,
                                        'department':res1.department,
                                        'id':res1._id,
                                        'solverTickets':res3,
                                        'unassignedTickets': res4
                                    });
                                }
                            });
                    });
                }
                else
                    return res.send({'error':1, 'message': 'Invalid Department'});
            }
        });
    }
};