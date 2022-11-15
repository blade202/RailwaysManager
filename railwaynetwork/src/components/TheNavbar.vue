<template>
    <nav class="fixed top-0 grid w-full grid-rows-1 p-5 bg-transparent xl:grid-cols-11 lg:grid-cols-8 md:grid-cols-8 sm:5 xs:grid-cols-4 font-mainfont">
        <h2 class="grid col-span-1 font-bold text-center border-2 rounded-md before:col-start-1 justify-items-center drop-shadow-md font-mainfont bg-lightgray text-darkgray border-lightgray" v-if="user">{{user.username}}
        </h2>  
        <RouterLink v-if="user&&user.role==='admin'" class="z-40 grid ml-2 font-bold text-center transition duration-200 ease-in-out rounded-md before:col-start-1 justify-items-center first-letter:col-span-1 drop-shadow-md font-mainfont bg-lightgray text-darkgray hover:bg-light hover:text-lightgray hover:bg-darkgray"  to="/admin">Admin</RouterLink>
        <button @click="Logout"
            class="z-30 col-span-1 col-start-11 p-1 px-1 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
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