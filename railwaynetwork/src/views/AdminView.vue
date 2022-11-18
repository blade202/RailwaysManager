<template>
    <div id="admin"
        class="w-full main-admin-container h-screen bg-[url('/public/pictures/lowercontainerbg.png')] bg-cover bg-no-repeat  ">
        <TheNavbar />
        <div
            class="absolute w-full h-screen -translate-x-1/2 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 left-1/2 admin-content-container xl:top-10 lg:top-20 md:top-20 sm:top-20 ">
            <div
                class="m-auto mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                <router-link to="/home">RailwaysNetwork</router-link>
            </div>
            <div
                class="flex w-full p-3 font-medium rounded-tl-lg rounded-tr-lg bg-darkgray navbar text-lightgray font-mainfont place-content-around">
                <div class="flex cities flex-nowrap">
                    <button @click="showcities"
                        class="border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Városok
                    </button>
                    <i class='text-3xl bx bx-dots-horizontal-rounded'></i>
                    <button @click="ShowAddCityModal"
                        class="border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Hozzáadás
                    </button>
                </div>
                <div class="flex railways flex-nowrap">
                    <button @click="showrailways"
                        class="border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Útvonalak
                    </button>
                    <i class='text-3xl bx bx-dots-horizontal-rounded'></i>
                    <button @click="ShowAddRailwayModal"
                        class="border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Hozzáadás
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
                                    <i @click="setChangeIDAndOpenChangeModal(city.id)"
                                        class='inline-block text-2xl duration-150 ease-in-out cursor-pointer text-silver bx bxs-cog ransition hover:text-darkersilver'></i>
                                </div>
                            </td>
                            <td class="w-1/5 text-center rounded-tr-full rounded-br-full bg-darkgray h-14">
                                <div class="">
                                    <i @click="setDeleteIDAndOpenDeleteModal(city.id)"
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
                                    <i @click="SetRailwayIdAndOpenUpdateRailwayModal(railway.id)"
                                        class='text-2xl duration-150 ease-in-out cursor-pointer text-silver bx bxs-cog hover:text-darkersilver'></i>
                                </div>
                            </td>

                            <td
                                class="text-center rounded-tr-full rounded-br-full xl:w-2/12 lg:w-2/12 md:w-2/12 sm:w-1/12 bg-darkgray h-14">
                                <div class="">
                                    <i @click="SetRailwayIdAndOpenRailwayDeleteModal(railway.id)"
                                        class='text-3xl duration-150 ease-in-out cursor-pointer text-red hover:text-darkerred bx bxs-trash '></i>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <ChangeCityModal :visible=cityModalChangeVisibility :close=closeChangeModal :UpdateCiti=UpdateCity
            :ShowError=ShowError :ShowSussces=ShowSussces />
        <DeleteModal :visible=deleteModalVisibility :deleteCity=DeletCities :closemodal=CloseDeleteModal />
        <AddCityModal :visible=AddCityModalVisibility :close=CloseAddCityModal :AddCity=AddCity :ShowError=ShowError
            :ShowSussces=ShowSussces />
        <DeleteRailwayModal :visible=DeleteRailwayModalVisibility :close=CloseDeleRailwayModal
            :deleteRailway=DeleteRailway />
        <AddRailwayModal :visible=AddRailwayModalVisibility :ShowError=ShowError :ShowSussces=ShowSussces
            :close=CloseAddRailwayModal :AddRailway=CreateRailway />
        <UpdateRailwayModal :visible=UpdateRailwayModalVisibility :ShowError=ShowError :ShowSussces=ShowSussces
            :close=CLoseUpdateRailwayModal :UpdateRailwy=UpdateRailway />
        <TheFooter />
    </div>
    <div v-if="blurVisibility" id="blur-overlay"
        class="absolute top-0 z-30 w-full h-screen backdrop-blur-md bg-dark/30">

    </div>
</template>

<script>
import axios from 'axios';
import { VueElement } from 'vue';
import TheFooter from '../components/TheFooter.vue';
import TheNavbar from '../components/TheNavbar.vue';
import DeleteModal from '../components/DeleteModal.vue';
import AddCityModal from '../components/AddCityModal.vue';
import ChangeCityModal from '../components/ChangeCityModal.vue';
import DeleteRailwayModal from '../components/DeleteRailwayModal.vue';
import AddRailwayModal from '../components/AddRailwayModal.vue'
import UpdateRailwayModal from '../components/UpdateRailwayModal.vue'
import console from 'console';


