<template>
    <div id="admin"
        class="w-full main-admin-container h-screen bg-[url('/public/pictures/admintestbg.jpg')] bg-cover bg-no-repeat  ">
        <TheNavbar />
        <div
            class="absolute w-full h-screen -translate-x-1/2 xl:top-10 lg:top-20 md:top-20 sm:top-20 top-20 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 left-1/2 admin-content-container">
            <div
                class="m-auto mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                <router-link to="/home">RailwayNetwork</router-link>
            </div>
            <div
                class="grid w-11/12 grid-cols-2 p-3 m-auto mb-5 text-sm font-medium rounded-tl-lg rounded-tr-lg rounded-bl-lg rounded-br-lg xl:gap-0 lg:gap-0 md:gap-0 sm:gap-x-5 gap-x-5 xl:grid-cols-2 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 xl:flex lg:flex md:flex sm:grid xl:text-base lg:text-base md:text-sm sm:text-sm bg-transparent/40 backdrop-blur-sm navbar text-lightgray font-mainfont place-content-around">
                <div class="grid xl:flex lg:flex md:flex sm:grid cities flex-nowrap ">
                    <button @click="showcities"
                        class="xl:py-0 lg:py-0 md:py-0 sm:py-1.5 py-1.5 border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Városok
                    </button>
                    <div class="text-center icon-container xl:text-center lg:text-center md:text-center sm:text-center">
                        <i
                            class='relative text-3xl rotate-90 transform-none bx bx-dots-horizontal-rounded xl:rotate-0 lg:rotate-0 md:rotate-0 sm:rotate-90'></i>
                    </div>
                    <button @click="ShowAddCityModal"
                        class="xl:py-0 lg:py-0 md:py-0 sm:py-1.5 py-1.5 border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Hozzáadás
                    </button>
                </div>
                <div class="grid xl:flex railways lg:flex md:flex sm:grid flex-nowrap">
                    <button @click="showrailways"
                        class="xl:py-0 lg:py-0 md:py-0 sm:py-1.5 py-1.5 border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Útvonalak
                    </button>
                    <div class="text-center icon-container xl:text-center lg:text-center md:text-center sm:text-center">
                        <i
                            class='relative text-3xl rotate-90 transform-none bx bx-dots-horizontal-rounded xl:rotate-0 lg:rotate-0 md:rotate-0 sm:rotate-90 '></i>
                    </div>
                    <button @click="ShowAddRailwayModal"
                        class="xl:py-0 lg:py-0 md:py-0 sm:py-1.5 py-1.5 border-2 border-lightgray p-0.5 px-5 rounded-lg transition duration-200 ease-in-out hover:bg-lightgray hover:text-darkgray">
                        Hozzáadás
                    </button>
                </div>
            </div>
            <div id="admin-table"
                class="w-11/12 m-auto overflow-scroll text-sm xl:max-h-desktop lg:max-h-desktop md:max-h-desktop sm:max-h-desktop max-h-mobile xl:text-base lg:text-base md:text-sm sm:text-sm table-box scrollbar-hide font-mainfont">
                <table v-if="tableheaders.length !== 0"
                    class="w-full px-1 border-separate rounded-tl-lg rounded-tr-lg rounded-bl-lg rounded-br-lg main-admin-table xl:px-7 lg:px-7 md:px-7 sm:px-7 border-spacing-y-4 bg-transparent/40 backdrop-blur-sm font-mainfont">
                    <tr id="admintableheader" class="sticky top-0 w-full font-medium bg-lightgray text-darkgray">
                        <th v-for="header in tableheaders" class="p-3 rounded-bl-lg rounded-br-lg">{{ header }}</th>
                    </tr>
                    <tbody class=" text-lightgray">
                        <tr v-if="tableheaders[0] === 'Városok'" v-for="city in cities" class="">
                            <td class="w-3/5 p-2 text-center rounded-tl-lg rounded-bl-lg bg-darkgray h-14 ">
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
                            <td class="w-1/5 text-center rounded-tr-lg rounded-br-lg bg-darkgray h-14">
                                <div class="">
                                    <i @click="setDeleteIDAndOpenDeleteModal(city.id)"
                                        class='text-3xl duration-150 ease-in-out cursor-pointer text-red bx bxs-trash hover:text-darkerred'></i>
                                </div>
                            </td>
                        </tr>
                        <tr v-if="showrailwayalone" v-for="railway in railways"
                            class="grid w-full grid-cols-4 grid-rows-2 mb-5 xl:table-row lg:table-row md:grid sm:grid xl:grid-cols-5 xl:grid-rows-1 lg:grid-cols-5 lg:grid-rows-1 md:grid-cols-4 md:grid-rows-2 sm:grid-cols-4 sm:grid-rows-2 ">
                            <td
                                class="grid items-center col-start-1 col-end-3 row-start-1 row-end-2 p-0 pl-3 text-center rounded-tl-lg rounded-tr-none h-11 scrollbar-hide xl:table-cell lg:table-cell md:grid sm:gird xl:p-2 lg:p-2 md:p-0 sm:p-0 xl:rounded-tr-none lg:rounded-tr-none md:rounded-tr-none sm:rounded-tr-none xl:rounded-tl-lg xl:rounded-bl-lg lg:rounded-tl-lg lg:rounded-bl-lg md:rounded-tl-lg sm:rounded-tl-lg bg-darkgray xl:col-start-1 xl:col-end-2 xl:row-start-1 xl:row-end-1 lg:col-start-1 lg:col-end-2 md:col-start-1 md:col-end-3 md:row-start-1 md:row-end-2 sm:col-start-1 sm:col-end-3 sm:row-start-1 sm:row-end-2 xl:pl-0 lg:pl-0 md:pl-3 sm:pl-3">
                                <div
                                    class="grid items-center p-1 px-3 overflow-x-scroll border-r-0 rounded-tl-lg rounded-bl-lg scrollbar-hide whitespace-nowrap xl:border-r-4 lg:border-r-4 md:border-r-0 sm:border-r-0 border-lightgray/70 xl:text-base lg:text-base md:text-sm sm:text-sm xl:bg-darkgray lg:bg-darkgray md:bg-dark/40 sm:bg-dark/40 bg-dark/40 xl:mx-0 lg:mx-0 md:mx-0 sm:mx-0 xl:rounded-none lg:rounded-none md:rounded-tl-lg md:rounded-bl-lg sm:rounded-tl-lg sm:rounded-bl-lg xl:h-10 lg:h-10 md:h-8 sm:h-8 xl:p-0 lg:p-0 md:p-1 sm:p-1">
                                    {{ railway.depatureCity }}</div>
                            </td>
                            <td class="grid items-center col-start-3 col-end-5 row-start-1 row-end-2 p-0 pr-3 text-center rounded-tr-lg h-11 scrollbar-hide xl:p-2 lg:p-2 md:p-0 sm:p-0 xl:mt-0 xl:rounded-tr-none lg:rounded-tr-none md:rounded-tr-lg sm:rounded-tr-lg xl:table-cell lg:table-cell md:grid sm:gird bg-darkgray xl:col-start-2 xl:col-end-3 xl:row-start-1 xl:row-end-2 lg:col-start-2 lg:col-end-3 lg:row-start-1 lg:row-end-2 md:col-start-3 md:col-end-5 md:row-start-1 md:row-end-2 sm:col-start-3 sm:col-end-5 sm:row-start-1 sm:row-end-2 xl:pr-0 lg:pr-0 md:pr-3 sm:pr-3">
                                <div
                                    class="grid items-center p-1 px-3 overflow-x-scroll border-r-0 rounded-tr-lg rounded-br-lg scrollbar-hide whitespace-nowrap xl:border-r-4 lg:border-r-4 md:border-r-0 sm:border-r-0 border-lightgray/70 xl:text-base lg:text-base md:text-sm sm:text-sm xs:text-sm xl:bg-darkgray lg:bg-darkgray md:bg-dark/40 sm:bg-dark/40 bg-dark/40 xl:mx-0 lg:mx-0 md:mx-0 sm:mx-0 xl:rounded-none lg:rounded-none md:rounded-tr-lg md:rounded-br-lg sm:rounded-tr-lg sm:rounded-br-lg xl:h-10 lg:h-10 md:h-8 sm:h-8 xl:p-0 lg:p-0 md:p-1 sm:p-1">
                                    {{ railway.arivalCity }}
                                </div>
                            </td>
                            <td
                                class="grid items-center w-full col-start-1 col-end-3 row-start-2 row-end-2 text-center rounded-bl-lg xl:w-2/12 lg:w-2/12 md:w-full sm:w-full h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:rounded-bl-none lg:rounded-bl-none md:rounded-bl-lg sm:rounded-bl-lg bg-darkgray xl:col-start-3 xl:col-end-4 xl:row-start-1 xl:row-end-2 lg:col-start-3 lg:col-end-4 md:col-start-1 md:col-end-3 md:row-start-2 md:row-end-2 sm:col-start-1 sm:col-end-3 sm:row-start-2 sm:row-end-2">
                                <div
                                    class="px-3 text-sm border-r-4 border-lightgray/70 xl:text-base lg:text-base md:text-base sm:text-sm">
                                    {{ railway.km }} km
                                </div>
                            </td>
                            <td
                                class="grid items-center w-full col-start-3 col-end-4 row-start-2 row-end-2 text-center xl:w-1/12 lg:w-1/12 md:w-full sm:w-full h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird bg-darkgray xl:col-start-4 xl:col-end-5 xl:row-start-1 xl:row-end-2 lg:col-start-4 lg:col-end-5 lg:row-start-1 lg:row-end-2 md:col-start-3 md:col-end-4 md:row-start-2 md:row-end-2 sm:col-start-3 sm:col-end-4 sm:row-start-2 sm:row-end-2">
                                <div class="border-r-4 border-lightgray/70 ">
                                    <i @click="SetRailwayIdAndOpenUpdateRailwayModal(railway.id)"
                                        class='text-xl duration-150 ease-in-out cursor-pointer xl:text-2xl lg:text-2xl md:text-xl sm:text-xl text-silver bx bxs-cog hover:text-darkersilver'></i>
                                </div>
                            </td>

                            <td
                                class="grid items-center w-full col-start-4 col-end-5 row-start-2 row-end-2 font-bold text-center text-white rounded-br-lg cursor-pointer xl:w-1/12 lg:w-1/12 md:w-full sm:w-full h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:rounded-tr-lg xl:rounded-br-lg lg:rounded-tr-lg lg:rounded-br-lg md:rounded-br-lg sm:rounded-br-lg font-sm bg-darkgray xl:col-start-5 xl:col-end-6 xl:row-start-1 xl:row-end-2 lg:col-start-5 lg:col-end-6 lg:row-start-1 lg:row-end-2 md:col-start-4 md:col-end-5 md:row-start-2 md:row-end-2 sm:col-start-4 sm:col-end-5 sm:row-start-2 sm:row-end-2">
                                <div class="">
                                    <i @click="SetRailwayIdAndOpenRailwayDeleteModal(railway.id)"
                                        class='text-xl duration-150 ease-in-out cursor-pointer xl:text-3xl lg:text-3xl md:text-xl sm:text-xl text-red hover:text-darkerred bx bxs-trash '></i>
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
            :close=CloseAddRailwayModal :AddRailway=CreateRailway :Cities=this.cities />
        <UpdateRailwayModal :visible=UpdateRailwayModalVisibility :ShowError=ShowError :ShowSussces=ShowSussces
            :close=CLoseUpdateRailwayModal :Update=UpdateRailway :Cities=this.cities />
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


