import {Store} from 'vuex';
import axios from 'axios';
import createPersistedState from 'vuex-persistedstate';
import * as Cookies from 'js-cookie';



axios.defaults.baseURL='https://localhost:7228/';
const state= {
    user:null
};


const store = new Store({
    
    state,
    getters: {
        user : (state)=>{   
            return state.user;    
        }
    },
    actions: {
        user(context, user){
            context.commit('user', user);
        }
    },
    mutations: {
        user(state,user){
            state.user=user;
        }
    },
    plugins: [
        createPersistedState()
      ]
});
if(store.state.user)
{
    axios.defaults.headers.common['Authorization']='Bearer '+ store.state.user.token;
}
export default store;
