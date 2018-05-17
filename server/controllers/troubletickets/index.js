const routes = require('express').Router();
const add = require('./add');
const get = require('./get');
const getsecondaryquestions = require('./getsecondaryquestions');
const solve = require('./solve');
const assign = require('./assign');

routes.route('/add').post(add.post);
routes.route('/get').post(get.post);
routes.route('/getsecondaryquestions').post(getsecondaryquestions.post);
routes.route('/solve').post(solve.post);
routes.route('/assign').post(assign.post);

module.exports = routes;