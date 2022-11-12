
var notificationHub = $.connection.notificationHub;
console.log(notificationHub);

$.connection.hub.start().done(function () {
    console.log('connected to hubs');

    notificationHub.server.pickupRequestReceived()

    notificationHub.client.receiveSushantSir = function (msg) {
        console.log(msg);
    }
});







