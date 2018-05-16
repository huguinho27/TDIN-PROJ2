const utils = require('../../utils/utils');
const mongo = require('../../models/db');

module.exports =
{
    post: (req, res) =>
    {
        const email = req.body.email;
        const name = req.body.name;
        const department = req.body.department;
        const password = req.body.password;
        const confirmPassword = req.body.confirmPassword;

        console.log(email, name, department, password, confirmPassword);
        console.log(req.body);

        if(email === undefined || name === undefined || department === undefined || password === undefined || confirmPassword === undefined) {
            res.send({'error': 1, 'message': 'Missing parameters' });
        }
        else if(password !== confirmPassword) {
            res.send({'error': 1, 'message': 'Passwords do not match' });
        }
        else if(!utils.validateEmail(email)) {
            res.send({'error': 1, 'message': 'Invalid email' });
        }
        else
        {
            mongo.insertUser(req.body, (err, result) =>
            {
                if(err !== null)
                    res.send({'error': 1, 'message': err });
                else
                {
                    //console.log(result.insertedId); //this is how u get the insertedId
                    res.send({'error': 0, 'message': 'OK', 'userId': result._id});
                }
            });
        }
    }
};
