const routes = require('express').Router();
const get = require('./get');

routes.route('/get').post(get.post);

module.exports = routes;