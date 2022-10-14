<template>
    <div id="home">
        <div class="main-home-container">
        </div>
    </div>
    <TheFooter />
</template>

<script>
import axios from 'axios';
import TheFooter from '../components/TheFooter.vue';

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
    components: { TheFooter }
}
</script>
