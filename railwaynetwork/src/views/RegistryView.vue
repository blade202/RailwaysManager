<template>
    <div id="registry">
        <div class="main-registry-container # w-full h-screen bg-[url('/public/pictures/loginregistrybg.jpg')] bg-left">
            <!-- Administration buttons-->
            <div class="registry-login-button-box # absolute p-1 grid grid-rows-1 grid-cols-2 xl:top-5 xl:right-5 xl:translate-x-0 xl:translate-y-0 lg:top-5 lg:right-5 lg:translate-x-0 lg:translate-y-0  md:right-1/2 md:top-2/3 md:translate-x-1/2  sm:right-1/2 sm:top-2/3 sm:translate-x-1/2 sm:translate-y-1/2  xs:right-1/2 xs:top-2/3 xs:translate-x-1/2 xs:translate-y-1/2">
                <button
                    class="p-2 mr-3 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
                    <RouterLink to="/registry">Regisztráció</RouterLink>
                </button>
                <button
                    class="p-2 mr-3 font-medium transition duration-200 ease-in-out border-2 rounded-md bg-lightgray text-darkgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-transparent hover:border-solid border-lightgray hover:text-lightgray">
                    <RouterLink to="/login">Bejelentkezés</RouterLink>
                </button>
            </div>
            <div
                class="main-registry-content # p-4 fixed top-1/3 left-1/2 -translate-y-1/2 -translate-x-1/2 font-mainfont grid lg:w-2/5 md:w-2/3 sm:w-full xs:w-full">
                <!--Title-->
                <h1
                    class="mb-5 text-4xl font-medium text-center text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    <RouterLink to="/login">RailwaysNetwork</RouterLink>
                </h1>
                <!-- registrycontent -->
                <div
                    class="registry-content # backdrop-blur-sm bg-gray-600 flex flex-col bg-transparent/60 pt-16 pb-16 rounded-3xl">
                    <form action="" class="text-center registry-form">
                        <input
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray text-lightgray"
                            type="text" placeholder="Felhasználónév">

                        <input
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray mt-7 text-lightgray"
                            type="password" placeholder="Jelszó">

                        <input
                            class="w-4/5 p-2 m-auto text-xl text-center outline-none rounded-3xl bg-darkgray mt-7 text-lightgray mb-7"
                            type="password" placeholder="Jelszó megerősítése">

                        <submit class="w-2/6 p-2 mt-6 text-xl text-center bg-lightgray rounded-xl text-darkgray">
                            <RouterLink to="/home">Bejelentkezés</RouterLink>
                        </submit>
                    </form>
                    <p class="mt-10 text-center text-lightgray text-md">
                        Nincs még fiókja?
                    </p>
                    <button
                        class="grid p-2 m-auto mt-1 transition duration-300 ease-in-out border-2 border-solid lg:text-xl md-text-xlw-2/6 border-lightgray rounded-xl text-lightgray hover:bg-lightgray hover:text-darkgray">
                        <RouterLink to="/registry">Hozzon létre egyet most!</RouterLink>
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>