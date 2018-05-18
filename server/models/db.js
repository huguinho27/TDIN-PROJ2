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
                return callback('Can\'t hash password', null);
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
                        return callback('User already exists', null);
                    else
                        return callback(null, result);
                });
        });
    },

    getUserById : (data, callback) =>
    {
        const id = data.id;

        if(id === undefined)
            return callback('Please Provide ID', null);

        _db.collection(usersCollection).findOne({'_id': new mongo.ObjectId(data.id)}, (err, res) =>
        {
            if(err)
                return callback('Failed to retrieve user from database', null);
            else
                return callback(null, res);
        });
    },

    checkUserLogin: (data, callback) =>
    {
        const email = data.email;
        const password = data.password;

        _db.collection(usersCollection).findOne({'email':email}, (err, res) =>
        {
            if(err === null && res === null) return callback('User does not exist', null);
            else
                bcrypt.compare(password, res.password, (err1, res1) =>
                {
                    if(err1) return callback('Password does not match', null);
                    else return callback(null, {'email': email, 'name':res.name, 'department': res.department, '_id':res._id});
                });
        });
    },

    getTroubleTicketsByEmail: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'email':data.email}).toArray((err, docs) =>
        {
            return callback(err, docs);
        });
    },

    getTroubleTicketsBySolver: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).find({'solverId':data.solverId.toString()}).toArray((err, docs) =>
        {
            return callback(err, docs);
        });
    },

    getTroubleTicketsNotAssigned: (callback) =>
    {

        _db.collection(troubleTicketsCollection).find({'state':'unassigned'}).toArray((err, docs) =>
        {
            return callback(err, docs);
        });
    },

    getTroubleTicketById: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).findOne({'_id': new mongo.ObjectId(data.id)}, (err, res) =>
        {
            return callback(err, res);
        });
    },

    getSecondaryQuestionByTroubleTicketId: (data, callback) =>
    {
        _db.collection(secondaryTicketsCollection).find({'troubleTicketId':data.id}).toArray((err, docs) =>
        {
            return callback(err, docs);
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
                    return callback(null, res);
                else
                    return callback('Failed to Create new Ticket', null);
            });
    },

    assignSolverToTroubleTicket: (data, callback) =>
    {
        _db.collection(troubleTicketsCollection).updateOne(
            {'_id': new mongo.ObjectId(data.id), 'state':'unassigned'},
            {$set: {'solverId': data.solverId, 'solverName':data.solverName, 'state':'assigned'}},
            (err, res) =>
            {
                if(res !== null && res.matchedCount < 1)
                    return callback('Trouble ticket already assigned', null);
                else if(err === null)
                    return callback(null, res);
                else
                    return callback('Failed to assign solver to ticket', null);
            });
    },

    createSecondaryQuestion: (data, callback) =>
    {
        _db.collection(secondaryTicketsCollection).insertOne(
            {
                'email':data.email,
                'name':data.name,
                'title':data.title,
                'description':data.description,
                'troubleTicketId': data.troubleTicketId,
                'date': (new Date).getTime(),
                'state':'waiting'
            },
            (err, res) =>
            {
                if(err !== null)
                    return callback('Failed to create Secondary Question', null);
                else
                    _db.collection(troubleTicketsCollection).updateOne(
                        {'_id': new mongo.ObjectId(data.troubleTicketId),'state': {$ne: 'solved'}},
                        {$set: {'state':'waiting'}},
                        (err1, res1) =>
                        {

                            if(res1 !== null && res1.matchedCount < 1)
                                return callback('Failed to update trouble to waiting, probably is solved already', null);
                            else if(err1 === null)
                                return callback(null, res);
                            else
                                return callback('Failed to update trouble ticket to waiting', null);
                        }
                    );
            }
        );
    },

    getSecondaryQuestionById: (data, callback) =>
    {
        _db.collection(secondaryTicketsCollection).findOne({'_id': new mongo.ObjectId(data.id)}, (err, res) =>
        {
            return callback(err, res);
        });
    },

    solveSecondaryQuestion: (data, callback) =>
    {
        _db.collection(secondaryTicketsCollection).updateOne(
            {'_id': new mongo.ObjectId(data.id)},
            {$set: {'answer':data.answer, 'state':'solved'}},
            (err, res) =>
            {
                if(err === null)
                    return callback(null, res);
                else
                    return callback('Failed to solve Secondary Question', null);
            }
        )
    },

    solveTroubleTicket: (data, callback) =>
    {

        _db.collection(secondaryTicketsCollection).find({'troubleTicketId':data.id}).toArray((err, docs) =>
        {
           if(err)
               return callback('Could not retrieve Secondary Tickets', null);
           else
               {
                   console.log(data.troubleTicketId);
                   docs.forEach((obj) =>
                   {
                       if(obj.state === 'waiting')
                           return callback('Some secondary tickets are not yet solved', null);
                   });

                   _db.collection(troubleTicketsCollection).updateOne(
                       {'_id': new mongo.ObjectId(data.id)},
                       {$set: {'answer': data.answer, 'state': 'solved'}},
                       (err, res) => {
                           if (err === null)
                               return callback(null, res);
                           else
                               return callback('Failed to solve Trouble Ticket', null);
                       }
               );
           }
        });
    }
};