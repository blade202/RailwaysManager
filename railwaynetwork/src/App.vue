<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>


<template>
<RouterView />
</template>
<script>
export default{
    name:"home",
    data() {
        return{
            user:null
        }
    }
   
}
</script>

