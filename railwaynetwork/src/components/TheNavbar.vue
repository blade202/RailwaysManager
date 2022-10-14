<template>
    <nav class="fixed top-0 grid w-full grid-rows-1 p-5 bg-transparent xxl:grid-cols-10 xl:grid-cols-11 lg:grid-cols-8 md:grid-cols-8 sm:5 xs:grid-cols-4">
        <h2 class="col-span-1 col-start-1 p-2 mr-3 font-medium text-center transition duration-200 ease-in-out border-2 border-solid rounded-md xl: border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
            api gyere rám
        </h2>
        <button 
            class="col-span-1 col-start-10 p-2 mr-3 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
            <router-link to="/register">Üdvözöljük,{{}}</router-link>
        </button>
        <button
            class="col-span-1 col-start-11 p-2 mr-3 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray">
            <router-link to="/register">Kijelentkezés</router-link>
        </button> 
    </nav>
</template>
<script>
    
</script>