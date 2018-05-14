const routes = require('express').Router();
const auth = require('./auth');

routes.get('/', (req, res, next) =>
{
    res.send("hello there");
});

routes.post('/', (req, res, next) =>
{
    res.send("general kenobi");
});

routes.use('/auth', auth);

module.exports = routes;
