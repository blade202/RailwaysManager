<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Registrtyvue from '../src/views/RegistryView.vue'
</script>


<template>
<RouterView />
</template>
<script>
    export default{
        name:'App',
        components:{
            Registrtyvue
        }
    }
</script>

