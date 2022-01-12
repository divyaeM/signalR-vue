import { createApp } from 'vue'
import App from './App.vue'
import chatHubPlugin from './js/chatHubPlugin.js';


createApp(App).use(chatHubPlugin).mount('#app')