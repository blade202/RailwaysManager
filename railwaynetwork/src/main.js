import { createApp, VueElement } from 'vue'
import App from './App.vue'
import router from './router'
import './vuex'
import store from './vuex'
import Vuex from 'vuex'




import './assets/main.css'
const app = createApp(App)

app.use(router)
app.use(store)
app.use(Vuex)


app.mount('#app')

