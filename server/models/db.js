const mongo = require('mongodb');
const mongoURL = "mongodb://localhost:27017/";
const mongoDB = "ttdb";
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
};