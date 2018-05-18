const mongo = require('../../models/db');

module.exports =
{
    post: (req, res) =>
    {
        const id = req.body.id;
        const solverId = req.body.solverId;
        const solverName = req.body.solverName;

        if(id === '' || solverId === '' || solverName === '' || id === undefined || solverId === undefined || solverName === undefined)
            return res.send({'error':1, 'message':'Invalid trouble ticket id, solver id or solver name'});

        else mongo.assignSolverToTroubleTicket(req.body, (err, result) =>
        {
            if(err !== null)
                return res.send({'error':1, 'message':err});
            else
                return res.send({'error':0, 'message':'OK'});
        });
    }
};
