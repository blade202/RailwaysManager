<template>
    <div id="registry">
        <div class="main-registry-container # w-full h-screen bg-[url('/public/pictures/loginregistrybg.jpg')] bg-left">
            <div
                class="main-registry-content # p-4 fixed top-1/3 left-1/2 -translate-y-1/2 -translate-x-1/2 font-mainfont grid lg:w-2/5 md:w-2/3 sm:w-full xs:w-full">
                <!--Title-->
                <h1
                    class="mb-5 text-4xl font-medium text-center text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    <RouterLink to="/login">RailwaysNetwork</RouterLink>
                </h1>
                <h2 v-if="msgvisibility" class="mb-5 text-4xl font-medium text-center text-lightgray text-shadow-xl font-mainfont inner-shadow">
                   {{msg}}
                </h2>
                <!-- registrycontent -->
                <div
                    class="registry-content # backdrop-blur-sm bg-gray-600 flex flex-col bg-transparent/60 pt-16 pb-16 rounded-3xl">
                    <form @submit.prevent='submithandle' class="text-center registry-form">
                        <input v-model="username"
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray text-lightgray"
                            type="text" placeholder="Felhasználónév" required>

                        <input v-model="password"
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray mt-7 text-lightgray"
                            type="password" placeholder="Email-cím" required>

                        <input v-model="passwordconfirm"
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray mt-7 text-lightgray mb-7"
                            type="password" placeholder="Jelszó" required>

                        <input type="submit" class="w-2/6 p-2 mt-6 text-xl text-center bg-lightgray rounded-xl text-darkgray ">
                      
                   
                    </form>                
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import router from '../router';
import axios from 'axios'
export default{
        name:"registry",
        data(){
            return{
                username:'',
                passwordconfirm:'',
                password:'',
                msg:'',
                msgvisibility:false
            };
        },
        methods:{
           async submithandle(){
            this.msg="A jelszavaknak egyezni kéne!"   
            if(this.password===this.passwordconfirm)
            {  
            const response= await axios.post('/SiginUp',{
                    Username:this.username,
                    PasswordConfrim:this.passwordconfirm,
                    Password:this.password
                });
                this.msg=response.data;
            }
            this.msgvisibility=true;
            }
        }
    }
</script>