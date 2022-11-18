<template>
    <nav class="fixed top-0 grid w-full grid-cols-4 grid-rows-1 p-1 text-sm bg-transparent xl:p-5 lg:p-5 md:p-5 sm:p-5 xl:grid-cols-11 lg:grid-cols-8 md:grid-cols-8 sm:grid-cols-4 font-mainfont xl:text-base lg:text-base md:text-sm sm:text-base">
        <h2 class="grid items-center col-start-1 col-end-2 font-bold text-center border-2 rounded-md xl:col-end-2 xl:col-start-1 lg:col-end-2 lg:col-start-1 md:col-end-2 md:col-start-1 sm:col-end-2 sm:col-start-1 justify-items-center drop-shadow-md font-mainfont bg-lightgray text-darkgray border-lightgray" v-if="user">{{user.username}}
        </h2>  
        <RouterLink v-if="user&&user.role==='admin'" class="z-40 grid items-center col-start-2 col-end-3 ml-2 font-bold text-center transition duration-200 ease-in-out rounded-md xl:col-start-2 xl:col-end-3 lg:col-start-2 lg:col-end-3 md:col-start-2 md:col-end-3 sm:col-start-2 sm:col-end-3 justify-items-center drop-shadow-md font-mainfont bg-lightgray text-darkgray hover:bg-light hover:text-lightgray hover:bg-darkgray"  to="/admin">Admin</RouterLink>
        <button @click="Logout"
            class="z-30 col-start-4 col-end-5 p-1 px-1 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md xl:col-start-11 xl:col-end-12 lg:col-start-8 lg:col-end-9 md:col-start-8 md:col-end-9 border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
           <h1 class="z-30">Kijelentkezés</h1>
        </button> 
    </nav>
</template>
<script>

import { mapGetters } from 'vuex';
import router from '../router';

    export default{
        computed:{
            ...mapGetters(['user'])
        },
        methods:{
            Logout()
            {
                this.$store.dispatch('user', null);
                router.push('/');
            }
        }
        

        
    }
</script>