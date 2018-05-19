const amqp = require('amqplib/callback_api');
const mongo = require('../models/db');
const amqpURL = 'amqp://localhost';
const receiveQueue = 'guiQueue';
const sendQueue = 'nodeQueue';
let channel;

module.exports =
{
    connect: (callback) =>
    {
        amqp.connect(amqpURL, (err1, conn) =>
        {
            conn.createChannel((err2, createdChannel) =>
            {
                channel = createdChannel;
                channel.assertQueue(receiveQueue, {durable:false});
                channel.consume(receiveQueue, receive, {noAck:true});
                channel.assertQueue(sendQueue, {durable:false});
                callback(err1, conn);
            });
        });
    },



    send: (msg, callback) =>
    {
        channel.sendToQueue(sendQueue, Buffer.from(msg));
        callback(null, 'Message Sent');
    }
};

const receive =  (msg) =>
{
    console.log('Received %s', msg.content.toString());

    try
    {
        const secondaryQuestion = JSON.parse(msg.content.toString());

        const id = secondaryQuestion.id;
        const answer = secondaryQuestion.answer;

        if(id === undefined || answer === undefined || id === '' || answer === '')
            console.error('Invalid id or answer when trying to solve secondary question');
        else
            mongo.solveSecondaryQuestion(secondaryQuestion, (err, res) =>
            {
                if(err !== null) console.error(err);
            });
    }
    catch(e) {}
};