<template>
  <div>
    <template>
      <b-form inline>
        <b-form-datepicker
          reset-button
          v-model="sorting.date"
          placeholder="Выберите дату"
          :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit', weekday: 'short' }">
        </b-form-datepicker>
        <template>
          <b-form-select v-model="sorting.status"
                         :options="optionsWithNull"
                         reset-button
          ></b-form-select>
        </template>
        <b-form-select v-model="sorting.initiator"
                       :options="listInitiators"
                       value-field="id"
                       text-field="name"
        ></b-form-select>
      </b-form>
    </template>
    <b-table striped hover :items="listTickets" :fields="fields">
      <template #cell(V)>
        <b-form-checkbox/>
      </template>
      <template #cell(dateOfCreation)="row">
        <b-form-datepicker
          v-model="row.item.dateOfCreation"
          :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit', weekday: 'short' }"
          disabled>
        </b-form-datepicker>
      </template>
      <template #cell(dateOfClosing)="row">
        <b-form-datepicker
          v-model="row.item.dateOfClosing"
          :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit', weekday: 'short' }"
        ></b-form-datepicker>
      </template>
      <template #cell(initiatorId)="row">
        <b-form-select v-model="row.item.initiatorId"
                       :options="listUsers"
                       value-field="id"
                       text-field="name"
        ></b-form-select>
      </template>
      <template #cell(executorId)="row">
        <b-form-select v-model="row.item.executorId"
                       :options="listUsers"
                       value-field="id"
                       text-field="name"
        ></b-form-select>
      </template>
      <template #cell(projectId)="row">
        <b-form-select v-model="row.item.projectId"
                       :options="listProjects"
                       value-field="id"
                       text-field="name"
        ></b-form-select>
      </template>
      <template #cell(status)="row">
        <b-form-select v-model="row.item.status"
                       :options="options"
        ></b-form-select>
      </template>
    </b-table>
    <CreateTicket :list-users="listUsers" :list-projects="listProjects" :options="options" @ticketCreated="loadTickets"/>
  </div>
</template>

<script>
import axios from "axios";
import CreateTicket from "./CreateTicket";

export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  components:{
    CreateTicket
  },
  methods:{
    loadTickets: async function (){
      this.unWatchers.forEach((unWatch) =>{
        unWatch();
      })
      let response = await axios.get('/tickets', {params: this.sorting});
      this.listTickets = response.data;
      this.listTickets.forEach((x, index) => {

        const unwatch = this.$watch('listTickets.' + index, {
          handler: function(newValue) {
            this.onTicketChanged(newValue);
          },
          deep: true
        })
        this.unWatchers.push(unwatch);
      })
    },
    onTicketChanged: async function(ticket){
      await axios.put('/tickets/'+ ticket.id, ticket);
    },
  },
  watch:{
    sorting: {
      handler: function() {
        this.loadTickets();
      },
      deep: true
    }
  },
  async mounted() {
    await this.loadTickets();
    let response = await axios.get('/users');
    this.listUsers = response.data;
    response = await axios.get('/projects');
    this.listProjects = response.data;
    response = await axios.get('/initiators');
    this.listInitiators = response.data;
    this.listInitiators.push({id: null, name:"Выберите инициатора"});
  },
  computed:{
    optionsWithNull: function(){
      const result = this.options.slice();
      result.push({value: null, text: 'Выберите статус'});
      return result;
    }
  },
  data() {
    return {
      sorting:{
        date: null,
        status: null,
        initiator: null
      },
      unWatchers:[],
      form: {
        email: '',
        name: '',
        food: null,
        checked: []
      },
      show: true,
      listTickets:[],
      listUsers:[],
      listProjects:[],
      listInitiators:[],
      select: null,
      fields: [
        {
          key: 'V',
          sortable: false
        },
        {
          key: 'dateOfCreation',
          label:'Дата создания',
          sortable: true,

        },
        {
          key: 'description',
          label:'Описание',
          sortable: false
        },
        {
          key: 'initiatorId',
          label:'Инициатор',
          sortable: true
        },
        {
          key: 'projectId',
          label:'Наименование проекта',
          sortable: false
        },
        {
          key: 'status',
          label:'Статус',
          sortable: true
        },
        {
          key: 'dateOfClosing',
          label:'Дата закрытия',
          sortable: false
        },
        {
          key: 'executorId',
          label:'Кем закрыт',
          sortable: true
        }
      ],
      options: [
        { value: 0, text: 'Новый' },
        { value: 1, text: 'В работе' },
        { value: 2, text: 'Закрыт' }
      ],
    }
  }
}
</script>
