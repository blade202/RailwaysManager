<template>
    <TheNavbar />
    <div
        class="w-full main-admin-container h-screen bg-[url('/public/pictures/lowercontainerbg.png')] bg-cover bg-no-repeat">
        <div
            class="absolute -translate-x-1/2 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 left-1/2 admin-content-container xl:top-10 lg:top-20 md:top-20 sm:top-20">
            <div
                class="m-auto mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                RailwaysNetwork
            </div>
            <div
                class="flex w-full p-3 font-medium rounded-tl-lg rounded-tr-lg bg-darkgray navbar text-lightgray font-mainfont place-content-around">
                <div class="cities">
                    <button @click="showcities"
                        class="border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Városok
                    </button>
                </div>
                <div class="railways">
                    <button @click="showrailways"
                        class="border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Útvonalak
                    </button>
                </div>
            </div>
            <div id="admin-table" class="scrollbar-hide max-h-128">
                <table  v-if="tableheaders.length!==0"
                    class="w-full border-separate rounded-bl-lg rounded-br-lg px-7 border-spacing-y-4 bg-transparent/40 backdrop-blur-sm font-mainfont">
                    <tr class="sticky top-0 flex w-full p-3 font-medium rounded-lg place-content-around bg-lightgray text-darkgray">
                        <th v-for="header in tableheaders" class="">{{header}}</th>
                    </tr>
                    <tbody class="bg-transparent/40 text-lightgray">
                        <tr v-if="tableheaders[0]==='Városok'" class="">
                            <td class="p-2 text-center rounded-tl-full rounded-bl-full bg-darkgray h-14">
                                <div class="">
                                    Isazeg
                                </div>
                            </td>
                            <td class="text-center  bg-darkgray h-14">
                                <div class="">
                                    itt van a törelés gomb
                                </div>
                            </td>
                            <td class="text-center  bg-darkgray h-14">
                                <div class="">
                                    itt van a modositas gomb
                                </div>
                            </td>
                        </tr>
                        <tr  v-if="tableheaders[0]==='Induló állomás'">
                            <td>
                                idnulo
                            </td>
                            <td>
                                erkezo
                            </td>
                            <td>
                                km
                            </td>
                            <td>
                                modositas
                            </td>
                            <td>
                                törlés
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <TheFooter />
</template>

<script>
import TheFooter from '../components/TheFooter.vue';
import TheNavbar from '../components/TheNavbar.vue';
export default {
    name: "admin",
    components: {
        TheNavbar, TheFooter,
    },
    data() {
        return {
            tableheaders: [],
            cities: [],
            railways: [],
        }
    },
    methods: {
        showcities() {
            this.tableheaders = ["Városok", "Módosítás", "Törlés"]
        },
        showrailways() {
            this.tableheaders = ["Induló állomás", "Érkező állomás", "Km", "Módosítás", "Törlés"]
        }
    }

}
</script>