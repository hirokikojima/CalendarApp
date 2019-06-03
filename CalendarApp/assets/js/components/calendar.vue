<template>
    <FullCalendar :config="config" :events="events" @event-selected="eventSelected" @day-click="dayClick" @view-render="viewRender" />
</template>

<script>
import axios from 'axios';
import { FullCalendar } from 'vue-full-calendar'

export default {
    components: {
        FullCalendar
    },
    data() {
        return {
            events: [],
            config: { 
                defaultView: 'month',
                header: {
                    left  : 'prev,next',
                    center: 'title',
                    right : ''
                }
            }
        }
    },
    methods: {
        dayClick(date, jsEvent, view) {
            this.$store.dispatch('createEvent', date, date, '')
            this.$router.push('/editor/create')
        },
        eventSelected(event, jsEvent, view) {
            this.$store.dispatch('selectEvent', event)
            this.$router.push('/detail')
        },
        viewRender(view, element) {
            var start = view.start.format('YYYY-MM-DD'),
                end   = view.end.format('YYYY-MM-DD')

            axios
                .get('/schedule/fetch?start=' + start + '&end=' + end)
                .then(response => {
                    this.events = response.data.schedules
                })
        }
    }
}
</script>