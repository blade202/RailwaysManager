<template>
    <transition v-if="Visible" name="modal-animation">
        <div class="modal">
            <transition name="modal-animation-inner">
                <div
                    class="absolute z-50 w-full p-6 -translate-x-1/2 -translate-y-1/2 modal-inner main-modal-container left-1/2 top-2/4 xl:w-1/2 lg:w-8/12 md:w-3/4 sm:w-8/12">
                    <div class="z-50 p-6 rounded-lg bg-darkgray font-mainfont">
                        <div class="modal-content">
                            <i @click="Close()"
                                class='absolute right-0 px-3 text-3xl font-medium transition duration-200 ease-in-out cursor-pointer top-2 selection:p-1 bx bx-x-circle text-lightgray drop-shadow-md font-mainfont hover:text-red '></i>
                            <h1 class="p-2 text-2xl text-center border-b-4 font-600 border-dark/30 text-lightgray">
                                Módosítás</h1>
                            <h4 class="mt-2 mb-5 text-lg text-center text-lightgray">
                                Írja be a kívánt módosításokat!
                            </h4>
                            
                            <div class="grid grid-cols-1 grid-rows-3 xl:grid-cols-3 xl:grid-rows-1 lg:grid-cols-3 lg:grid-rows-1 md:grid-cols-3 md:grid-rows-1 sm:grid-cols-1 sm:grid-rows-3 Railway-update-container">
                                <div class="col-start-1 col-end-2 row-start-1 row-end-2 mb-2 text-center xl:col-start-1 xl:col-end-2 xl:row-start-1 xl:row-end-2 lg:col-start-1 lg:col-end-2 lg:row-start-1 lg:row-end-2 md:col-start-1 md:col-end-2 md:row-start-1 md:row-end-2 sm:col-start-1 sm:col-end-2 sm:row-start-1 sm:row-end-2 depature-container">
                                    <h2 class="font-medium text-left text-lightgray">Induló állomás</h2>
                                    <select v-model="Railway.DepatureID" class="w-11/12 p-2.5 font-semibold text-center rounded-lg outline-none bg-dark/60 text-lightgray" name="" id="">
                                        <option  class="cursor-pointer bg-darkgray text-lightgray" value="">Induló állomás</option>
                                        <option class="cursor-pointer bg-darkgray text-lightgray" v-for="item in Cities" :value="item.id">{{ item.cityName }} </option>
                                    </select>
                                </div>
                                <div class="col-start-1 col-end-2 row-start-2 row-end-3 mb-2 text-center arrival-container xl:col-start-2 xl:col-end-3 xl:row-start-1 xl:row-end-2 lg:col-start-2 lg:col-end-3 lg:row-start-1 lg:row-end-2 md:col-start-2 md:col-end-3 md:row-start-1 md:row-end-2 sm:col-start-1 sm:col-end-2 sm:row-start-2 sm:row-end-3">
                                    <h2 class="font-medium text-left text-lightgray">Érkező állomás</h2>
                                    <select v-model="Railway.ArrivalID" class="w-11/12 p-2.5 font-semibold text-center rounded-lg outline-none bg-dark/60 text-lightgray" name="" id="">
                                        <option class="cursor-pointer bg-darkgray text-lightgray" value="">Érkező állomás</option>
                                        <option class="cursor-pointer bg-darkgray text-lightgray" v-for="item in Cities" :value="item.id">{{ item.cityName }}</option>
                                    </select>
                                </div>
                                <div class="col-start-1 row-start-3 row-end-4 mb-2 text-center selection:col-end-2 Km-container xl:col-start-3 xl:col-end-4 xl:row-start-1 xl:row-end-2 lg:col-start-3 lg:col-end-4 lg:row-start-1 lg:row-end-2 md:col-start-3 md:col-end-4 md:row-start-1 md:row-end-2 sm:col-start-1 sm:col-end-2 sm:row-start-3 sm:row-end-4">
                                    <h2 class="font-medium text-left text-lightgray">Távolság</h2>
                                    <div class="flex flex-col items-center xl:flex-row lg:flex-row md:flex-row sm:flex-col Km-container-content">
                                        <input v-model="Railway.Km"
                                            class="w-11/12 p-2 font-semibold text-center rounded-lg outline-none bg-dark/60 text-darkeryellow"
                                            type="text ">
                                        <h2 class="pl-1 first-line:font-semibold text-lightgray"> Km.</h2>
                                    </div>
                                </div>
                                
                            </div>
                            <h2 class="mt-3 text-sm text-center text-darkeryellow">
                                Később megváltoztathatja a korábban hozzáadott járatokat és részleteit is.
                            </h2>
                            <div class="flex place-content-center">
                                <button
                                    class="p-1 px-5 mt-6 font-medium text-center transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray hover:font-semibold"
                                    @click="Update(this.Railway)">Módosítás</button>
                            </div>
                        </div>
                    </div>
                    <div v-if="ShowError"
                        class="z-50 p-6 mt-3 font-semibold text-center rounded-lg response-container bg-darkgray font-mainfont">
                        <h2 class="text-red">
                            Sikertelen módosítás! <br>
                            Már létezik ilyen útvonal!</h2>
                    </div>
                    <div v-if="ShowSuccess"
                        class="z-50 p-6 mt-3 font-semibold text-center rounded-lg response-container bg-darkgray font-mainfont">
                        <h2 class="text-green">Sikeres módosítás!</h2>
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
            Railway:{
            DepatureID: 0,
            ArrivalID: 0,
            Km:0   
            }
           
        }
    },
    props: {
        Visible: Boolean,
        Close: Function,
        Update: Function,
        ShowError: Boolean,
        ShowSuccess: Boolean,
        Cities:Array
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
