import CalendarComponent from './components/calendar.vue';
import DetailComponent from './components/detail.vue';
import EditorComponent from './components/editor.vue';

export default {
    mode  : 'hash',
    routes: [
        {
            name: 'editor',
            path: '/editor/:mode',
            component: EditorComponent
        },
        {
            name: 'detail',
            path: '/detail',
            component: DetailComponent
        },
        {
            name: 'calendar',
            path: '/calendar',
            component: CalendarComponent
        },
        {
            name: 'notfound',
            path: '*',
            component: CalendarComponent
        }
    ]
}