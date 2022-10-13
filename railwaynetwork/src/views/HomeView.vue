<template>
    <div id="home">
        <div class="main-home-container">
            <div class="navbar">
                Lorem ipsum, dolor sit amet consectetur adipisicing elit. Facere cumque aspernatur est voluptate debitis veniam perspiciatis repellat molestias temporibus? Ipsum, laborum omnis ratione hic alias perspiciatis provident doloremque fugit excepturi.
            </div>
            
        </div>
    </div>
</template>

<script>
import axios from 'axios';

    export default{
        name:'Home',
        async created(){
            let response =await axios.get('User',{
                headers: {
                    Authorization: 'Bearer ' +localStorage.getItem('token')
                }
            }
            );
            console.log(response)
        }
    }
</script>
