import {Store} from 'vuex';
import axios from 'axios';
import createPersistedState from 'vuex-persistedstate';
import * as Cookies from 'js-cookie';



axios.defaults.baseURL='https://trainbackendapi20221125003319.azurewebsites.net/';
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
            if(user)
            {
                axios.defaults.headers.common['Authorization']='Bearer '+ user.token;
            }
           
        }
    },
    mutations: {
        user(state,user){
            state.user=user;
            if(user)
            {
                axios.defaults.headers.common['Authorization']='Bearer '+ user.token;
            }
        }
    },
    plugins: [
        createPersistedState()
      ]
});
if(store.state.user.token)
    {
        axios.defaults.headers.common['Authorization']='Bearer '+ store.state.user.token;
    }
      axios.interceptors.response.use(function (response) {
        return response;
      }, async function (error) {
        console.log(error);
        if(error.response.status===0){    
        let newtokens= await axios.post('RefreshToken',{
            oldtoken:store.state.user.token,
            refreshtoken:store.state.user.refreshtoken
        });
        let user=store.state.user;
        console.log(user)
        user.token=newtokens.data.token;
        user.refreshtoken=newtokens.data.refreshtoken;
        console.log(newtokens);
        error.config.headers['Authorization'] = 'Bearer ' + user.token;
        store.dispatch("user",user);
        console.log(store.state.user);  
        return axios(error.config);
    }
      
      return Promise.reject(error);
    });
    
     
export default store;
