<template>
    <div class="editor">
        <div class="form-group">
            <label>start</label>
            <Datepicker name="start" input-class="form-control" :format="DatePickerFormat" :value="start" @input="updateEventStart"></Datepicker>
        </div>
        <div class="form-group">
            <label>end</label>
            <Datepicker name="end" input-class="form-control" :format="DatePickerFormat" :value="end" @input="updateEventEnd"></Datepicker>
        </div>
        <div class="form-group">
            <label>title</label>
            <input type="text" name="title" class="form-control" :value="title" @input="updateEventTitle">
        </div>
        <div class="l-button-group">
            <router-link tag="button" class="btn btn-default btn" to="/calendar">Cancel</router-link>
            <button class="btn btn-success btn" v-if="$route.params.mode == 'create'" v-on:click="eventCreate">Create</button>
            <button class="btn btn-success btn" v-if="$route.params.mode == 'update'" v-on:click="eventUpdate">Update</button>
        </div>
    </div>
</template>

<script>
import Datepicker from 'vuejs-datepicker';
import moment from 'moment'
import { mapState } from 'vuex'

export default {
    components: {
        Datepicker
    },
    computed: mapState({
        id   : state => state.event.id,
        start: state => (state.event.start || state.event.end).format("YYYY-MM-DD"),
        end  : state => (state.event.end || state.event.start).format("YYYY-MM-DD"),
        title: state => state.event.title
    }),
    data() {
        return {
            DatePickerFormat: 'yyyy-MM-dd',
        }
    },
    methods: {
        updateEventStart(datetime) {
            this.$store.dispatch('updateEventStart', moment(datetime))
        },
        updateEventEnd(datetime) {
            this.$store.dispatch('updateEventEnd', moment(datetime))
        },
        updateEventTitle(e) {
            this.$store.dispatch('updateEventTitle', e.target.value)
        },
        eventCreate() {
            this.$store
                .dispatch('create')
                .then(res => {
                    this.$router.push('/calendar')
                })
        },
        eventUpdate() {
            this.$store
                .dispatch('update')
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