const routes = require('express').Router();
const auth = require('./auth');

// TEST ONLY
routes.get('/', (req, res, next) =>
{
    res.send("get working");
});
routes.post('/', (req, res, next) =>
{
    res.send("post working");
});

routes.use('/auth', auth);

module.exports = routes;
