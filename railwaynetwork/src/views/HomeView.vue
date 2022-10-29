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
                    <select v-model="DepatCityId" name="" id=""
                        class="p-2 font-medium text-center rounded-tl-full rounded-bl-full outline-none rounded- text-md bg-darkgray text-lightgray">
                        <option>Válasszon járataink közül!</option>
                        <option v-for="item in Cities"  :value="item.id"   >{{ item.cityName }}</option>
                    </select>
                    <select v-model="ArrivalCityId" name="" id=""
                        class="p-2 font-medium text-center rounded-tr-full rounded-br-full outline-none text-md bg-darkgray text-lightgray">
                        <option>Válasszon járataink közül!</option>
                        <option v-for="item in Cities" :value="item.id" >{{ item.cityName }}</option>
                    </select>
                    <button @click="Searchheandel">
                        keresés
                    </button>
                </div>
                <div id="table" class="pb-3 mt-5 overflow-scroll table-box scrollbar-hide min-h-min max-h-128">
                    <table class="border-separate rounded-lg border-spacing-y-2 bg-transparent/40 backdrop-blur-sm pr-7 pl-7">
                        <tr class="sticky top-0 font-medium rounded-lg bg-lightgray text-darkgray">
                            <th class="w-4/5 p-3 rounded-bl-xl">Állomások</th>
                            <th class="w-1/12">Távolság</th>
                            <th class="w-1/12">Ár</th>
                            <th class="w-1/6 p-3 rounded-br-xl">Foglalás</th>
                        </tr>
                        <tbody class=" bg-transparent/40 text-lightgray">
                            <tr v-for="item in Railways">
                                <td  class="w-4/5 p-2 text-center rounded-tl-full rounded-bl-full bg-darkgray">
                                    <span v-for="railway in item.railways" >{{railway.depatureCity}}->{{railway.arivalCity}}</span> 
                                </td>
                                <td class="w-1/12 text-center bg-darkgray">
                                    {{item.km}}
                                </td>
                                <td class="w-1/12 text-center bg-darkgray">
                                    {{item.price}}
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
            Cities: null,
            Railways:[],
            DepatCityId:0,
            ArrivalCityId:0,
            range:0
        }
    },
    methods: {
        async getcities() {
            let response = await axios.get('/getCities');
            this.Cities = response.data;
            document.getElementById('table').addEventListener("scroll",this.handleScroll);
        },
       async handleScroll () {
        let div = document.getElementById('table');
        console.log(div.offsetHeight);
        console.log(div.scrollTop);
        console.log(div.scrollHeight);
        if (div.offsetHeight+div.scrollTop>=div.scrollHeight) {
            this.range=this.range+50;
            await this.GetRailways();
        }
        },
        Searchheandel()
        {
            this.range=0;
            this.Railways=[]
            this.GetRailways()
        },
        async GetRailways() 
        { 
            console.log(this.ArrivalCityId);
            let response=await axios.post('/GetRoutes',{
                DepatureId:this.DepatCityId,
                ArrivalId:this.ArrivalCityId,
                range:this.range
            
            })
         document.getElementById('table').addEventListener('scroll', this.handleScroll);
            this.Railways=[...this.Railways,...response.data];
            
            console.log(this.Railways)
        },
        setDepaturecity(id)
        {
            this.DepatCityId=id;
            console.log(id);
        },
        setArrivalCity(id)
        {
            this.ArrivalCityId=id;
        }
    },
    beforeMount() {
        this.getcities();
    }

}
</script>
