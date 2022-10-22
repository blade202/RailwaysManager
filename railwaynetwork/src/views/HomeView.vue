<template>
    <div id="home">
        <TheNavbar />
        <div class="main-home-container">
            <div class="upper-content-box">
                <div class="title">
                  <h1 v-if="user">{{user.username}}</h1>      
                </div>
                <div class="searchbar">

                </div>
            </div>
            <div class="table-box">
                
            </div>
        </div>
        <TheFooter />
    </div>
</template>

<script>
import axios from 'axios';
import TheFooter from '../components/TheFooter.vue';
import TheNavbar from '../components/TheNavbar.vue';
import {mapGetters} from 'vuex';
import { computed } from '@vue/reactivity';

    export default{
    name: "Home",
    async created() {
        let response = await axios.get("User");
        console.log(response);
    },
    components: { 
        TheFooter, TheNavbar 
    },
    computed:{
        ...mapGetters(['user'])
    }
}
</script>
