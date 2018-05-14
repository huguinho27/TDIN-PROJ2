const routes = require('express').Router();
const login = require('./login');
const register = require('./register');

routes.route('/login')
    .post(login.post);
routes.route('/register')
    .post(register.post);

module.exports = routes;