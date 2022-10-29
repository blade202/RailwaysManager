<template>
    <div class="font-mainfont" id="home">
        <div
            class="main-home-container bg-[url('/public/pictures/homebg.jpg')] bg-cover bg-darkgray w-full h-screen bg-fixed bg-no-repeat">
            <TheNavbar />
            <div class="absolute w-2/3 -translate-x-1/2 top-10 main-content-box left-1/2">
                <div
                    class="mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    RailwaysNetwork
                </div>
                <div class="grid w-1/2 grid-cols-3 grid-rows-1 m-auto text-center searchbar">
                    <select name="" id=""
                        class="p-2 font-medium text-center rounded-tl-full rounded-bl-full outline-none rounded- text-md bg-darkgray text-lightgray">
                        <option>Válasszon járataink közül!</option>
                        <option v-for="item in Cities">{{ item.cityName }}</option>
                    </select>
                    <select name="" id=""
                        class="p-2 font-medium text-center rounded-tr-full rounded-br-full outline-none text-md bg-darkgray text-lightgray">
                        <option>Válasszon járataink közül!</option>
                        <option v-for="item in Cities">{{ item.cityName }}</option>
                    </select>
                    <button class="cursor-pointer">
                        keresés
                    </button>
                </div>
                <div class="mt-5 table-box">
                    <table class="border-separate rounded-lg border-spacing-y-2 bg-transparent/40 backdrop-blur-sm pr-7 pl-7">
                        <tr class="font-medium rounded-lg bg-lightgray text-darkgray">
                            <th class="w-4/5 p-3 rounded-bl-xl">Állomások</th>
                            <th class="w-1/12">Távolság</th>
                            <th class="w-1/12">Ár</th>
                            <th class="w-1/6 p-3 rounded-br-xl">Foglalás</th>
                        </tr>
                        <tbody class=" bg-transparent/40 text-lightgray">
                            <tr>
                                <td class="w-4/5 p-2 text-center border-r-4 border-opacity-50 rounded-tl-full rounded-bl-full bg-darkgray border-lightgray outline-offset-10px">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. At ipsa veniam vel, ad
                                    fuga
                                    eos blanditiis. Veniam ut consectetur repudiandae aliquam non, saepe quae illo
                                    facilis
                                    nisi est aut neque.
                                </td>
                                <td class="w-1/12 text-center border-r-4 border-opacity-50 bg-darkgray border-lightgray">
                                    120
                                </td>
                                <td class="w-1/12 text-center border-r-4 border-opacity-50 bg-darkgray border-lightgray">
                                    5000
                                </td>
                                <td class="w-1/6 p-2 font-bold text-white rounded-tr-full rounded-br-full cursor-pointer font-sm bg-darkgray">
                                    Vásárlás
                                </td>
                            </tr>
                            <tr>
                                <td class="w-4/5 p-2 text-center rounded-tl-full rounded-bl-full bg-darkgray">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. At ipsa veniam vel, ad
                                    fuga
                                    eos blanditiis. Veniam ut consectetur repudiandae aliquam non, saepe quae illo
                                    facilis
                                    nisi est aut neque.
                                </td>
                                <td class="w-1/12 text-center bg-darkgray">
                                    120
                                </td>
                                <td class="w-1/12 text-center bg-darkgray">
                                    5000
                                </td>
                                <td class="w-1/6 font-bold text-white rounded-tr-full rounded-br-full font-sm bg-darkgray">
                                    Vásárlás
                                </td>
                            </tr>          
                            <tr>
                                <td class="w-4/5 p-2 text-center rounded-tl-full rounded-bl-full bg-darkgray">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. At ipsa veniam vel, ad
                                    fuga
                                    eos blanditiis. Veniam ut consectetur repudiandae aliquam non, saepe quae illo
                                    facilis
                                    nisi est aut neque.
                                </td>
                                <td class="w-1/12 text-center bg-darkgray">
                                    120
                                </td>
                                <td class="w-1/12 text-center bg-darkgray">
                                    5000
                                </td>
                                <td class="w-1/6 font-bold text-white rounded-tr-full rounded-br-full font-sm bg-darkgray">
                                    Vásárlás
                                </td>
                            </tr>                                
                        </tbody>
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
        TheNavbar, TheFooter,
    },
    computed: {
        ...mapGetters(['user'])
    },
    data() {
        return {
            Cities: null
        }
    },
    methods: {
        async getcities() {
            let response = await axios.get('/getCities');
            this.Cities = response.data;
            console.log(response.data)
        }
    },
    beforeMount() {
        this.getcities();
    }

}
</script>
