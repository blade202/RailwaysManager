<template>
    <transition name="modal-animation">
        <div v-show="modalActive" class="modal">
            <transition name="modal-animation-inner">
                <div v-show="modalActive" class="modal-inner">
                    <slot />
                    <button
                        class="p-1 px-3 font-semibold transition duration-200 ease-in-out border-2 border-solid rounded-md bg-lightgray text-darkgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray"
                        @click="closeDeleteModal">Mégsem</button>
                        <button
                        class="p-1 px-3 font-medium transition duration-200 ease-in-out border-2 border-solid rounded-md border-lightgray text-lightgray drop-shadow-md font-mainfont hover:shadow-xl shadow-lightgray hover:bg-lightgray hover:text-darkgray hover:font-semibold"
                        @click="DeletCities()">Törlés</button>
                        <button/>
                </div>
            </transition>
        </div>
    </transition>
</template>

<script>
export default {
    props: ["modalActive"],
    setup(props, { emit }) {
        const closeDeleteModal = () => {
            emit('closeDeleteModal')
        };

        return { closeDeleteModal };
    }
}
</script>

<style lang="scss" scoped>
.modal-animation-enter-active,
.modal-animation-leave-active {
    transition: opacity 0.2s cubic-bezier(0.52, 0.02, 0.19, 1.02);
}

.modal-animation-enter-from,
.modal-animation-leave-to {
    opacity: 0;
}

.modal-animation-inner-enter-active {
    transition: opacity all 0.2s cubic-bezier(0.52, 0.02, 0.19, 1.02) 0.15s;
}

.modal-animation-inner-leave-active {
    transition: opacity all 0.2s cubic-bezier(0.52, 0.02, 0.19, 1.02);
}

.modal-animation-inner-enter-from {
    opacity: 0;
    transform: scale(0.8);
}

.modal-animation-inner-leave-to {
    transform: scale(0.8);
}

</style>