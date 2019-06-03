<template>
    <div class="editor">
        <div class="form-group">
            <label>start</label>
            <div>{{ start }}</div>
        </div>
        <div class="form-group">
            <label>end</label>
            <div>{{ end }}</div>
        </div>
        <div class="form-group">
            <label>title</label>
            <div>{{ title }}</div>
        </div>
        <div class="l-button-group">
            <router-link tag="button" class="btn btn-default btn" to="/calendar">Back</router-link>
            <button class="btn btn-danger btn" v-on:click="eventDelete">Delete</button>
            <router-link tag="button" class="btn btn-success btn" to="/editor/update">Edit</router-link>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
    computed: mapState({
        id   : state => state.event.id,
        start: state => (state.event.start || state.event.end).format("YYYY-MM-DD"),
        end  : state => (state.event.end || state.event.start).format("YYYY-MM-DD"),
        title: state => state.event.title
    }),
    methods: {
        eventDelete() {
            this.$store
                .dispatch('delete')
                .then(res => {
                    this.$router.push('/calendar')
                })
        }
    }
}
</script>

<style scoped>
div.l-button-group {
    max-width: 280px;
    text-align: right;
}
</style>