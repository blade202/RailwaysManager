<template>
    <TheNavbar />
    <div class="main-admin-container">
        <div class="admin-content-container">
            <div class="absolute w-3/4 m-auto navbar top-20">
                <div class="cities">
                    <button @click="showcities">
                        cities
                    </button>
                </div>
                <div class="railways">
                    <button @click="showrailways">
                        railways
                    </button>
                </div>
            </div>
            <div id="admin-table" class="overflow-scroll scrollbar-hide max-h-128">
                <table class="border-separate rounded-lg border-spacing-y-4 bg-transparent/40 backdrop-blur-sm">
                    <tr class="sticky top-0">
                        <th v-for="header in tableheaders" class="">{{header}}</th>
                    </tr>
                    <tbody class="">
                        <tr class="">
                            <td class="">
                                <div class="">

                                </div>
                            </td>
                            <td class="">
                                <div class="">

                                </div>
                            </td>
                            <td class="">
                                <div class="">

                                </div>
                            </td>
                            <td class="">
                                <div class="">

                                </div>
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
            tableheaders:[],
            cities:[],
            railways:[],
        }
    },
    methods:{
        showcities(){
            this.tableheaders=["városok","módosítás","törlés"]
        },
        showrailways(){
            this.tableheaders=["induló állomás", "érkező állomás","km", "módosítás", "törlés"]
        }
    }

}
</script>