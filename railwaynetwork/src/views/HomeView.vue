
<template>
    <div class="w-full h-screen min-h-full overflow-auto bg-fixed bg-no-repeat bg-cover bg-homebg" id="home">
        <div class="w-full main-home-container font-mainfont bg-darkgray ">
            <TheNavbar />
            <div class="absolute w-2/3 -translate-x-1/2 top-10 main-content-box left-1/2">
                <div
                    class="mb-5 text-4xl font-medium text-center title text-lightgray text-shadow-xl font-mainfont inner-shadow">
                    RailwaysNetwork
                </div>
                <div class="grid w-2/3 grid-cols-10 grid-rows-1 m-auto text-center searchbar">
                    <select v-model="DepatCityId" name="" id=""
                        class="col-start-1 col-end-5 p-2 pr-3 font-medium text-center rounded-tl-full rounded-bl-full outline-none text-md bg-darkgray text-lightgray">
                        <option>Válasszon járataink közül!</option>
                        <option v-for="item in Cities" :value="item.id">{{ item.cityName }}</option>
                    </select>
                    <select v-model="ArrivalCityId" name="" id=""
                        class="col-start-5 col-end-9 p-2 pr-3 font-medium text-center rounded-tr-full rounded-br-full outline-none text-md bg-darkgray text-lightgray">
                        <option class="rounded-xl">Válasszon járataink közül!</option>
                        <option v-for="item in Cities" :value="item.id" class="rounded-xl">{{ item.cityName }}</option>
                    </select>
                    <button @click="Searchheandel" class="col-start-9 col-end-10 text-lightgray">
                        <i
                            class='px-3 text-2xl font-medium transition duration-200 ease-in-out border-2 rounded-lg bx bx-search border-darkgray hover:bg-darkgray'></i>
                    </button>
                </div>
                <div id="table" class="w-full pb-3 mt-5 overflow-scroll table-box scrollbar-hide max-h-128">
                    <table
                        class="border-separate rounded-lg border-spacing-y-4 bg-transparent/40 backdrop-blur-sm pr-7 pl-7">
                        <tr class="sticky top-0 font-medium rounded-lg bg-lightgray text-darkgray">
                            <th class="w-4/5 p-3 rounded-bl-xl">Állomások</th>
                            <th class="w-1/12">Távolság</th>
                            <th class="w-1/12">Ár</th>
                            <th class="w-1/6 p-3 rounded-br-xl">Foglalás</th>
                        </tr>
                        <tbody class=" bg-transparent/40 text-lightgray">
                            <tr v-for="item in Railways">
                                <td  class="w-4/5 p-2 text-center rounded-tl-full rounded-bl-full bg-darkgray">
                                    <span v-for="(key,val,index) of item.railways">
                                        <span v-if="val == 0">
                                            {{key.depatureCity}}
                                        </span>
                                        ->{{key.arivalCity}}
                                        {{index}}
                                    </span> 
                                </td>
                                <td class="w-1/12 text-center">
                                    {{ item.km }} km.
                                </td>
                                <td class="w-1/12 text-center ">
                                    {{ item.price }} Ft.
                                </td>
                                <td
                                    class="w-1/6 font-bold text-center text-white rounded-tr-full rounded-br-full cursor-pointer font-sm ">
                                    Vásárlás
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div
                    class="grid w-full grid-cols-5 grid-rows-1 p-5 text-center text-lightgray infobbox-conatainer mt-9">
                    <div
                        class="col-start-1 col-end-4 p-10 m-2 text-xl font-bold text-center border-4 rounded-lg infobox border-darkgray bg-transparent/40 backdrop-blur-sm">
                        Üdvözöljök a RailwaysNetwork olalán!
                        Ez a projekt azért jött létre, hogy bemutassuk a szakmai tudástárunkat és munkaszínvonalunkat.
                        További munkáinkért kérjük látogasson el a GitHub fiókunk oldalára! <br>
                        Frontend Fejlesztő, Soltész Dávid. <br> Backend fejlesztő, Plachi Szilárd.
                    </div>
                    <div
                        class="grid grid-cols-2 col-start-4 col-end-6 grid-rows-1 p-5 m-2 text-center border-4 rounded-lg contacts border-darkgray text-lightgray bg-transparent/40 backdrop-blur-sm">
                        <div class="col-start-1 col-end-2 text-left border-r-2 backend-developer border-lightgray">
                            <span class="font-bold border-b-2 contacts-name border-darkgray/80">Plachi
                                Szilárd</span><br>
                            <span class="contacts-phone">Telefon:<br>+36 20 4388850</span><br>
                            <span class="contacts-email">Email:<br>plachiszilard@gmail.com</span>
                        </div>
                        <div class="col-start-2 col-end-2 pl-2 text-left frontend-developer">
                            <span class="mb-2 font-bold border-b-2 contacts-name border-darkgray/80">SoltészDávid</span><br>
                            <span class="contacts-phone">Telefon:<br> +36 20 4388850</span><br>
                            <span class="contacts-email">Email:<br>solteszdavid@gmail.com</span>
                        </div>
                    </div>
                </div>
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
            Cities: null,
            Railways: [],
            DepatCityId: 0,
            ArrivalCityId: 0,
            range: 0
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
            console.log(div.offsetHeight);
            console.log(div.scrollTop);
            console.log(div.scrollHeight);
            if (div.offsetHeight + div.scrollTop >= div.scrollHeight) {
                this.range = this.range + 50;
                await this.GetRailways();
            }
        },
       async Searchheandel()
        {
            
            this.range=0;
            this.Railways=[]
            await this.GetRailways()
        },
        async GetRailways() {
            console.log(this.ArrivalCityId);

            let response=await axios.post('/GetRoutes',{
                DepatureId:this.DepatCityId,
                ArrivalId:this.ArrivalCityId,
                range:this.range
            })
             document.getElementById('table').addEventListener('scroll', this.handleScroll);
            this.Railways=[...this.Railways,...response.data];
        },
        setDepaturecity(id) {
            this.DepatCityId = id;
            console.log(id);
        },
        setArrivalCity(id) {
            this.ArrivalCityId = id;
        }
    },
    beforeMount() {
        this.getcities();
    }

}
</script>

