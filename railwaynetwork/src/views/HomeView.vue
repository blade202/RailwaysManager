<template>
    <div @click="Showhint"
        class="w-full h-screen min-h-full overflow-auto bg-fixed bg-no-repeat bg-[url('/public/pictures/homebg.jpg')] bg-cover "
        id="home">
        <div class="w-full main-home-container font-mainfont bg-darkgray ">
            <TheNavbar />
            <div
                class="absolute w-full text-sm -translate-x-1/2 xl:text-base lg:text-base md:text-sm sm:text-base xl:w-3/4 lg:w-10/12 md:w-11/12 sm:w-11/12 xl:top-10 lg:top-20 md:top-20 sm:top-20 top-20 main-content-box left-1/2">
                <div
                    class="mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    RailwaysNetwork
                </div>
                <div
                    class="static grid grid-cols-11 grid-rows-1 m-auto text-sm xl:w-1/2 lg:w-10/12 md:w-10/12 sm:w-full searchbar xl:text-base lg:text-base md:text-sm sm:text-base">
                    <select @click="Reomovehint" v-model="DepatCityId" name="" id=""
                        class="static z-0 col-start-1 col-end-6 p-2 pr-3 font-medium text-center rounded-tl-full rounded-bl-full outline-none bg-darkgray text-lightgray">
                        <option selected>Ki induló város</option>
                        <option v-for="item in Cities" :value="item.id">{{ item.cityName }}</option>
                    </select>
                    <select @click="Reomovehint" v-model="ArrivalCityId" name="" id=""
                        class="static z-0 col-start-6 col-end-11 p-2 pr-3 font-medium text-center rounded-tr-full rounded-br-full outline-none bg-darkgray text-lightgray">
                        <option class="rounded-xl" disabled value="" selected>Céllálomás</option>
                        <option v-for="item in Cities" :value="item.id" class="rounded-xl">{{ item.cityName }}</option>
                    </select>
                    <button @click="Searchheandel" class="col-start-11 col-end-12 xl:pl-2 text-lightgray">
                        <i
                            class='px-0 text-2xl font-medium transition duration-200 ease-in-out border-2 rounded-lg xl:px-3 lg:px-3 md:px-3 sm:px-2 bx bx-search border-darkgray hover:bg-darkgray'></i>
                    </button>
                </div>
                <div id="table" class="w-full pb-3 mt-5 overflow-scroll table-box scrollbar-hide max-h-128">
                    <table
                        class="z-10 border-separate rounded-lg border-spacing-y-4 bg-transparent/40 backdrop-blur-sm px-7">
                        <tr class="sticky top-0 font-medium rounded-lg bg-lightgray text-darkgray">
                            <th class="p-3 xl:w-4/5 lg:w-4/5 rounded-bl-xl rounded-br-xl">Állomások</th>
                            <th class="xl:w-1/12 lg:w-1/12 md:w-1/6 sm:w-1/6 rounded-bl-xl rounded-br-xl">Távolság</th>
                            <th class="xl:w-1/12 lg:w-1/12 md:w-1/6 sm:w-1/6 rounded-bl-xl rounded-br-xl">Ár</th>
                            <th class="p-3 xl:w-1/6 lg:w-1/6 md:w-1/6 sm:w-1/6 rounded-br-xl rounded-bl-xl ">Foglalás
                            </th>
                        </tr>
                        <tbody class=" bg-transparent/40 text-lightgray">
                            <tr class="lg:text-base xl:text-base md:text-sm sm:text-sm" v-for="item in Railways">
                                <td
                                    class="p-2 text-center rounded-tl-full rounded-bl-full xl:w-4/5 lg:w-4/5 bg-darkgray h-14 max-h-14">
                                    <div
                                        class="items-center m-auto border-r-4 arrival-depature-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70">
                                        <span v-for="(key, val, index) of item.railways">
                                            <span v-if="val == 0">{{ key.depatureCity }}

                                            </span>
                                            <i class='pl-1 bx bxs-right-arrow-alt'></i>
                                            {{ key.arivalCity }}{{ index }}
                                        </span>
                                    </div>
                                </td>
                                <td class="text-center xl:w-1/12 lg:w-1/12 md:w-1/6 sm:w-1/6 bg-darkgray h-14">
                                    <div
                                        class="border-r-4 km-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70 ">
                                        {{ item.km }} km
                                    </div>
                                </td>
                                <td class="text-center xl:w-1/12 lg:w-1/12 md:w-1/6 sm:w-1/6 bg-darkgray h-14">
                                    <div
                                        class="border-r-4 price-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70 ">
                                        {{ item.price }} Ft
                                    </div>
                                </td>
                                <td
                                    class="font-bold text-center text-white rounded-tr-full rounded-br-full cursor-pointer xl:w-1/6 lg:w-1/6 md:w-1/6 sm:w-1/6 font-sm bg-darkgray h-14">
                                    <div class="buy-container">
                                        <i
                                            class='text-3xl duration-150 ease-in-out text-darkeryellow bx bxs-cart-add hover:text-white'></i>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div id="hint" class="w-full">
                <div
                    class="absolute z-10 w-11/12 p-10 text-center -translate-x-1/2 border-4 rounded-lg font-mainfont backdrop-blur-sm bg-transparent/50 left-1/2 xl:w-3/4 lg:w-5/6 md:w-11/12 sm:w-11/12 loading-conatainer-content xl:top-1/3 lg:top-1/3 md:top-1/3 sm:top-1/3 top-1/2 border-lightgray text-lightgray">
                    Kérjük válasszon induló és érkező állomást!
                </div>
            </div>
        </div>
    </div>
    <div class="w-full spacing-container bg-darkgray font-mainfont ">
        <div class="grid p-10 gird-cols-2 gird-rows-2 spacing-container-content">
            <span
                class="pl-2 m-auto text-3xl font-black border-l-8 xl:text-center welcome-title text-dark border-lightgray/80 z-3">
                Üdvözöljök a RailwaysNetwork oldalán!<br>
            </span>
        </div>
    </div>
    <div
        class=" w-full lower-conent-main-container bg-[url('/public/pictures/lowercontainerbg.png')] bg-cover bg-no-repeat bg-fixed pb-20 font-mainfont">
        <div
            class="grid p-5 m-auto xl:p-5 lg:p-2 md:p-10 sm:p-10 xl:w-full xl:grid-cols-8 xl:grid-rows-1 lg:w-full lg:grid-cols-6 lg:grid-rows-1 lower-conent-container">
            <div
                class="z-10 grid p-3 m-2 border-4 rounded-lg xl:grid-cols-1 xl:col-start-1 xl:col-end-6 xl:grid-rows-2 lg:col-start-1 lg:col-end-4 toolbox bg-transparent/50 backdrop-blur-sm border-lightgray text-lightgray">
                <div
                    class="flex items-center row-start-1 row-end-2 p-4 text-sm text-left border-b-2 xl:text-2xl lg:text-xl md:text-lg sm:text-base technology-paragraph border-lightgray">
                    <span class="border-l-4 h-min w-min border-lightgray">Ez</span> a projekt azért jött létre ,hogy
                    bemutassuk munkaszínvonalunk és tudástárunkat. <br>
                    Az oldal lényege, hogy két kiválaszott város között az összes lehetséges útvonalat megtekinthessük a
                    részleteikkel együtt.
                    Frontend fejlesztő, Soltész Dávid. Backend fejlesztő, Plachi Szilárd.
                </div>
                <div
                    class="flex flex-wrap row-start-2 row-end-2 p-3 place-content-center xl:justify-start lg:justify-center md:justify-center sm:justify-around technology-icons">
                    <div v-for="img in images"
                        class="w-16 p-2 mx-3 mb-2 rounded-lg xl:w-24 lg:w-24 md:w-20 sm:w-24 h-min bg-lightgray/20">
                        <div class="w-12 h-12 p-2 bg-center bg-no-repeat bg-contain xl:w-20 xl:h-20 lg:w-20 lg:h-20 md:w-16 md:h-16 sm:w-20 sm:h-20 icon "
                            v-bind:style="{ backgroundImage: 'url(../public/pictures/' + img + ')' }">
                        </div>
                    </div>
                </div>
            </div>
            <div
                class="grid grid-cols-1 grid-rows-2 p-3 m-2 border-4 rounded-lg lg:grid-rows-2 md:grid-rows-1 sm:grid-rows-1 xl:grid-cols-2 xl:col-start-6 xl:col-end-9 xl:grid-rows-1 lg:col-start-4 lg:col-end-7 lg:grid-cols-1 md:grid-cols-2 sm:grid-cols-2 programers border-lightgray bg-transparent/50 backdrop-blur-sm">
                <div
                    class="col-start-1 col-end-1 row-start-2 row-end-2 p-2 text-sm border-t-2 xl:p-0 lg:p-5 md:p-5 sm:p-0 xl:border-r-2 xl:border-b-0 xl:border-t-0 lg:border-t-0 md:border-t-0 sm:border-t-0 lg:border-b-2 lg:border-r-0 md:border-r-2 sm:border-r-2 xl:col-start-1 xl:col-end-2 xl:row-start-1 xl:row-end-1 lg:col-start-1 lg:col-end-1 lg:row-start-1 lg:row-end-2 md:col-start-1 md:col-end-2 md:row-start-1 md:row-end-1 sm:col-start-1 sm:col-end-2 sm:row-start-1 sm:row-end-1 frontend-developer border-lightgray text-lightgray xl:text-base lg:text-base md:text-sm sm:text-base">
                    <div class="xl:mt-4 lg:mt-0 md:mt-0 contact-name-container">
                        <span
                            class="font-black tracking-wider contacts-name text-lightgray drop-shadow-sm xl:text-base lg:text-base md:text-lg sm:text-base tracking">Soltész
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
                        <span class="flex-wrap p-1 font-bold border-l-4 border-white contacts-email"><span
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
                <div
                    class="col-start-1 col-end-1 row-start-1 row-end-2 p-2 text-sm xl:p-0 lg:p-5 md:p-5 sm:p-0 xl:pl-5 sm:pl-5 backend-developer text-lightgray xl:text-base lg:text-base md:text-sm sm:text-base xl:col-start-2 xl:col-end-2 xl:row-start-1 xl:row-end-2 lg:col-start-1 lg:col-end-2 lg:row-start-2 lg:row-end-2 md:col-start-2 md:col-end-2 md:row-start-1 md:row-end-1 sm:col-start-2 sm:col-end-2 sm:row-start-1 sm:row-end-2">
                    <div class="xl:mt-4 lg:mt-0 md:mt-0 contact-name-container">
                        <span
                            class="font-black tracking-wider contacts-name text-lightgray drop-shadow-sm xl:text-base lg:text-base md:text-lg sm:text-base">Plachi
                            Szilárd
                        </span>
                    </div>
                    <br>
                    <div class="mb-1 contact-phone-container">
                        <span
                            class="p-1 font-bold border-l-4 border-white contacts-phone">Telefon:<br><span>+36204388850</span>
                        </span>
                    </div>
                    <br>
                    <div class="mb-1 contact-email-container">
                        <span class="flex-wrap p-1 font-bold border-l-4 border-white contacts-email"><span
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
            falg: false,
            images: ['.net.png', 'cracs.png', 'css.png', 'html.png', 'js.png', 'mysql.png', 'tailwind.png', 'vuejs.png']
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
            this.falg = false;
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
            console.log(response);
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
        Reomovehint() {

            document.getElementById('hint').classList.add('main-loading-container');
            setTimeout(() => {
                this.falg = true;
            }, 1);

        },
        Showhint() {
            if (this.falg && this.Railways.length === 0) {

                this.falg = false;
                document.getElementById('hint').classList.remove('main-loading-container');
            }
        }

    },
    beforeMount() {
        this.getcities();
    }

}
</script>

