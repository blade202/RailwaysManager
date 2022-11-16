<template>
    <div
        class="w-full main-admin-container h-screen bg-[url('/public/pictures/lowercontainerbg.png')] bg-cover bg-no-repeat  ">
        <TheNavbar />
        <div
            class="absolute w-full h-screen -translate-x-1/2 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 left-1/2 admin-content-container xl:top-10 lg:top-20 md:top-20 sm:top-20 ">
            <div
                class="m-auto mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                <router-link to="/home">RailwaysNetwork</router-link>
            </div>
            <div
                class="flex w-full p-3 font-medium border-b-4 rounded-tl-lg rounded-tr-lg bg-darkgray navbar border-lightgray text-lightgray font-mainfont place-content-around">
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
            <div id="admin-table" class="w-full overflow-scroll table-box scrollbar-hide font-mainfont max-h-128">
                <table v-if="tableheaders.length !== 0"
                    class="w-full border-separate rounded-bl-lg rounded-br-lg px-7 border-spacing-y-4 bg-transparent/40 backdrop-blur-sm font-mainfont">
                    <tr class="sticky top-0 w-full font-medium bg-lightgray text-darkgray">
                        <th v-for="header in tableheaders" class="p-3 rounded-bl-xl rounded-br-xl">{{ header }}</th>
                    </tr>
                    <tbody class="bg-transparent/40 text-lightgray">
                        <tr v-if="tableheaders[0] === 'Városok'" v-for="city in cities" class="">
                            <td class="w-3/5 p-2 text-center rounded-tl-full rounded-bl-full bg-darkgray h-14 ">
                                <div class="border-r-4 xl:border-lightgray/70">
                                    {{ city.cityName }}
                                </div>
                            </td>
                            <td class="w-1/5 text-center bg-darkgray h-14 ">
                                <div class="border-r-4 xl:border-lightgray/70">
                                    <i
                                        class='inline-block text-2xl duration-150 ease-in-out cursor-pointer text-silver bx bxs-cog ransition hover:text-darkersilver'></i>
                                </div>
                            </td>
                            <td class="w-1/5 text-center rounded-tr-full rounded-br-full bg-darkgray h-14">
                                <div class="">
                                    <i @click="toggleModal(); setDeleteID(city.id)"
                                        class='text-3xl duration-150 ease-in-out cursor-pointer text-red bx bxs-trash hover:text-darkerred'></i>
                                </div>
                            </td>
                        </tr>
                        <tr v-if="tableheaders[0] === 'Induló állomás'" v-for="railway in railways">
                            <td class="p-2 text-lg text-center rounded-tl-full rounded-bl-full bg-darkgray h-14">
                                <div
                                    class="border-r-4 border-lightgray/70 xl:text-base lg:text-base md:text-sm sm:text-sm">
                                    {{ railway.depatureCity }}</div>
                            </td>
                            <td class="text-lg text-center bg-darkgray h-14">
                                <div
                                    class="border-r-4 border-lightgray/70 xl:text-base lg:text-base md:text-sm sm:text-sm xs:text-sm">
                                    {{ railway.arivalCity }}
                                </div>
                            </td>
                            <td class="text-lg text-center xl:w-1/12 lg:w-1/12 md:w-2/12 sm:w-1/12 bg-darkgray h-14">
                                <div
                                    class="px-3 border-r-4 border-lightgray/70 xl:text-base lg:text-base md:text-sm sm:text-sm">
                                    {{ railway.km }} km
                                </div>
                            </td>
                            <td class="text-center xl:w-2/12 lg:w-2/12 md:w-1/12 sm:w-1/12 bg-darkgray h-14">
                                <div class="border-r-4 border-lightgray/70">
                                    <i
                                        class='text-2xl duration-150 ease-in-out cursor-pointer text-silver bx bxs-cog hover:text-darkersilver'></i>
                                </div>
                            </td>

                            <td
                                class="text-center rounded-tr-full rounded-br-full xl:w-2/12 lg:w-2/12 md:w-2/12 sm:w-1/12 bg-darkgray h-14">
                                <div class="">
                                    <i
                                        class='text-3xl duration-150 ease-in-out cursor-pointer text-red hover:text-darkerred bx bxs-trash '></i>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <Modal @closeDeleteModal="toggleModal" :modalActive="modalActive"
            class="absolute z-50 p-6 -translate-x-1/2 -translate-y-1/2 rounded-lg bakcdrop-filter-none main-modal-container left-1/2 top-2/4 bg-darkgray font-mainfont ">
            <div class="modal-content">
                <h1 class="p-2 text-2xl text-center border-b-4 font-600 border-dark/30 text-lightgray">Megerősítés</h1>
                <h4 class="mt-2 mb-2 text-lg text-center text-lightgray">Biztos benne, hogy törölni szeretné a járatot?
                </h4>
                <h5 class="mt-1 mb-1 text-sm text-center text-lightgray">Ha törli a járatot többet nem tudja
                    visszaállítani.</h5>
                <div class="delete-options">
                   
                     
                </div>
            </div>
        </Modal>
        <TheFooter />
    </div>
    <div v-if="modalActive" id="blur-overlay" class="absolute top-0 z-30 w-full h-screen backdrop-blur-md bg-dark/30">
    </div>
</template>

<script>
import axios from 'axios';
import { VueElement } from 'vue';
import TheFooter from '../components/TheFooter.vue';
import TheNavbar from '../components/TheNavbar.vue';
import Modal from '../components/Modal.vue'
import { ref } from 'vue';

export default {
    name: "admin",
    components: {
        TheNavbar, TheFooter, Modal
    },
    setup() {
        const modalActive = ref(false);

        const toggleModal = () => {
            modalActive.value = !modalActive.value;
        };
        return { toggleModal, modalActive }
    },
    data() {
        return {
            tableheaders: [],
            cities: [],
            railways: [],
            deleteID:null
        }
    },
    methods: {
        async showcities() {
            this.tableheaders = ["Városok", "Módosítás", "Törlés"];
            let response = await axios.get('/getCities');
            this.cities = response.data;
        },
        async showrailways() {
            this.tableheaders = ["Induló állomás", "Érkező állomás", "Km", "Módosítás", "Törlés"];
            let response = await axios.get('/GetRailways');
            this.railways = response.data;

        },
        async DeletCities() {
            let cityid=this.deleteID;
            try {
                await axios.post('/DeletCity', {
                    id: cityid,
                });
                const objWithIdIndex = this.cities.findIndex((obj) => obj.id === cityid);
                this.cities.splice(objWithIdIndex, 1);

            } catch {

            }
        },
        setDeleteID(id) {
            this.deleteID=id;
        }
    

    }
}


</script>