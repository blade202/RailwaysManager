<template>
    <transition v-if="Visible" name="modal-animation">
        <div class="modal">
            <transition name="modal-animation-inner">
                <div class="absolute z-50 w-11/12 p-6 -translate-x-1/2 -translate-y-1/2 modal-inner main-modal-container left-1/2 top-2/4 xl:w-1/4 lg:w-2/6 md:w-1/2 sm:w-3/4">
                    <div
                        class="z-50 p-6 rounded-lg bg-darkgray font-mainfont">
                        <div class="modal-content">
                            <i @click="Close()"
                                class='absolute right-0 px-3 text-3xl font-medium transition duration-200 ease-in-out cursor-pointer top-2 selection:p-1 bx bx-x-circle text-lightgray drop-shadow-md font-mainfont hover:text-red '></i>
                            <h1 class="p-2 text-2xl text-center border-b-4 font-600 border-dark/30 text-lightgray">
                                Hozzáadás</h1>
                            <h4 class="mt-2 mb-1 text-lg text-center text-lightgray">
                                Írja be az új város nevét!
                            </h4>
                            <input v-model="newcitiname"
                                class="w-full p-2 font-semibold text-center rounded-lg outline-none bg-dark/60 text-darkeryellow">
                            <h5 class="mt-0.5 mb-1 text-sm text-center text-darkeryellow">Később is módosíthatja a már
                                hozzáadott adatokat.</h5>
                            <div class="flex delete place-content-center">
                                <button
                                    class="p-1 px-5 mt-6 font-medium text-center transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray hover:font-semibold"
                                    @click="AddCity(this.newcitiname)">Hozzáadás</button>
                            </div>
                        </div>
                    </div>
                    <div v-if="ShowError" class="z-50 p-6 mt-3 font-semibold text-center rounded-lg response-container bg-darkgray font-mainfont">
                        <h2 class="text-red" >
                            Sikertelen hozzáadás! <br>
                            Már létezik ilyen nevű város!</h2>
                    </div>
                    <div v-if="ShowSuccess" class="z-50 p-6 mt-3 font-semibold text-center rounded-lg response-container bg-darkgray font-mainfont">                  
                        <h2 class="text-green" >Sikeres hozzáadás!</h2>
                    </div>
                </div>
            </transition>
        </div>
    </transition>
</template>
<script>
import axios from 'axios';

export default {
    data() {
        return {
            newcitiname: "",
        }
    },
    props: {
        Visible: Boolean,
        Close: Function,
        AddCity: Function,
        ShowError: Boolean,
        ShowSuccess: Boolean,
    },
    watch:{
        Visible:function(){
            console.log("csináld")
        }
    }

}
</script>
<style lang="scss" scoped>
.modal-animation-enter-active,
.modal-animation-leave-active {
    transition: opacity 0.2 ease-in-out;
}
.modal-animation-enter-from,
.modal-animation-leave-to {
    opacity: 0;
}

</style>
