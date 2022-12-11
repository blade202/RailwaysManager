<template>
    <div @click="Showhint"
        class="w-full h-screen min-h-full overflow-auto bg-fixed bg-no-repeat bg-[url('/public/pictures/hometestbg.jpg')] bg-cover bg-blend-darken "
        id="home">
        <div class="w-full main-home-container font-mainfont bg-darkgray ">
            <TheNavbar />
            <div
                class="absolute w-11/12 text-sm -translate-x-1/2 xl:text-base lg:text-sm md:text-sm sm:text-base xl:w-3/4 lg:w-11/12 md:w-11/12 sm:w-11/12 xl:top-10 lg:top-20 md:top-20 sm:top-20 top-20 main-content-box left-1/2">
                <div
                    class="mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    RailwayNetwork
                </div>
                <div
                    class="static z-10 grid grid-cols-10 grid-rows-2 p-2 m-auto text-sm xl:p-0 lg:p-0 md:p-0 sm:p-0 left-1/2 xl:grid-cols-11 xl:grid-rows-1 lg:grid-cols-11 lg:grid-rows-1 md:grid-cols-11 md:grid-rows-1 sm:grid-cols-11 sm:grid-rows-1 xl:w-1/2 lg:w-10/12 md:w-10/12 sm:w-full searchbar xl:text-base lg:text-base md:text-sm sm:text-base">
                    <select @click="Reomovehint" v-model="DepatureCityID" name="" id=""
                        class="static z-0 col-start-1 col-end-6 p-2 pr-3 font-medium text-center rounded-tl-lg rounded-bl-lg outline-none xl:row-start-1 xl:row-end-2 lg:row-start-1 lg:row-end-2 md:row-start-1 md:row-end-2 sm:row-start-1 sm:row-end-2 bg-darkgray text-lightgray">
                        <option selected>Kiinduló város</option>
                        <option v-for="item in Cities" :value="item.id">{{ item.cityName }}</option>
                    </select>
                    <select @click="Reomovehint" v-model="ArrivalCityID" name="" id=""
                        class="static z-0 col-start-6 col-end-11 p-2 pr-3 font-medium text-center rounded-tr-lg rounded-br-lg outline-none xl:row-start-1 xl:row-end-2 lg:row-start-1 lg:row-end-2 md:row-start-1 md:row-end-2 sm:row-start-1 sm:row-end-2 bg-darkgray text-lightgray">
                        <option class="rounded-lg" disabled value="" selected>Céllálomás</option>
                        <option v-for="item in Cities" :value="item.id" class="rounded-lg">{{ item.cityName }}</option>
                    </select>
                    <button @click="Searchheandel"
                        class="col-start-4 col-end-8 row-start-2 row-end-2 xl:col-start-11 xl:col-end-12 lg:col-start-11 lg:col-end-12 md:col-start-11 md:col-end-12 sm:col-start-11 sm:col-end-12 xl:pl-2 text-lightgray xl:row-start-1 xl:row-end-2 lg:row-start-1 lg:row-end-2 md:row-start-1 md:row-end-2 sm:row-start-1 sm:row-end-2">
                        <i
                            class='px-5 mt-1 text-2xl font-medium transition duration-200 ease-in-out border-2 rounded-lg xl:mt-0 lg:mt-0 md:mt-0 sm:mt-0 xl:px-3 lg:px-3 md:px-3 sm:px-2 bx bx-search border-darkgray hover:bg-darkgray'></i>
                    </button>
                </div>

                <!--Table-->
                <div id="table"
                    class="z-10 w-full p-2 pb-3 mt-5 overflow-scroll table-box scrollbar-hide xl:max-h-desktop lg:max-h-desktop md:max-h-desktop sm:max-h-desktop max-h-mobile">
                    <table
                        class="px-1 border-separate xl:rounded-lg lg:rounded-lg md:rounded-none sm:rounded-none xl:border-spacing-y-4 lg:border-spacing-y-4 md:border-spacing-y-0 sm:border-spacing-y-0 bg-transparent/40 backdrop-blur-sm xl:px-7 lg:px-7 md:px-7 sm:px-7">
                        <tr id="tableheader" class="sticky top-0 font-medium rounded-lg bg-lightgray text-darkgray">
                            <th
                                class="p-3 rounded-bl-lg rounded-br-lg xl:w-4/5 lg:w-4/5 md:w-4/5 sm:w-4/5 xl:rounded-bl-lg xl:rounded-br-lg lg:rounded-bl-lg lg:rounded-br-lg md:rounded-bl-lg md:rounded-br-lg sm:rounded-bl-lg sm:rounded-br-lg">
                                Állomások
                            </th>
                            <th
                                class="w-1/6 rounded-bl-none rounded-br-none xl:w-1/12 lg:w-1/12 md:w-1/6 sm:w-1/6 xl:rounded-bl-lg xl:rounded-br-lg lg:rounded-bl-lg lg:rounded-br-lg md:rounded-bl-lg md:rounded-br-lg sm:rounded-bl-lg sm:rounded-br-lg">
                                Távolság
                            </th>
                            <th
                                class="w-1/6 rounded-bl-none rounded-br-none xl:w-1/12 lg:w-1/12 md:w-1/6 sm:w-1/6 xl:rounded-bl-lg xl:rounded-br-lg lg:rounded-bl-lg lg:rounded-br-lg md:rounded-bl-lg md:rounded-br-lg sm:rounded-bl-lg sm:rounded-br-lg">
                                Ár
                            </th>
                            <th
                                class="w-1/6 p-3 rounded-bl-none rounded-br-lg xl:w-1/6 lg:w-1/6 md:w-1/6 sm:w-1/6 xl:rounded-bl-lg xl:rounded-br-lg lg:rounded-bl-lg lg:rounded-br-lg md:rounded-bl-lg md:rounded-br-lg sm:rounded-bl-lg sm:rounded-br-lg ">
                                Foglalás
                            </th>
                        </tr>
                        <tbody class=" text-lightgray">
                            <!--Table row-->
                            <tr class="grid w-full grid-cols-3 grid-rows-2 mb-5 xl:table-row lg:table-row md:grid sm:grid xl:grid-cols-4 xl:grid-rows-1 lg:grid-cols-4 lg:grid-rows-1 md:grid-cols-3 md:grid-rows-2 sm:grid-cols-3 sm:grid-rows-2 br lg:text-base xl:text-base md:text-base sm:text-sm"
                                v-for="item in Railways">
                                <!--First td/Állomások-->
                                <td
                                    class="grid items-center w-full col-start-1 col-end-4 row-start-1 row-end-2 p-0 px-3 text-center rounded-tl-lg rounded-tr-lg h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:p-2 xl:px-0 lg:px-0 md:px-0 sm:px-0 lg:p-2 md:p-2 sm:p-2 xl:rounded-tr-none lg:rounded-tr-none md:rounded-tr-lg sm:rounded-tr-lg xl:rounded-tl-lg xl:rounded-bl-lg lg:rounded-tl-lg lg:rounded-bl-lg md:rounded-tl-lg sm:rounded-tl-lg xl:w-4/5 lg:w-4/5 md:w-full sm:w-full xl:h-14 lg:h-14 md:h-12 sm:h-12 bg-darkgray xl:col-start-1 xl:col-end-2 xl:row-start-1 xl:row-end-1 lg:col-start-1 lg:col-end-2 md:col-start-1 md:col-end-4 md:row-start-1 md:row-end-2 sm:col-start-1 sm:col-end-4 sm:row-start-1 sm:row-end-2">
                                    <div
                                        class="p-1 overflow-x-auto border-b-0 border-r-0 rounded-lg xl:whitespace-normal lg:whitespace-normal md:whitespace-nowrap sm:whitespace-nowrap whitespace-nowrap xl:border-r-4 xl:border-b-0 lg:border-r-4 lg:border-b-0 md:border-r-0 md:border-b-0 sm:border-r-0 sm:border-b-0 arrival-depature-container border-lightgray/70 xl:bg-darkgray lg:bg-darkgray md:bg-dark/40 sm:bg-dark/40 bg-dark/40 xl:mx-0 lg:mx-0 md:mx-4 sm:mx-4 xl:rounded-none lg:rounded-none md:rounded-lg sm:rounded-lg">
                                        <span v-for="(key, val, index) of item.railways">
                                            <span v-if="val == 0">{{ key.depatureCity }}

                                            </span>
                                            <i class=' bx bxs-right-arrow-alt'></i>
                                            {{ key.arivalCity }}{{ index }}
                                        </span>
                                    </div>
                                </td>
                                <!--Second td/Km-->
                                <td
                                    class="grid items-center w-full col-start-1 col-end-2 row-start-2 row-end-2 text-center rounded-bl-lg h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:rounded-bl-none lg:rounded-bl-none md:rounded-bl-lg sm:rounded-bl-lg xl:w-1/12 lg:w-1/12 md:w-full sm:w-full bg-darkgray xl:col-start-2 xl:col-end-3 xl:row-start-1 xl:row-end-1 lg:col-start-2 lg:col-end-3 md:col-start-1 md:col-end-2 md:row-start-2 md:row-end-2 sm:col-start-1 sm:col-end-2 sm:row-start-2 sm:row-end-2">
                                    <div
                                        class="text-center border-r-4 km-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70">
                                        {{ item.km }} km
                                    </div>
                                </td>
                                <!--Third td/Ár-->
                                <td
                                    class="grid items-center w-full col-start-2 col-end-3 row-start-2 row-end-2 text-center h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:w-1/12 lg:w-1/12 md:w-full sm:w-full bg-darkgray xl:col-start-3 xl:col-end-4 xl:row-start-1 xl:row-end-1 lg:col-start-3 lg:col-end-4 md:col-start-2 md:col-end-3 md:row-start-2 md:row-end-2 sm:col-start-2 sm:col-end-3 sm:row-start-2 sm:row-end-2">
                                    <div
                                        class="border-r-4 price-container xl:border-lightgray/70 lg:border-lightgray/70 md:border-lightgray/70">
                                        {{ item.price }} Ft
                                    </div>
                                </td>
                                <!--Fourth td/Vásárlás-->
                                <td
                                    class="grid items-center w-full col-start-3 col-end-4 row-start-2 row-end-2 font-bold text-center text-white rounded-br-lg cursor-pointer h-9 xl:h-14 lg:h-14 md:h-9 sm:h-9 xl:table-cell lg:table-cell md:grid sm:gird xl:rounded-tr-lg xl:rounded-br-lg lg:rounded-tr-lg lg:rounded-br-lg md:rounded-br-lg sm:rounded-br-lg xl:w-1/6 lg:w-1/6 md:w-full sm:w-full font-sm bg-darkgray xl:col-start-4 xl:col-end-5 xl:row-start-1 xl:row-end-1 lg:col-start-4 lg:col-end-5 lg:row-start-1 lg:row-end-2 md:col-start-3 md:col-end-4 md:row-start-2 md:row-end-2 sm:col-start-3 sm:col-end-4 sm:row-start-2 sm:row-end-2">
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
        class="z-10 w-full lower-conent-main-container bg-[url('/public/pictures/admintestbg.jpg')] bg-cover bg-no-repeat bg-fixed pb-20 font-mainfont">
        <div
            class="grid p-5 m-auto xl:p-5 lg:p-2 md:p-10 sm:p-10 xl:w-full xl:grid-cols-8 xl:grid-rows-1 lg:w-full lg:grid-cols-6 lg:grid-rows-1 lower-conent-container">
            <div
                class="flex grid items-center p-3 m-2 duration-200 ease-in-out border-4 rounded-lg xl:grid-cols-1 xl:col-start-1 xl:col-end-6 xl:grid-rows-2 lg:col-start-1 lg:col-end-4 toolbox bg-darkgray hover:bg-dark/50 backdrop-blur-sm border-lightgray text-lightgray">
                <div
                    class="row-start-1 row-end-2 p-4 text-sm text-left border-b-2 xl:text-2xl lg:text-xl md:text-lg sm:text-base technology-paragraph border-lightgray">
                    <span class="pl-1 border-l-4 h-min w-min border-lightgray">Ez</span> a projekt azért jött létre
                    ,hogy
                    bemutassuk munkaszínvonalunk és tudástárunkat. <br>
                    Az oldal lényege, hogy két kiválaszott város között az összes lehetséges útvonalat megtekinthessük a
                    részleteikkel együtt.
                    Frontend fejlesztő, Soltész Dávid. Backend fejlesztő, Plachi Szilárd.
                </div>
                <div
                    class="flex flex-wrap row-start-2 row-end-2 p-3 place-content-center xl:justify-center lg:justify-center md:justify-center sm:justify-around technology-icons">
                    <div v-for="img in Iamges"
                        class="w-16 p-2 mx-3 mb-2 rounded-lg xl:w-24 lg:w-24 md:w-20 sm:w-24 h-min bg-lightgray/20">
                        <div class="w-12 h-12 p-2 bg-center bg-no-repeat bg-contain xl:w-20 xl:h-20 lg:w-20 lg:h-20 md:w-16 md:h-16 sm:w-20 sm:h-20 icon "
                            v-bind:style="{ backgroundImage: 'url(/pictures/' + img + ')' }">
                        </div>
                    </div>
                </div>
            </div>
            <div
                class="grid grid-cols-1 grid-rows-2 p-3 m-2 duration-200 ease-in-out border-4 rounded-lg lg:grid-rows-2 md:grid-rows-1 sm:grid-rows-1 xl:grid-cols-2 xl:col-start-6 xl:col-end-9 xl:grid-rows-1 lg:col-start-4 lg:col-end-7 lg:grid-cols-1 md:grid-cols-2 sm:grid-cols-2 programers border-lightgray bg-darkgray hover:bg-dark/50 backdrop-blur-sm">
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
            DepatureCityID: 0,
            ArrivalCityID: 0,
            Range: 0,
            Flag: false,
            Iamges: ['.net.png', 'cracs.png', 'css.png', 'html.png', 'js.png', 'mysql.png', 'tailwind.png', 'vuejs.png'],
            TheadCildren: [],
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
                this.Range = this.Range + 50;
                await this.GetRailways();
            }
        },
        async Searchheandel() {

            this.Range = 0;
            this.Railways = []
            this.Flag = false;
            this.Reomovehint();
            await this.GetRailways()
        },
        async GetRailways() {
            console.log(this.ArrivalCityID);

            let response = await axios.post('/GetRoutes', {
                DepatureId: this.DepatureCityID,
                ArrivalId: this.ArrivalCityID,
                Range: this.Range

            })
            console.log(response);
            if (response.data.railways !== null) {
                this.Railways = [...this.Railways, ...response.data];
            }
        },
        setDepaturecity(id) {
            this.DepatureCityID = id;
            console.log(id);
        },
        setArrivalCity(id) {
            this.ArrivalCityID = id;
        },
        Reomovehint() {

            document.getElementById('hint').classList.add('main-loading-container');
            setTimeout(() => {
                this.Flag = true;
            }, 1);

        },
        Showhint() {
            if (this.Flag && this.Railways.length === 0) {

                this.Flag = false;
                document.getElementById('hint').classList.remove('main-loading-container');
            }
        },
        SetTeableChildresn() {
            let thead = document.getElementById("tableheader");
            let thedchilderns = [];
            for (const item of thead.children) {
                thedchilderns.push(item);
            }
            this.TheadCildren = thedchilderns;
        }


    },
    beforeMount() {
        this.getcities();
        onresize = (event) => {
            let thead = document.getElementById("tableheader");
            if (window.innerWidth < 1024 && thead.children.length > 3) {
                for (let i = 0; i < 3; i++) {
                    thead.lastChild.remove();
                }
            } else if (window.innerWidth > 1024 && thead.children.length < 3) {
                for (let i = 0; i < 4; i++) {
                    thead.appendChild(this.TheadCildren[i]);
                }
            }
        }

    },
    mounted: function () {
        this.SetTeableChildresn() 
    },
}
</script>

