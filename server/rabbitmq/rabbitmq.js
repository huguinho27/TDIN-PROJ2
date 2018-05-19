const amqp = require('amqplib/callback_api');
const amqpURL = 'amqp://localhost';
const receiveQueue = 'guiQueue';
const sendQueue = 'nodeQueue';
let channel;

module.exports =
{
    receive: (msg) =>
    {
        //receive callback
        console.log('Received %s', msg.content.toString());

        //TODO: criar os metodos aqui para fazer as cenas quando recebo
    },

    connect: (callback) =>
    {
        amqp.connect(amqpURL, (err1, conn) =>
        {
            conn.createChannel((err2, createdChannel) =>
            {
                channel = createdChannel;
                channel.assertQueue(receiveQueue, {durable:false});
                channel.consume(receiveQueue, (msg) =>
                {
                    console.log('Received %s', msg.content.toString());
                }, {noAck:true});
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