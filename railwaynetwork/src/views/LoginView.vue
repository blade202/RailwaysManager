<template>
    <div id="login">
        <div class="main-login-container # w-full h-screen bg-[url('/public/pictures/loginregistrybg.jpg')] bg-left">
            <!-- Administration buttons-->
            <div class="registry-login-button-box # absolute top-5 right-5 flex p-1">
                <button
                    class="border-solid border-2 border-lightgray p-2 rounded-md text-lightgray font-medium mr-3 drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                    <router-link to="/registry">Regisztráció</router-link>
                </button>
                <button
                    class=" bg-lightgray p-2 rounded-md text-darkgray font-medium mr-3 drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray transition duration-200 ease-in-out hover:bg-transparent hover:border-solid border-2 border-lightgray hover:text-lightgray">
                    <router-link to="/login">Bejelentkezés</router-link>
                </button>
            </div>
            <div
                class="main-login-content #  p-4 fixed top-1/3 left-1/2 -translate-y-1/2 -translate-x-1/2 font-mainfont">
                <!--Title-->
                <h1
                    class="text-4xl font-medium text-lightgray text-center mb-5 text-shadow-xl font-mainfont inner-shadow">
                    <router-link to="/login">RailwaysNetwork</router-link>

                </h1>
                <!-- logincontent -->
                <div
                    class="login-content # w-2/5 backdrop-blur-sm bg-gray-600 h-3/5 bg-transparent/60 pt-16 pb-16 rounded-3xl grid lg:grid-rows-1 lg:grid-cols-3 sm:grid-cols-1 sm:grid-rows-1">
                    <form action="" class="login-form text-center">
                        <input
                            class="outline-none text-xl text-center rounded-3xl bg-darkgray p-2 text-lightgray w-4/5 m-auto"
                            type="text" placeholder="Felhasználónév">

                        <input
                            class="outline-none text-xl text-center rounded-3xl bg-darkgray mt-7 p-2 text-lightgray w-4/5 m-auto mb-7"
                            type="password" placeholder="Jelszó">

                        <submit class="bg-lightgray w-2/6 p-2 mt-6 rounded-xl text-darkgray text-xl text-center">
                            <RouterLink to="/home">Bejelentkezés</RouterLink>
                        </submit>
                    </form>
                    <p class="text-center mt-10 text-lightgray text-md">
                        Nincs még fiókja?
                    </p>
                    <button
                        class="border-solid border-2 border-lightgray w-2/6 m-auto p-2 rounded-xl mt-1 text-lightgray text-xl hover:bg-lightgray hover:text-darkgray transition duration-300 ease-in-out">
                        <router-link to="/registry">Hozzon létre egyet most!</router-link>
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>
