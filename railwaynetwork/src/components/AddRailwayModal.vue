<template>
    <transition v-if="visible" name="modal-animation">
        <div class="modal">
            <transition name="modal-animation-inner">
                <div class="absolute z-50 p-6 -translate-x-1/2 -translate-y-1/2 modal-inner main-modal-container left-1/2 top-2/4">
                    <div
                        class="z-50 p-6 rounded-lg bg-darkgray font-mainfont">
                        <div class="modal-content">
                            <i @click="close()"
                                class='absolute right-0 px-3 text-3xl font-medium transition duration-200 ease-in-out cursor-pointer top-2 selection:p-1 bx bx-x-circle text-lightgray drop-shadow-md font-mainfont hover:text-red '></i>
                            <h1 class="p-2 text-2xl text-center border-b-4 font-600 border-dark/30 text-lightgray">
                                Hozzáadás</h1>
                            <h4 class="mt-2 mb-1 text-lg text-center text-lightgray">
                                Írja be a kívánt módosításokat!
                            </h4>
                            <div class="grid grid-cols-3 grid-rows-1 railway-creation-container">
                                <div class="col-start-1 col-end-2 depature-container">
                                    <h1></h1>
                                </div>
                                <div class="col-start-2 col-end-3 arrival-container">
                                    <h2></h2>
                                </div>
                                <div class="col-start-3 col-end-4 km-container">
                                    <h4></h4>
                                </div>
                            </div>
                            <div class="flex place-content-center">
                                <button
                                    class="p-1 px-5 mt-6 font-medium text-center transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray hover:font-semibold"
                                    @click="AddRailway(this.newcitiname)">Módosítás</button>
                            </div>
                        </div>
                    </div>
                    <div v-if="ShowError" class="z-50 p-6 mt-3 font-semibold text-center rounded-lg response-container bg-darkgray font-mainfont">
                        <h2 class="text-red" >
                            Sikertelen módosítás! <br>
                            Már létezik ilyen nevű város!</h2>
                    </div>
                    <div v-if="ShowSussces" class="z-50 p-6 mt-3 font-semibold text-center rounded-lg response-container bg-darkgray font-mainfont">                  
                        <h2 class="text-green" >Sikeres módosítás!</h2>
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
        visible:Boolean,
        close:Function,
        AddRailway:Function,
        ShowError:Boolean,
        ShowSussces:Boolean,
    },

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