export default {
    name: "admin",
    components: {
        TheNavbar, TheFooter, DeleteModal, ChangeCityModal, AddCityModal, DeleteRailwayModal, AddRailwayModal, UpdateRailwayModal
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
            showrailwayalone:false
        }
    },
    methods: {
        async showcities() {
            this.tableheaders = ["Városok", "Módosítás", "Törlés"];
            this.showrailwayalone=false;
        },
        
        async showrailways() {
            if (window.innerWidth < 1024) {
                this.tableheaders = ["Járataink"];
            }else
            {
                this.tableheaders = ["Induló állomás", "Érkező állomás", "Km", "Módosítás", "Törlés"];
            }
            this.showrailwayalone=true;
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

            let DepatureCityname = this.cities[this.cities.findIndex((obj) => obj.id === railway.Depatureid)].cityName;
            let ArrivalCityname = this.cities[this.cities.findIndex((obj) => obj.id === railway.arrivalid)].cityName;
            console.log(DepatureCityname, ArrivalCityname);
            let isexist = this.railways.some((obj) => obj.depatureCity === DepatureCityname && obj.arivalCity === ArrivalCityname);
            if (!isexist) {
                let response = await axios.patch("/UpdateRailway", {
                    Id: this.RailwayId,
                    DepCitiyId: railway.Depatureid,
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
            else {
                this.ShowError = true;
                setTimeout(() => {
                    this.ShowError = false;
                }, 1200);
            }

        },
        SetRailwayIdAndOpenUpdateRailwayModal(id) {
            this.RailwayId = id;
            this.blurVisibility = true;
            this.UpdateRailwayModalVisibility = true;
        },
        CLoseUpdateRailwayModal() {
            this.UpdateRailwayModalVisibility = false;
            this.blurVisibility = false;
        },
        async getcities() {
            let ctresponse = await axios.get('/GetRailways');
            this.railways = ctresponse.data;
        },
        async getrailways() {
            let railwaysresponse = await axios.get('/getCities');
            this.cities = railwaysresponse.data;
        }
    },
    async beforeMount() {
        await this.getcities();
        await this.getrailways();
        onresize = (event) => {
            if (window.innerWidth < 1024 && this.tableheaders.length>3) {
                this.tableheaders = ["Járatok"]
                

            } else if (window.innerWidth > 1024 && this.tableheaders.length<3) {

                this.tableheaders = ["Induló állomás", "Érkező állomás", "Km", "Módosítás", "Törlés"];

            }
            console.log(window.innerWidth,this.tableheaders.length)
        }
    }

}

</script>
