const routes = require('express').Router();
const add = require('./add');
const get = require('./get');
const getsecondaryquestions = require('./getsecondaryquestions');

routes.route('/add').post(add.post);
routes.route('/get').post(get.post);
routes.route('/getsecondaryquestions').post(getsecondaryquestions.post);

module.exports = routes;