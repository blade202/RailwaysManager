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
                <div class="grid xl:flex lg:flex md:flex sm:grid Cities flex-nowrap ">
                    <button @click="ShowCities"
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
                <div class="grid xl:flex Railways lg:flex md:flex sm:grid flex-nowrap">
                    <button @click="ShowRailways"
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
                <table v-if="TableHeaders.length !== 0"
                    class="w-full px-1 border-separate rounded-tl-lg rounded-tr-lg rounded-bl-lg rounded-br-lg main-admin-table xl:px-7 lg:px-7 md:px-7 sm:px-7 border-spacing-y-4 bg-transparent/40 backdrop-blur-sm font-mainfont">
                    <tr id="admintableheader" class="sticky top-0 w-full font-medium bg-lightgray text-darkgray">
                        <th v-for="header in TableHeaders" class="p-3 rounded-bl-lg rounded-br-lg">{{ header }}</th>
                    </tr>
                    <tbody class=" text-lightgray">
                        <tr v-if="TableHeaders[0] === 'Városok'" v-for="city in Cities" class="">
                            <td class="w-3/5 p-2 text-center rounded-tl-lg rounded-bl-lg bg-darkgray h-14 ">
                                <div class="border-r-4 xl:border-lightgray/70">
                                    {{ city.cityName }}
                                </div>
                            </td>
                            <td class="w-1/5 text-center bg-darkgray h-14 ">
                                <div class="border-r-4 xl:border-lightgray/70">
                                    <i @click="SetChangeIDAndOpenChangeModal(city.id)"
                                        class='inline-block text-2xl duration-150 ease-in-out cursor-pointer text-silver bx bxs-cog ransition hover:text-darkersilver'></i>
                                </div>
                            </td>
                            <td class="w-1/5 text-center rounded-tr-lg rounded-br-lg bg-darkgray h-14">
                                <div class="">
                                    <i @click="SetDeleteIDAndOpenDeleteModal(city.id)"
                                        class='text-3xl duration-150 ease-in-out cursor-pointer text-red bx bxs-trash hover:text-darkerred'></i>
                                </div>
                            </td>
                        </tr>
                        <tr v-if="ShowRailwayMobileScreen" v-for="railway in Railways"
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
                                    {{ railway.km }} Km.
                                </div>
                            </td>
                            <td
                                class="grid items-center w-full col-start-3 col-end-4 row-start-2 row-end-2 text-center xl:w-1/12 lg:w-1/12 md:w-full sm:w-full h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird bg-darkgray xl:col-start-4 xl:col-end-5 xl:row-start-1 xl:row-end-2 lg:col-start-4 lg:col-end-5 lg:row-start-1 lg:row-end-2 md:col-start-3 md:col-end-4 md:row-start-2 md:row-end-2 sm:col-start-3 sm:col-end-4 sm:row-start-2 sm:row-end-2">
                                <div class="border-r-4 border-lightgray/70 ">
                                    <i @click="SetRailwayIDAndOpenUpdateRailwayModal(railway.id)"
                                        class='text-xl duration-150 ease-in-out cursor-pointer xl:text-2xl lg:text-2xl md:text-xl sm:text-xl text-silver bx bxs-cog hover:text-darkersilver'></i>
                                </div>
                            </td>

                            <td
                                class="grid items-center w-full col-start-4 col-end-5 row-start-2 row-end-2 font-bold text-center text-white rounded-br-lg cursor-pointer xl:w-1/12 lg:w-1/12 md:w-full sm:w-full h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:rounded-tr-lg xl:rounded-br-lg lg:rounded-tr-lg lg:rounded-br-lg md:rounded-br-lg sm:rounded-br-lg font-sm bg-darkgray xl:col-start-5 xl:col-end-6 xl:row-start-1 xl:row-end-2 lg:col-start-5 lg:col-end-6 lg:row-start-1 lg:row-end-2 md:col-start-4 md:col-end-5 md:row-start-2 md:row-end-2 sm:col-start-4 sm:col-end-5 sm:row-start-2 sm:row-end-2">
                                <div class="">
                                    <i @click="SetRailwayIDAndOpenRailwayDeleteModal(railway.id)"
                                        class='text-xl duration-150 ease-in-out cursor-pointer xl:text-3xl lg:text-3xl md:text-xl sm:text-xl text-red hover:text-darkerred bx bxs-trash '></i>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <ChangeCityModal :Visible=CityModalChangeVisibility :Close=CloseChangeModal :UpdateCiti=UpdateCity
            :ShowError=ShowError :ShowSuccess=ShowSuccess />
        <DeleteModal :Visible=DeleteModalVisibility :DeleteCity=DeletCities :Closemodal=CloseDeleteModal />
        <AddCityModal :Visible=AddCityModalVisibility :Close=CloseAddCityModal :AddCity=AddCity :ShowError=ShowError
            :ShowSuccess=ShowSuccess />
        <DeleteRailwayModal :Visible=DeleteRailwayModalVisibility :Close=CloseDeleRailwayModal
            :DeleteRailway=DeleteRailway />
        <AddRailwayModal :Visible=AddRailwayModalVisibility :ShowError=ShowError :ShowSuccess=ShowSuccess
            :Close=CloseAddRailwayModal :AddRailway=CreateRailway :Cities=this.Cities />
        <UpdateRailwayModal :Visible=UpdateRailwayModalVisibility :ShowError=ShowError :ShowSuccess=ShowSuccess
            :Close=CloseUpdateRailwayModal :Update=UpdateRailway :Cities=this.Cities />
        <TheFooter />
    </div>
    <div v-if="BlurVisibility" id="blur-overlay"
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
            TableHeaders: [],
            Cities: [],
            Railways: [],
            CityID: null,
            RailwayID: null,
            BlurVisibility: false,
            DeleteModalVisibility: false,
            CityModalChangeVisibility: false,
            AddCityModalVisibility: false,
            DeleteRailwayModalVisibility: false,
            AddRailwayModalVisibility: false,
            UpdateRailwayModalVisibility: false,
            ShowError: false,
            ShowSuccess: false,
            ShowRailwayMobileScreen:false
        }
    },
    methods: {
        async ShowCities() {
            this.TableHeaders = ["Városok", "Módosítás", "Törlés"];
            this.ShowRailwayMobileScreen=false;

        },
        
        async ShowRailways() {
            if (window.innerWidth < 1024) {
                this.TableHeaders = ["Járataink"];
            }else
            {
                this.TableHeaders = ["Induló állomás", "Érkező állomás", "Km", "Módosítás", "Törlés"];
            }
            this.ShowRailwayMobileScreen=true;
        },
        SetDeleteIDAndOpenDeleteModal(id) {
            this.CityID = id;
            this.DeleteModalVisibility = true;
            this.BlurVisibility = true;
        },
        CloseDeleteModal() {
            this.DeleteModalVisibility = false;
            this.BlurVisibility = false;
        },
        async DeletCities() {
            axios.delete('/DeletCity', {
                data: {
                    id: this.CityID
                }
            });
            const ObjWithIDIndex = this.Cities.findIndex((obj) => obj.id === this.CityID);
            this.Cities.splice(ObjWithIDIndex, 1);
            this.DeleteModalVisibility = false;
            this.BlurVisibility = false;
        },
        async UpdateCity(updatedname) {
            const ObjWithIDIndex = this.Cities.findIndex((obj) => obj.id === this.CityID);
            let isexist = this.Cities.some((obj) => obj.cityName === updatedname);
            if (!isexist) {
                await axios.patch('/UpdateCity', {
                    id: this.CityID,
                    CityName: updatedname
                });
                this.Cities[ObjWithIDIndex].cityName = updatedname;
                this.ShowSuccess = true,
                    await setTimeout(() => {
                        this.ShowSuccess = false;
                        this.CityModalChangeVisibility = false;
                        this.BlurVisibility = false;
                    }, 1200);

            }
            else {
                this.ShowError = true;
                setTimeout(() => {
                    this.ShowError = false;
                }, 2500);

            }

        },
        SetChangeIDAndOpenChangeModal(id) {
            this.CityID = id;
            this.CityModalChangeVisibility = true;
            this.BlurVisibility = true;
        },
        CloseChangeModal() {
            this.CityModalChangeVisibility = false;
            this.BlurVisibility = false;
        },
        async AddCity(citiname) {
            let isexist = this.Cities.some((obj) => obj.cityName === citiname);
            if (!isexist) {
                let resposne = await axios.put("/CreatCity", {

                    CityName: citiname

                })
                this.Cities.push(resposne.data);
                this.ShowSuccess = true;
                setTimeout(() => {
                    this.AddCityModalVisibility = false;
                    this.ShowSuccess = false;
                    this.BlurVisibility = false;
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
            this.BlurVisibility = true;
            this.AddCityModalVisibility = true;
        },
        CloseAddCityModal() {
            this.BlurVisibility = false;
            this.AddCityModalVisibility = false;
        },
        DeleteRailway() {
            axios.delete("/DeleteRailway", {
                data: {
                    id: this.RailwayID
                }
            });
            const ObjWithIDIndex = this.Railways.findIndex((obj) => obj.id === this.RailwayID);
            this.Railways.splice(ObjWithIDIndex, 1);
            this.DeleteRailwayModalVisibility = false;
            this.BlurVisibility = false;
        },
        SetRailwayIDAndOpenRailwayDeleteModal(id) {
            this.RailwayID = id;
            this.DeleteRailwayModalVisibility = true;
            this.BlurVisibility = true;
        },
        CloseDeleRailwayModal() {
            this.DeleteRailwayModalVisibility = false;
            this.BlurVisibility = false;
        },
        async CreateRailway(railway) {
            let DepatureCityname = this.Cities[this.Cities.findIndex((obj) => obj.id === railway.DepatureID)].cityName;
            let ArrivalCityname = this.Cities[this.Cities.findIndex((obj) => obj.id === railway.ArrivalID)].cityName;
            let isexist=this.Railways.some((obj) => obj.depatureCity === DepatureCityname&&obj.arivalCity === ArrivalCityname);         
            if (!isexist) {
                 let response = await axios.put("/CreateRailwy", {
                    DepatureCityID: railway.DepatureID,
                    ArivalCityID: railway.ArrivalID,
                    km: railway.Km
                });
                this.Railways.push(response.data)
                this.ShowSuccess = true;
                setTimeout(() => {
                    this.ShowSuccess = false;
                    this.BlurVisibility = false;
                    this.AddRailwayModalVisibility = false;
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
        ShowAddRailwayModal() {
            this.AddRailwayModalVisibility = true;
            this.BlurVisibility = true;
        },
        CloseAddRailwayModal() {
            this.AddRailwayModalVisibility = false;
            this.BlurVisibility = false;
        },
        async UpdateRailway(railway) {

            let DepatureCityname = this.Cities[this.Cities.findIndex((obj) => obj.id === railway.DepatureID)].cityName;
            let ArrivalCityname = this.Cities[this.Cities.findIndex((obj) => obj.id === railway.ArrivalID)].cityName;

            let isexist=this.Railways.some((obj) => obj.depatureCity === DepatureCityname&&obj.arivalCity === ArrivalCityname&&obj.km ===railway.Km);         
            if (!isexist) {
                let response = await axios.patch("/UpdateRailway", {
                    id: this.RailwayID,
                    depCitiyId: railway.DepatureID,
                    ariCityID: railway.ArrivalID,
                    km: railway.Km
                });
                let inex = this.Railways.findIndex((obj) => obj.id === this.RailwayID);
                this.Railways[inex] = response.data;
                this.ShowSuccess = true;
                setTimeout(() => {
                    this.ShowSuccess = false;
                    this.BlurVisibility = false;
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
        SetRailwayIDAndOpenUpdateRailwayModal(id) {
            this.RailwayID = id;
            this.BlurVisibility = true;
            this.UpdateRailwayModalVisibility = true;
        },
        CloseUpdateRailwayModal() {
            this.UpdateRailwayModalVisibility = false;
            this.BlurVisibility = false;
        },
        async getCities() {
            let ctresponse = await axios.get('/GetRailways');
            this.Railways = ctresponse.data;
        },
        async getRailways() {
            let Railwaysresponse = await axios.get('/getCities');
            this.Cities = Railwaysresponse.data;
        }
    },
    async beforeMount() {
        await this.getCities();
        await this.getRailways();
        onresize = (event) => {
            if (window.innerWidth < 1024 && this.TableHeaders.length>3) {
                this.TableHeaders = ["Járatok"]
                

            } else if (window.innerWidth > 1024 && this.TableHeaders.length<3) {

                this.TableHeaders = ["Induló állomás", "Érkező állomás", "Km", "Módosítás", "Törlés"];

            }
            console.log(window.innerWidth,this.TableHeaders.length)
        }
    }

}

</script>
