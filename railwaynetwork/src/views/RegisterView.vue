<template>
    <div id="register">
        <div
            class=" main-register-container # w-full h-screen bg-[url('/public/pictures/logintestbg.jpg')] bg-left bg-fixed bg-no-repeat">
            <div
                class=" grid-cols-1 grid-rows-7 main-register-content # p-4 fixed xl:top-1/3 lg:top-1/3 md:top-1/3 sm:top-1/2 top-1/2 w-full left-1/2 -translate-y-1/2 -translate-x-1/2 font-mainfont grid lg:w-2/5 md:w-2/3 sm:w-full">
                <!--Title-->
                <h1 id="title" class="row-start-1 row-end-2 mb-4 text-4xl font-medium text-center text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    <RouterLink to="/">RailwaysNetwork</RouterLink>
                </h1>
                <!-- register content -->
                <div class="register-content # row-start-2 row-end-6 backdrop-blur-sm bg-gray-600 flex flex-col bg-transparent/60 py-16 rounded-lg xl:text-xl lg:text-xl md:text-xl sm:text-base">
                    <form @submit.prevent='SubmitHandle' class="text-center registry-form">
                        <input v-model="Username"
                            class="w-4/5 p-2 m-auto text-center rounded-lg outline-none bg-darkgray text-lightgray"
                            type="text" placeholder="Felhasználónév" required>

                        <input v-model="Password"
                            class="w-4/5 p-2 m-auto text-center rounded-lg outline-none bg-darkgray mt-7 text-lightgray"
                            type="Password" placeholder="Jelszó" required>

                        <input v-model="PasswordConfirm"
                            class="w-4/5 p-2 m-auto text-center rounded-lg outline-none bg-darkgray mt-7 text-lightgray mb-7"
                            type="Password" placeholder="Jelszó megerősítése" required>

                        <input type="submit" class="w-2/6 p-2 mt-6 text-center rounded-lg bg-lightgray text-darkgray ">
                    </form>
                </div>
                <!-- response container -->
                <div class="absolute grid w-11/12 row-start-6 row-end-7 mt-6 text-center -translate-x-1/2 -translate-y-1/2 rounded-lg left-1/2 response-container bg-transparent/60">
                    <h2 v-if="MsgVisibility"
                        class="text-2xl font-medium duration-100 ease-in-out text-lightgray">
                        {{ Msg }}
                    </h2>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import router from '../router';
import axios from 'axios'
export default {
    name: "register",
    data() {
        return {
            Username: '',
            PasswordConfirm: '',
            Password: '',
            Msg: '',
            MsgVisibility: false
        };
    },
    methods: {
        async SubmitHandle() {
            this.Msg = "A jelszavaknak egyezniük kell!"
            if (this.Password === this.PasswordConfirm) {
                const response = await axios.post('/SiginUp', {
                    Username: this.Username,
                    PasswordConfrim: this.PasswordConfirm,
                    Password: this.Password
                });
                this.Msg = response.data;
            }
            this.MsgVisibility = true;
            setTimeout(() => {
                this.MsgVisibility = false;
                if (this.Msg === "Sikeres regisztráció!") {
                    router.push('/');
                };
            }, 2500);
        }
    }
}
</script>