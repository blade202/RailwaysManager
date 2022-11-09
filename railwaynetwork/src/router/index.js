import { createRouter, createWebHistory } from 'vue-router'
import { Store } from 'vuex';
import store from '../vuex';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path:'/',
      name:'login',
      component: () => import('@/views/LoginView.vue')
    },
    {
      path:'/register',
      name:'register',
      component: () => import('@/views/RegisterView.vue')
    },
    {
      path:'/home',
      name:'home',
      component: () => import('@/views/HomeView.vue')
    },
    {
      path:'/admin',
      name : 'admin',
      component:() => import('@/views/AdminView.vue')
    }
   
 
  ]
})
router.beforeEach(async(to,from)=>{
  if(to.name==="home")
  {
    if(!store.state.user)
    {
      return '/'
    }
  }
  if(to.name==="login")
  {
    if(store.state.user)
    {
      return "/home"
    }
  }
  if(to.name==="admin")
  {
    if(store.state.user===null||store.state.user.role!=="admin")
    {
      return "/";
    }
  }
})

export default router
