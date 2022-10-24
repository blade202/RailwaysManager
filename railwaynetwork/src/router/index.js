import { createRouter, createWebHistory } from 'vue-router'
import { Store } from 'vuex';
import store from '../vuex';
let user=store.state.user;

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
   
 
  ]


 
})
function canAccess(to)
{
  if(to.name==="home")
  {
    if(user)
    {
      return true;
    }
    return false
  }
  return true;
  
}
router.beforeEach(async(to,from)=>{
 if(!canAccess(to)) return '/'
})

export default router
