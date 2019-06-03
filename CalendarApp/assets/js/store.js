import axios from 'axios';
export default {
    state: {
        event: {
            id   : null,
            start: null,
            end  : null,
            title: null
        }
    },
    mutations: {
        setEventId(state, id) {
            state.event.id = id
        },
        setEventStart(state, start) {
            state.event.start = start
        },
        setEventEnd(state, end) {
            state.event.end = end
        },
        setEventTitle(state, title) {
            state.event.title = title
        }
    },
    actions: {
        /**
         * 新規イベント作成
         * @param {*} context 
         * @param {*} start 
         * @param {*} end 
         * @param {*} title 
         */
        createEvent(context, start, end, title) {
            context.commit('setEventId', null)
            context.commit('setEventStart', start)
            context.commit('setEventEnd'  , end)
            context.commit('setEventTitle', title)
        },
        /**
         * 既存イベント選択
         * @param {*} context 
         * @param {*} event 
         */
        selectEvent(context, event) {
            context.commit('setEventId', event.id)
            context.commit('setEventStart', event.start)
            context.commit('setEventEnd'  , event.end)
            context.commit('setEventTitle', event.title)
        },
        /**
         * イベント開始日付を設定
         * @param {*} context 
         * @param {*} e 
         */
        updateEventStart(context, start) {
            context.commit('setEventStart', start)
        },
        /**
         * イベント終了日付を設定
         * @param {*} context 
         * @param {*} e 
         */
        updateEventEnd(context, end) {
            context.commit('setEventEnd', end)
        },
        /**
         * イベントタイトルを設定
         * @param {*} context 
         * @param {*} e 
         */
        updateEventTitle(context, title) {
            context.commit('setEventTitle', title)
        },
        /**
         * 新規イベントを登録
         * @param {*} context 
         */
        create(context) {
            let params = new URLSearchParams()
                params.append('start', context.state.event.start.format("YYYY-MM-DD"))
                params.append('end', context.state.event.end.format("YYYY-MM-DD"))
                params.append('title', context.state.event.title)
  
            return axios.post('/schedule/create', params)
        },
        /**
         * 既存イベントを更新
         * @param {*} context 
         */
        update(context) {
            let params = new URLSearchParams()
                params.append('id', context.state.event.id)
                params.append('start', context.state.event.start.format("YYYY-MM-DD"))
                params.append('end', context.state.event.end.format("YYYY-MM-DD"))
                params.append('title', context.state.event.title)
  
            return axios.post('/schedule/update', params)
        },
        /**
         * 既存イベントを削除
         * @param {*} context 
         */
        delete(context) {
            let params = new URLSearchParams()
                params.append('id', context.state.event.id)
      
            return axios.post('/schedule/delete', params)
        }
    }
}