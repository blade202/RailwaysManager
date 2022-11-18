<template>
    <div id="login">
        <div class="main-login-container # w-full h-screen bg-[url('/public/pictures/loginregistrybg.jpg')] bg-left bg-cover bg-fixed bg-no-repeat">
            <!-- Administration buttons-->
            <div
                class="main-login-content # p-4 fixed xl:top-1/3 lg:top-1/3 md:top-1/3 sm:top-1/2 top-1/2 w-full left-1/2 -translate-y-1/2 -translate-x-1/2 font-mainfont grid lg:w-2/5 md:w-2/3 sm:w-full ">
                <!--Title-->
                <h1 id="title"
                    class="mb-5 text-4xl font-medium text-center text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    <router-link to="/login">RailwaysNetwork</router-link>

                </h1>
                <!-- logincontent -->
                <div
                    class="login-content # backdrop-blur-sm bg-gray-600 bg-transparent/60 pt-16 pb-16 rounded-3xl grid lg:grid-rows-1 lg:grid-cols-1 xl:text-xl lg:text-xl md:text-xl sm:text-base">
                    <form @submit.prevent="login" class="text-center login-form">
                        <input v-model="username"
                            class="w-4/5 p-2 m-auto text-center outline-none rounded-3xl bg-darkgray text-lightgray"
                            type="text" placeholder="Felhasználónév">

                        <input v-model="password"
                            class="w-4/5 p-2 m-auto text-center outline-none rounded-3xl bg-darkgray mt-7 text-lightgray mb-7"
                            type="password" placeholder="Jelszó">

                        <input type="submit" class="w-2/6 p-2 mt-6 text-center cursor-pointer bg-lightgray rounded-xl text-darkgray ">
                    </form>
                    <p class="mt-10 text-center text-lightgray text-md">
                        Nincs még fiókja?
                    </p>
                    <button @click="GotoRegister" class="grid p-2 m-auto mt-1 transition duration-300 ease-in-out border-2 border-solid xl:w-2/6 lg:w-2-6 md:w-2/6 sm:w-2/4 border-lightgray rounded-xl text-lightgray hover:bg-lightgray hover:text-darkgray">
                    Hozza létre most!
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import router from '../router';

export default{
name:"login",
data(){
    return{
        username:'',
        password:'',
    };
},
methods:{
    GotoRegister(){
        router.push('/register')
    },
    async login(){
        try{
        let response=await axios.post('/Login',{
            username:this.username,
            password:this.password
        })
        console.log(response);
        this.$store.dispatch('user', response.data);
        router.push('/home');
    }
    catch{
        console.log("hibaás felhasználonév vagy jelszó")
    }
         
        }
}
}
</script>

