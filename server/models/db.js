const bcrypt = require('bcrypt');
const saltRounds = 10;
const mongo = require('mongodb');
const mongoURL = "mongodb://localhost:27017/";
const mongoDB = "ttdb";
const usersCollection = "users";
const troubleTicketsCollection = "troubleTickets";
const secondaryTicketsCollection = "secondaryQuestions";
let _db;

module.exports =
{
    /**
     * Server connection handler
     */
    connectToServer: (callback) => {
        mongo.MongoClient.connect(mongoURL, (err, db) => {
            _db = db.db(mongoDB);
            return callback(err);
        });
    },

    /**
     * Index handlers
     */
    ensureUsersIndex: () =>
    {
        _db.collection(usersCollection).ensureIndex({email:1}, {unique:true}, (err, res) =>
        {
            if(!err) console.log("Ensured Users index");
            else console.err("Could not ensure Users index");
        })
    },

    insertUser: (data, callback) =>
    {
        bcrypt.hash(data.password, saltRounds, (err1, hash) =>
        {
            if(err1)
                callback('Can\'t hash password', null);
            else
                _db.collection(usersCollection).insertOne(
                    {
                        'email':data.email,
                        'password':hash,
                        'name':data.name,
                        'department':data.department
                    },
                    (err2, result) =>
                {
                    if(err2)
                        callback('User already exists', null);
                    else
                        callback(null, result);
                });
        });
    },

    checkUserLogin: (data, callback) =>
    {
        const email = data.email;
        const password = data.password;

        _db.collection(usersCollection).findOne({'email':email}, (err, res) =>
        {
            if(err) callback('User does not exist', null);
            else
                bcrypt.compare(password, res.password, (err1, res1) =>
                {
                    if(err1) callback('Password does not match', null);
                    else callback(null, {'email': email, 'name':res.name, 'department': res.department});
                });
        });
    },

    getTroubleTicketsByAuthor: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'author':data.email}).toArray((err, docs) =>
        {
            callback(err, docs);
        });
    },

    getTroubleTicketsBySolver: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'solver':data.email}).toArray((err, docs) =>
        {
            callback(err, docs);
        });
    },

    getTroubleTicketsNotAssigned: (callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'state':'unassigned'}).toArray((err, docs) =>
        {
            callback(err, docs);
        });
    },

    createTroubleTicket: (data, callback) =>
    {
        // TODO: implement
    },

    assignSolverToTroubleTicket: (data, callback) =>
    {
        //TODO: implement
    },

    assignSecondaryQuestionToTroubleTicket: (data, callback) =>
    {
        //TODO: implement
    },

    createSecondaryQuestion: (data, callback) =>
    {
        //TODO: implement
    },

    solveSecondaryQuestionAndUpdateTroubleTicket: (data, callback) =>
    {
        //TODO: implement
        //NOTE: this one will be tough....
    }


};