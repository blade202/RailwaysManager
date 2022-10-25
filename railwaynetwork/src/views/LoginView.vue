<template>
    <div id="login">
        <div class="main-login-container # w-full h-screen bg-[url('/public/pictures/loginregistrybg.jpg')] bg-left bg-fixed bg-no-repeat">
            <!-- Administration buttons-->
            <div class="registry-login-button-box # absolute p-1 grid grid-rows-1 grid-cols-2 xl:top-5 xl:right-5 xl:translate-x-0 xl:translate-y-0 lg:top-5 lg:right-5 lg:translate-x-0 lg:translate-y-0  md:right-1/2 md:top-2/3 md:translate-x-1/2  sm:right-1/2 sm:top-2/3 sm:translate-x-1/2 sm:translate-y-1/2  xs:right-1/2 xs:top-2/3 xs:translate-x-1/2 xs:translate-y-1/2">
                <button
                    class="p-2 mr-3 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
                    <router-link to="/register">Regisztráció</router-link>
                </button>
                <button
                    class="p-2 mr-3 font-medium transition duration-200 ease-in-out border-2 rounded-md bg-lightgray text-darkgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-transparent hover:border-solid border-lightgray hover:text-lightgray">
                    <router-link to="/login">Bejelentkezés</router-link>
                </button>
            </div>
            <div
                class="main-login-content # p-4 fixed top-1/3 left-1/2 -translate-y-1/2 -translate-x-1/2 font-mainfont grid lg:w-2/5 md:w-2/3 sm:w-full xs:w-full">
                <!--Title-->
                <h1 id="title"
                    class="mb-5 text-4xl font-medium text-center text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    <router-link to="/login">RailwaysNetwork</router-link>

                </h1>
                <!-- logincontent -->
                <div
                    class="login-content # backdrop-blur-sm bg-gray-600 bg-transparent/60 pt-16 pb-16 rounded-3xl grid lg:grid-rows-1 lg:grid-cols-1 lg:w">
                    <form @submit.prevent="login" class="text-center login-form">
                        <input v-model="username"
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray text-lightgray"
                            type="text" placeholder="Felhasználónév">

                        <input v-model="password"
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray mt-7 text-lightgray mb-7"
                            type="password" placeholder="Jelszó">

                        <input type="submit" class="w-2/6 p-2 mt-6 text-xl text-center cursor-pointer bg-lightgray rounded-xl text-darkgray">
                    </form>
                    <p class="mt-10 text-center text-lightgray text-md">
                        Nincs még fiókja?
                    </p>
                    <button class="grid p-2 m-auto mt-1 transition duration-300 ease-in-out border-2 border-solid lg:text-xl md-text-xlw-2/6 border-lightgray rounded-xl text-lightgray hover:bg-lightgray hover:text-darkgray">
                       <router-link to="/registry">Hozza létre most!</router-link>
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
    async login(){
        try{
        let response=await axios.post('/Login',{
            username:this.username,
            password:this.password
            
        })
        this.$store.dispatch('user', response.data);
        console.log(this.$store.user);
        router.push('/home')
    }catch{
        console.log("hibaás felhasználonév vagy jelszó")
    }
         
        }

    

}
}
</script>

