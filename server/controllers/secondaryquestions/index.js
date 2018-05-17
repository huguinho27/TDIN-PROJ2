const routes = require('express').Router();
const add = require('./add');
const get = require('./get');

routes.route('/add').post(add.post);
routes.route('/get').post(get.post);

module.exports = routes;