export default {
    name: "admin",
    components: {
        TheNavbar, TheFooter, DeleteModal, ChangeCityModal, AddCityModal, DeleteRailwayModal, AddRailwayModal,UpdateRailwayModal
    },
    data() {
        return {
            tableheaders: [],
            cities: [],
            railways: [],
            CitiId: null,
            RailwayId: null,
            blurVisibility: false,
            deleteModalVisibility: false,
            cityModalChangeVisibility: false,
            AddCityModalVisibility: false,
            DeleteRailwayModalVisibility: false,
            AddRailwayModalVisibility: false,
            UpdateRailwayModalVisibility: false,
            ShowError: false,
            ShowSussces: false,
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
        setDeleteIDAndOpenDeleteModal(id) {
            this.CitiId = id;
            this.deleteModalVisibility = true;
            this.blurVisibility = true;
        },
        CloseDeleteModal() {
            this.deleteModalVisibility = false;
            this.blurVisibility = false;
        },
        async DeletCities() {
            axios.delete('/DeletCity', {
                data: {
                    id: this.CitiId
                }
            });
            const objWithIdIndex = this.cities.findIndex((obj) => obj.id === this.CitiId);
            this.cities.splice(objWithIdIndex, 1);
            this.deleteModalVisibility = false;
            this.blurVisibility = false;
        },
        async UpdateCity(updatedname) {
            const objWithIdIndex = this.cities.findIndex((obj) => obj.id === this.CitiId);
            let isexist = this.cities.some((obj) => obj.cityName === updatedname);
            if (!isexist) {
                await axios.patch('/UpdateCity', {
                    id: this.CitiId,
                    CityName: updatedname
                });
                this.cities[objWithIdIndex].cityName = updatedname;
                this.ShowSussces = true,
                    await setTimeout(() => {
                        this.ShowSussces = false;
                        this.cityModalChangeVisibility = false;
                        this.blurVisibility = false;
                    }, 1200);

            }
            else {
                this.ShowError = true;
                setTimeout(() => {
                    this.ShowError = false;
                }, 2500);

            }

        },
        setChangeIDAndOpenChangeModal(id) {
            this.CitiId = id;
            this.cityModalChangeVisibility = true;
            this.blurVisibility = true;
        },
        closeChangeModal() {
            this.cityModalChangeVisibility = false;
            this.blurVisibility = false;
        },
        async AddCity(citiname) {
            let isexist = this.cities.some((obj) => obj.cityName === citiname);
            if (!isexist) {
                let resposne = await axios.put("/CreatCity", {

                    CityName: citiname

                })
                this.cities.push(resposne.data);
                this.ShowSussces = true;
                setTimeout(() => {
                    this.AddCityModalVisibility = false;
                    this.ShowSussces = false;
                    this.blurVisibility = false;
                }, 1200);
            }
            else {
                this.ShowError = true;
                setTimeout(() => {
                    this.ShowError = false;
                }, 2500);
            }
        },
        ShowAddCityModal() {
            this.blurVisibility = true;
            this.AddCityModalVisibility = true;
        },
        CloseAddCityModal() {
            this.blurVisibility = false;
            this.AddCityModalVisibility = false;
        },
        DeleteRailway() {
            axios.delete("/DeleteRailway", {
                data: {
                    id: this.RailwayId
                }
            });
            const objWithIdIndex = this.railways.findIndex((obj) => obj.id === this.RailwayId);
            this.railways.splice(objWithIdIndex, 1);
            this.DeleteRailwayModalVisibility = false;
            this.blurVisibility = false;
        },
        SetRailwayIdAndOpenRailwayDeleteModal(id) {
            this.RailwayId = id;
            this.DeleteRailwayModalVisibility = true;
            this.blurVisibility = true;
        },
        CloseDeleRailwayModal() {
            this.DeleteRailwayModalVisibility = false;
            this.blurVisibility = false;
        },
        CreateRailway(Railway) {
            axios.post("/CreateRailway", {

            });
        },
        ShowAddRailwayModal() {
            this.AddRailwayModalVisibility = true;
            this.blurVisibility = true;
        },
        CloseAddRailwayModal() {
            this.AddRailwayModalVisibility = false;
            this.blurVisibility = false;
        },
        async UpdateRailway(railway) {

            let DepatureCityname = this.cities[railway.Depatureid];
            let ArrivalCityname = this.cities[railway.arrivalid];
            let isexist = this.railways.some((obj) => obj.depatureCity === DepatureCityname && obj.arivalCity === ArrivalCityname);
            if (!isexist) {

                let response = await axios.patch("/UpdateRailway", {
                    Id: this.RailwayId,
                    DepCityId: railway.Depatureid,
                    AriCityId: railway.arrivalid,
                    km: railway.km
                });
                let inex = this.railways.findIndex((obj) => obj.id === this.RailwayId);
                this.railways[inex] = response.data;
                this.ShowSussces = true;
                setTimeout(() => {
                    this.ShowSussces = false;
                    this.blurVisibility = false;
                    this.UpdateRailwayModalVisibility = false;
                }, 1200);
            }
            else
            {
                this.ShowError=true;
                setTimeout(() => {
                    this.ShowError=false;
                }, 1200);
            }
        },
        SetRailwayIdAndOpenUpdateRailwayModal(id){
            this.RailwayId=id;
            this.blurVisibility=true;
            this.UpdateRailwayModalVisibility=true;
        },
        CLoseUpdateRailwayModal()
        {
            this.UpdateRailwayModalVisibility=false;
            this.blurVisibility=false;
        }
    }
}

</script>