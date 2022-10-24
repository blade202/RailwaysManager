<template>
    <div id="home">
        <TheNavbar />
        <div
            class="main-home-container bg-[url('/public/pictures/homebg.jpg')] brightness-90 bg-cover bg-darkgray w-full h-screen bg-fixed bg-no-repeat">
            <div class="fixed w-2/3 -translate-x-1/2 translate-y-1/2 main-content-box top-1/6 left-1/2">
                <div
                    class="mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    RailwaysNetwork
                </div>
                <div class="w-full grid-cols-2 grid-rows-1 m-auto text-center searchbar">
                    <input class="w-1/3 p-2 font-medium text-center border-4 rounded-tl-full rounded-bl-full outline-none border-r-dark/75 text-md bg-darkgray text-lightgray" type="text" placeholder="Induló állomás">
                    <input class="w-1/3 p-2 font-medium text-center rounded-tr-full rounded-br-full outline-none text-md bg-darkgray text-lightgray" type="text" placeholder="Érekző állomás">
                </div>
                <div class="table-box">
                    <table>
                        <tr>
                            <th>Állomások</th>
                            <th>Távolság</th>
                            <th>Ár</th>
                            <th>Vásárlás</th>
                        </tr>
                        <tr>
                            <td>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. At ipsa veniam vel, ad fuga
                                eos blanditiis. Veniam ut consectetur repudiandae aliquam non, saepe quae illo facilis
                                nisi est aut neque.
                            </td>   
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <TheFooter />
    </div>
</template>

<script>
import axios from 'axios';
import TheFooter from '../components/TheFooter.vue';
import TheNavbar from '../components/TheNavbar.vue';
import { mapGetters } from 'vuex';
import { computed } from '@vue/reactivity';

export default {
    name: "Home",
    components: {
        TheNavbar,TheFooter, 
    },
    computed: {
        ...mapGetters(['user'])
    }
}
</script>
