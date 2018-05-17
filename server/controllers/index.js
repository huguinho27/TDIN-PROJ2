const routes = require('express').Router();
const auth = require('./auth');
const secondaryquestions = require('./secondaryquestions');
const troubletickets = require('./troubletickets');
const users = require('./users');

routes.use('/auth', auth);
routes.use('/secondaryquestions', secondaryquestions);
routes.use('/troubletickets', troubletickets);
routes.use('/users',users);

module.exports = routes;
