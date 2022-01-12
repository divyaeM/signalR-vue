import ChatHub from "./chatHub";

export default {
    install: (app) => {
        app.config.globalProperties.$chatHub = ChatHub;
    }
}