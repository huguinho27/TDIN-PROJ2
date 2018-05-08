const routes = require('express').Router();

routes.get('*', (req, res, next) =>
{
    res.send("hello");
});

routes.post('*', (req, res, next) =>
{
    res.send("hello");
});

module.exports = routes;
