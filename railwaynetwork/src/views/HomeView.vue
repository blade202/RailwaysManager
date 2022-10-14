<template>
    <div id="home">
        <TheNavbar />
        <div class="main-home-container">
        </div>
        <TheFooter />
    </div>
</template>

<script>
import axios from 'axios';
import TheFooter from '../components/TheFooter.vue';
import TheNavbar from '../components/TheNavbar.vue';

    export default{
    name: "Home",
    async created() {
        let response = await axios.get("User", {
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
            }
        });
        console.log(response);
    },
    components: { TheFooter, TheNavbar }
}
</script>
