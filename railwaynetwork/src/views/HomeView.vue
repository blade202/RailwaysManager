<template>
    <div @click="Showhint" class="w-full h-screen min-h-full overflow-auto bg-fixed bg-no-repeat bg-cover bg-homebg" id="home">
        <div class="w-full main-home-container font-mainfont bg-darkgray ">
            <TheNavbar />
            <div
                class="absolute -translate-x-1/2 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 xl:top-10 lg:top-20 md:top-20 sm:top-20 main-content-box left-1/2">
                <div
                    class="mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    RailwaysNetwork
                </div>
                <div class="grid grid-cols-11 grid-rows-1 m-auto xl:w-1/2 lg:w-10/12 md:w-10/12 sm:w-full searchbar">
                    <select @click="Reomovehint" v-model="DepatCityId" name="" id=""
                        class="col-start-1 col-end-6 p-2 pr-3 font-medium text-center rounded-tl-full rounded-bl-full outline-none text-md bg-darkgray text-lightgray">
                        <option selected>Ki induló város</option>
                        <option  v-for="item in Cities" :value="item.id">{{ item.cityName }}</option>
                    </select>
                    <select  @click="Reomovehint" v-model="ArrivalCityId" name="" id=""
                        class="col-start-6 col-end-11 p-2 pr-3 font-medium text-center rounded-tr-full rounded-br-full outline-none text-md bg-darkgray text-lightgray">
                        <option  class="rounded-xl" disabled value="" selected>Céllálomás</option>
                        <option v-for="item in Cities" :value="item.id" class="rounded-xl">{{ item.cityName }}</option>
                    </select>
                    <button @click="Searchheandel" class="col-start-11 col-end-12 xl:pl-2 text-lightgray">
                        <i
                            class='px-3 text-2xl font-medium transition duration-200 ease-in-out border-2 rounded-lg bx bx-search border-darkgray hover:bg-darkgray'></i>
                    </button>
                </div>
                <div id="table" class="w-full pb-3 mt-5 overflow-scroll table-box scrollbar-hide max-h-128">
                    <table
                        class="border-separate rounded-lg border-spacing-y-4 bg-transparent/40 backdrop-blur-sm px-7">
                        <tr class="sticky top-0 font-medium rounded-lg bg-lightgray text-darkgray">
                            <th class="w-4/5 p-3 rounded-bl-xl">Állomások</th>
                            <th class="w-1/12">Távolság</th>
                            <th class="w-1/12">Ár</th>
                            <th class="w-1/6 p-3 rounded-br-xl">Foglalás</th>
                        </tr>
                        <tbody class=" bg-transparent/40 text-lightgray">
                            <tr class="lg:text-base xl:text-base md:text-sm sm:text-sm" v-for="item in Railways">
                                <td
                                    class="w-4/5 p-2  text-center rounded-tl-full rounded-bl-full bg-darkgray h-14 max-h-14">
                                    <div
                                        class="border-r-4 arrival-depature-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70 sm:border-none">
                                        <span v-for="(key, val, index) of item.railways">
                                            <span v-if="val == 0">{{ key.depatureCity }}
                                            </span>
                                            ->
                                            {{ key.arivalCity }}{{ index }}
                                        </span>
                                    </div>
                                </td>
                                <td class="w-1/12 text-center bg-darkgray h-14">
                                    <div
                                        class="border-r-4 km-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70 ">
                                        {{ item.km }} km.
                                    </div>
                                </td>
                                <td class="w-1/12 text-center bg-darkgray h-14">
                                    <div
                                        class="border-r-4 price-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70 ">
                                        {{ item.price }} Ft.
                                    </div>
                                </td>
                                <td
                                    class="w-1/6 font-bold text-center text-white rounded-tr-full rounded-br-full cursor-pointer font-sm bg-darkgray h-14">
                                    <div class="buy-container">
                                        Vásárlás
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div id="hint" class="w-full">
                <div
                    class="absolute p-10 text-xl text-center -translate-x-1/2 border-4 rounded-lg font-mainfont backdrop-blur-sm bg-transparent/50 left-1/2 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 loading-conatainer-content xl:top-1/3 lg:top-1/3 md:top-1/3 sm:top-1/3 border-lightgray text-lightgray">
                    Kérjük válasszon induló és érkező állomást!
                </div>
            </div>
        </div>
    </div>
    <div class="w-full spacing-container bg-darkgray font-mainfont ">
        <div class="grid p-10 gird-cols-2 gird-rows-2 spacing-container-content">
            <span
                class="pl-2 m-auto text-3xl font-black border-l-8 xl:text-center welcome-title text-dark border-lightgray/80">
                Üdvözöljök a RailwaysNetwork oldalán!<br>
            </span>
        </div>
    </div>
    <div
        class="w-full lower-conent-main-container bg-[url('/public/pictures/lowercontainerbg.png')] bg-cover bg-no-repeat bg-fixed pb-20 font-mainfont">
        <div
            class="grid p-10 m-auto xl:w-full xl:grid-cols-8 xl:grid-rows-1 lg:w-full lg:grid-cols-6 lg:grid-rows-1 lower-conent-container">
            <div
                class="grid p-3 m-2 text-xl border-4 rounded-lg xl:grid-cols-1 xl:col-start-1 xl:col-end-6 xl:grid-rows-2 lg:col-start-1 lg:col-end-4 toolbox bg-transparent/50 backdrop-blur-sm border-lightgray text-lightgray">
                <div
                    class="row-start-1 row-end-2 p-4 text-left border-b-2 xl:text-2xl lg:text-base technology-paragraph border-lightgray">
                    Ez a projekt azért jött létre ,hogy bemutassuk munkaszínvonalunk és tudástárunkat. <br>
                    Az oldal lényege, hogy két kiválaszott város között az összes lehetséges útvonalat megtekinthessük a
                    részleteikkel együtt.
                    Frontend fejlesztő, Soltész Dávid. Backend fejlesztő, Plachi Szilárd.
                </div>
                <div class="grid grid-cols-5 grid-rows-2 row-start-2 row-end-2 p-3 text-center technology-icons">
                    <div class="py-2 mb-2 rounded-lg vuejscontainer w-18 h-18 bg-lightgray/20 mx-14">
                        <div
                            class="icon bg-[url('/public/pictures/vuejspng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto bg-center p-2">
                        </div>
                    </div>
                    <div class="rounded-lg .netcontainer w-18 h-18 bg-lightgray/20 py-2 mx-14 mb-2">
                        <div
                            class="icon bg-[url('/public/pictures/.netpng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto  bg-center p-2">
                        </div>
                    </div>
                    <div class="py-2 mb-2 rounded-lg tailwindcsscontainer w-18 h-18 bg-lightgray/20 mx-14">
                        <div
                            class="icon bg-[url('/public/pictures/tailwindpng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto bg-center p-2">
                        </div>
                    </div>
                    <div class="py-2 mb-2 rounded-lg cracscontainer w-18 h-18 bg-lightgray/20 mx-14">
                        <div
                            class="icon bg-[url('/public/pictures/cracspng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto  bg-center p-2">
                        </div>
                    </div>
                    <div class="py-2 mb-2 rounded-lg mysqlcontainer w-18 h-18 bg-lightgray/20 mx-14">
                        <div
                            class="icon bg-[url('/public/pictures/mysqlpng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto  bg-center p-2">
                        </div>
                    </div>
                    <div class="py-2 mb-2 rounded-lg javascriptcontainer w-18 h-18 bg-lightgray/20 mx-14">
                        <div
                            class="icon bg-[url('/public/pictures/jspng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto  bg-center p-2">
                        </div>
                    </div>
                    <div class="py-2 mb-2 rounded-lg htmlcontainer w-18 h-18 bg-lightgray/20 mx-14">
                        <div
                            class="icon bg-[url('/public/pictures/htmlpng.png')]  w-16 h-16 bg-contain bg-no-repeat m-auto  bg-center p-2">
                        </div>
                    </div>
                </div>
            </div>
            <div
                class="grid p-5 m-2 border-4 rounded-lg xl:grid-cols-2 xl:col-start-6 xl:col-end-9 xl:grid-rows-1 lg:col-start-4 lg:col-end-7 programers border-lightgray bg-transparent/50 backdrop-blur-sm">
                <div class="col-start-1 border-r-2 col-end 2 frontend-developer border-lightgray text-lightgray">
                    <div class="mt-4 contact-name-container">
                        <span class="text-xl font-black contacts-name text-lightgray drop-shadow-sm">Soltész
                            Dávid</span>
                    </div>
                    <br>
                    <div class="mb-1 contact-phone-container">
                        <span
                            class="p-1 font-bold border-l-4 border-white contacts-phone">Telefon:<br><span>+36204388850</span>
                        </span>
                    </div>
                    <br>
                    <div class="mb-1 contact-email-container">
                        <span
                            class="flex-wrap p-1 font-bold border-l-4 border-white xl:text-sm lg:text-sm md:text-base sm:text-sm contacts-email"><span
                                class="text-base">Email:</span><br><span>solteszdavid@gmail.com</span>
                        </span>
                    </div>
                    <br>
                    <div class="contact-link-conatiner">
                        <span
                            class="p-1 font-bold border-l-4 border-white github-link">GitHub:<br><span>solteszlink</span>
                        </span>
                    </div>
                </div>
                <div class="col-start-2 col-end-2 pl-5 backend-developer text-lightgray">
                    <div class="mt-4 contact-name-container">
                        <span class="text-xl font-black contacts-name text-lightgray drop-shadow-sm">Plachi
                            Szilárd</span>
                    </div>
                    <br>
                    <div class="mb-1 contact-phone-container">
                        <span
                            class="p-1 font-bold border-l-4 border-white contacts-phone">Telefon:<br><span>+36204388850</span>
                        </span>
                    </div>
                    <br>
                    <div class="mb-1 contact-email-container">
                        <span
                            class="flex-wrap p-1 font-bold border-l-4 border-white xl:text-sm lg:text-sm md:text-base sm:text-sm contacts-email"><span
                                class="text-base">Email:</span><br><span>plachiszilárd@gmail.com</span>
                        </span>
                    </div>
                    <br>
                    <div class="contact-link-conatiner">
                        <span
                            class="p-1 font-bold border-l-4 border-white github-link">GitHub:<br><span>szilardlink</span>
                        </span>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <TheFooter />
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
            Cities: null,
            Railways: [],
            DepatCityId: 0,
            ArrivalCityId: 0,
            range: 0,
            falg:false,
        }
    },
    methods: {
        async getcities() {
            let response = await axios.get('/getCities');
            this.Cities = response.data;
            document.getElementById('table').addEventListener("scroll", this.handleScroll);
        },
        async handleScroll() {
            let div = document.getElementById('table');
            if (div.offsetHeight + div.scrollTop >= div.scrollHeight) {
                this.range = this.range + 50;
                await this.GetRailways();
            }
        },
        async Searchheandel() {

            this.range = 0;
            this.Railways = []
            this.falg=false;
            this.Reomovehint();
            await this.GetRailways()
        },
        async GetRailways() {
            console.log(this.ArrivalCityId);

            let response = await axios.post('/GetRoutes', {
                DepatureId: this.DepatCityId,
                ArrivalId: this.ArrivalCityId,
                range: this.range
            })
            if (response.data.railways !== null) {
                this.Railways = [...this.Railways, ...response.data];
            }
        },
        setDepaturecity(id) {
            this.DepatCityId = id;
            console.log(id);
        },
        setArrivalCity(id) {
            this.ArrivalCityId = id;
        },
        Reomovehint()
        {
            
            document.getElementById('hint').classList.add('main-loading-container');
            setTimeout(()=>{
                this.falg=true;
            },1);
    
        },
        Showhint()
        {
            if(this.falg&&this.Railways.length===0)
            {
            
                this.falg=false;
                document.getElementById('hint').classList.remove('main-loading-container');
            }
        }
        
    },
    beforeMount() {
        this.getcities();
    }

}
</script>

