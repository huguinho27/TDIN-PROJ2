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
            return callback(err, null);
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
            if(err === null && res === null) callback('User does not exist', null);
            else
                bcrypt.compare(password, res.password, (err1, res1) =>
                {
                    if(err1) callback('Password does not match', null);
                    else callback(null, {'email': email, 'name':res.name, 'department': res.department, 'id':res._id});
                });
        });
    },

    getTroubleTicketsByEmail: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'email':data.email}).toArray((err, docs) =>
        {
            callback(err, docs);
        });
    },

    getTroubleTicketsBySolver: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'solverId':data.solverId}).toArray((err, docs) =>
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
        _db.collection(troubleTicketsCollection).insertOne(
            {
                'email': data.email,
                'name': data.name,
                'title': data.title,
                'description': data.description,
                'date': (new Date).getTime(),
                'state': 'unassigned',
            },
            (err, res) =>
            {
                if(err === null)
                    callback(null, res);
                else
                    callback('Failed to Create new Ticket', null);
            });
    },

    assignSolverToTroubleTicket: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).updateOne(
            {'_id': new mongo.ObjectId(data.id)},
            {$set: {'solverId': data.solverId, 'solverName':data.solverName, 'state':'assigned'}},
            (err, res) =>
            {
                if(err === null)
                    callback(null, res);
                else
                    callback('Failed to assign solver to ticket', null);
            });
    },

    createSecondaryQuestion: (data, callback) =>
    {
        _db.collection(secondaryTicketsCollection).insertOne(
            {
                'title':data.title,
                'description':data.description,
                'troubleTicketId': data.troubleTicketId,
                'state':'waiting'
            },
            (err, res) =>
            {
                if(err !== null)
                    callback('Failed to create Secondary Question', null);
                else
                    _db.collection(troubleTicketsCollection).updateOne(
                        {'_id': new mongo.ObjectId(data.troubleTicketId),'state': {$not: 'solved'}},
                        {$set: {'state':'waiting'}},
                        (err1, res1) =>
                        {
                            if(res1.modifiedCount < 1)
                                callback('Failed to update trouble to waiting, probably is solved already', null);
                            else if(err1 === null)
                                callback(null, res);
                            else
                                callback('Failed to update trouble ticket to waiting', null);
                        }
                    );
            }
        );
    },

    solveSecondaryQuestion: (data, callback) =>
    {
        _db.collection(secondaryTicketsCollection).updateOne(
            {'_id': new mongo.ObjectId(data.id)},
            {$set: {'answer':data.answer, 'state':'solved'}},
            (err, res) =>
            {
                if(err === null)
                    callback(null, res);
                else
                    callback('Failed to solve Secondary Question', null);
            }
        )
    },

    solveTroubleTicket: (data, callback) =>
    {

        _db.collection(secondaryTicketsCollection).find({'troubleTicketId':data.troubleTicketId}).toArray((err, docs) =>
        {
           if(err)
               callback('Could not retrieve Secondary Tickets', null);
           else
               {
                   docs.forEach((obj) =>
                   {
                       if(obj.status === 'waiting')
                           callback('Some secondary tickets are not yet solved', null);
                   });

                   _db.collection(troubleTicketsCollection).updateOne(
                       {'_id': new mongo.ObjectId(data.id)},
                       {$set: {'answer': data.answer, 'state': 'solved'}},
                       (err, res) => {
                           if (err === null)
                               callback(null, res);
                           else
                               callback('Failed to solve Trouble Ticket', null);
                       }
               );
           }
        });
    }
};