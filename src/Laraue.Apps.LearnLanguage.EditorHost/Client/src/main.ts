import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import qs from 'qs';
import { createVuestic } from "vuestic-ui";
import "vuestic-ui/css";

axios.defaults.baseURL = "http://localhost:5005/api"
axios.defaults.paramsSerializer = (params: any) => {
    return qs.stringify(params)
}

const app = createApp(App)
    .use(createVuestic({}))
    .use(router)

app.config.globalProperties.axios = axios
app.mount('#app')
