import {Store} from 'vuex';
import axios from 'axios';
import createPersistedState from 'vuex-persistedstate';
import * as Cookies from 'js-cookie';



axios.defaults.baseURL='https://localhost:49155/';
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

      axios.interceptors.response.use(function (response) {
        // Any status code that lie within the range of 2xx cause this function to trigger
        // Do something with response data
        return response;
      }, async function (error) {
        // Any status codes that falls outside the range of 2xx cause this function to trigger
        // Do something with response error
        console.log(error);
      
        let newtokens= await axios.post('RefreshToken',{
            oldtoken:store.state.user.token,
            refreshtoken:store.state.user.refreshtoken
        });
        console.log("itt vagyok!!");
        let user=store.state.user;
        console.log(user)
        user.token=newtokens.data.token;
        user.refreshtoken=newtokens.data.refreshtoken;
        axios.defaults.headers.common['Authorization']='Bearer '+ user.token;
        console.log(newtokens);
        store.dispatch("user",user);
        console.log(store.state.user);  
        return axios.request(error.config);
      
      return Promise.reject(error);
    });
    
     
export default store;
