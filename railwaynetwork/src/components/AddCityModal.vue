<template>
    <transition v-if="visible" name="modal-animation">
        <div class="modal">
            <transition name="modal-animation-inner">
                <div class="modal-inner">
                    <div
                        class="absolute z-50 p-6 -translate-x-1/2 -translate-y-1/2 rounded-lg bakcdrop-filter-none main-modal-container left-1/2 top-2/4 bg-darkgray font-mainfont ">
                        <div class="modal-content">
                            <i @click="close()"
                                class='absolute right-0 px-3 text-3xl font-medium transition duration-200 ease-in-out cursor-pointer top-2 selection:p-1 bx bx-x-circle text-lightgray drop-shadow-md font-mainfont hover:text-red '></i>
                            <h1 class="p-2 text-2xl text-center border-b-4 font-600 border-dark/30 text-lightgray">
                                Hozzáadás</h1>
                            <h4 class="mt-2 mb-1 text-lg text-center text-lightgray">
                                Írja be az új város nevét!
                            </h4>
                            <input v-model="newcitiname" class="w-full p-2 font-semibold rounded-lg outline-none bg-dark/60 text-lightgray">
                            <h5 class="mt-0.5 mb-1 text-sm text-center text-lightgray">Később is módosíthatja a már
                                hozzáadott városokat!.</h5>
                            <div class="flex delete place-content-center">
                                <button
                                    class="p-1 px-5 mt-6 font-medium text-center transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray hover:font-semibold"
                                    @click="AddCity(this.newcitiname)">Hozzáadás</button>
                            </div>
                            <h2 class="text-red" v-if="ShowError">Már van ilyen nevű Város</h2>
                            <h2 class="text-green" v-if="ShowSussces">A Város Sikeresen hozzáadva!!</h2>
                        </div>
                    </div>
                </div>
            </transition>
        </div>
    </transition>
</template>
<script>
import axios from 'axios';

export default{
    data(){
        return{
            newcitiname:"",
        }
    },    
    props: {
        visible:Boolean,
        close:Function,
        AddCity:Function,
        ShowError:Boolean,
        ShowSussces:Boolean,
    },

}

</script>
<style lang="scss" scoped>
.modal-animation-enter-active,
.modal-animation-leave-active {
    transition: opacity 0.2s cubic-bezier(0.52, 0.02, 0.19, 1.02);
}

.modal-animation-enter-from,
.modal-animation-leave-to {
    opacity: 0;
}

.modal-animation-inner-enter-active {
    transition: opacity all 0.2s cubic-bezier(0.52, 0.02, 0.19, 1.02) 0.15s;
}

.modal-animation-inner-leave-active {
    transition: opacity all 0.2s cubic-bezier(0.52, 0.02, 0.19, 1.02);
}

.modal-animation-inner-enter-from {
    opacity: 0;
    transform: scale(0.8);
}

.modal-animation-inner-leave-to {
    transform: scale(0.8);
}
</style>
