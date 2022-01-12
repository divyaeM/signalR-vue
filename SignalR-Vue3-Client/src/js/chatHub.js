import { HubConnectionBuilder } from '@aspnet/signalr';

class ChatHub {

    connectionState = false;

    constructor() {
        this.client = new HubConnectionBuilder()
            .withUrl("https://localhost:44312/readmessage")
            .build();
    }

    start() {
        return this.client.start()
            .then(() => {
                console.log("Connection successfull");
                this.connectionState = true;
            })
            .catch(function(err) {
                return console.error(err.toString());
            });
    }

}

export default new ChatHub();