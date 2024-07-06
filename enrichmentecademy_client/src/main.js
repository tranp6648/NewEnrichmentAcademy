

import { createApp } from 'vue'
import App from './App.vue';
import './assets/main.css'
import router from './components/router';
import 'bootstrap/dist/css/bootstrap.min.css'; 


import { VueSelect } from 'vue-select';

createApp(App).use(router).component("v-select", VueSelect).mount('#app')
