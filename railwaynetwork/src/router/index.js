import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path:'/login',
      name:'login',
      component: () => import('@/views/LoginView.vue')
    },
    {
      path:'/registry',
      name:'registry',
      component: () => import('@/views/RegistryView.vue')
    },
    {
      path:'/home',
      name:'home',
      component: () => import('@/views/HomeView.vue')
    }

 
  ]
})

export default router
