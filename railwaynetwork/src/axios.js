import axios from 'axios'
import store from '../store'


let user=store.getters.user;

axios.defaults.baseURL='https://localhost:49153/';
axios.defaults.headers.common['Authorization']='Barer'+ user.token;
