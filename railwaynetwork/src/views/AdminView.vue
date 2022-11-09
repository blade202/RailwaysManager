<template>
    <TheNavbar />
    <nav class="bg-white border-gray-200 px-2 mt-20 sm:px-4 py-2.5 rounded dark:bg-gray-900">
        <div class="container flex flex-wrap justify-between items-center mx-auto">
          <div class="hidden w-full md:block md:w-auto flex" id="navbar-default">
                <ul class="flex">
                    <li>
                        <a href="#"
                        class="block py-2 pr-4 pl-3 text-gray-700 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-gray-400 md:dark:hover:text-white dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Contact</a>
                    </li>
                    <li>
                        <a href="#"
                        class="block py-2 pr-4 pl-3 text-gray-700 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-gray-400 md:dark:hover:text-white dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Contact</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <table>
        <thead>
            <tr>
                <td>
                    asd
                </td>
                <td>
                    asd
                </td>
                <td>
                    asd
                </td>
            </tr> 
        </thead>
    </table>
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

}
</script>