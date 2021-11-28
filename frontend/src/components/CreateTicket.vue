<template>
  <div>
    <b-button v-b-modal.modal-1>Создать новый тикет</b-button>
    <b-modal id="modal-1" title="Создание нового тиккета" @ok="createTicket">
      <b-container fluid>
        <b-row >
          <b-col sm="5">
            <label>
              Описание :
            </label>
          </b-col>
          <b-col sm="9">
            <b-form-input type="text"
                          v-model="ticket.description"
                          :state="validateDescription">
            </b-form-input>
          </b-col>
        </b-row>
        <b-row >
          <b-col sm="5">
            <label>
              Инициатор :
            </label>
          </b-col>
          <b-col sm="9">
            <b-form-select v-model="ticket.initiatorId"
                           :options="listUsers"
                           value-field="id"
                           text-field="name"
                           :state="validateInitiator"
            ></b-form-select>
          </b-col>
        </b-row>
        <b-row >
          <b-col sm="9">
            <label>
              Наименование проекта :
            </label>
          </b-col>
          <b-col sm="9">
            <b-form-select v-model="ticket.projectId"
                           :options="listProjects"
                           value-field="id"
                           text-field="name"
                           :state="validateProject"
            ></b-form-select>
          </b-col>
        </b-row>
        <b-row >
          <b-col sm="5">
            <label>
              Статус :
            </label>
          </b-col>
          <b-col sm="9">
            <b-form-select v-model="ticket.status"
                           :options="options"
                           :state="validateStatus"
            ></b-form-select>
          </b-col>
        </b-row>
        <b-row >
          <b-col sm="5">
            <label>
              Дата закрытия :
            </label>
          </b-col>
          <b-col sm="9">
            <b-form-input type="datetime-local" v-model="ticket.dateOfClosing"></b-form-input>
          </b-col>
        </b-row>
        <b-row >
          <b-col sm="5">
            <label>
              Кем закрыт :
            </label>
          </b-col>
          <b-col sm="9">
              <b-form-select v-model="ticket.executorId"
                             :options="listUsers"
                             value-field="id"
                             text-field="name"
              ></b-form-select>
          </b-col>
        </b-row>
      </b-container>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "CreateTicket",
  props:{
    listUsers: {
      type: Array
    },
    listProjects: {
      type: Array
    },
    options:{
      type: Array
    }
  },
  methods:{
    createTicket: async function (){
      await axios.post('/tickets',this.ticket);
      this.$emit("ticketCreated");
    },
  },
  computed:{
    validateDescription: function (){
      return this.ticket.description.length > 0
    },
    validateInitiator: function (){
      return !!this.ticket.initiatorId
    },
    validateProject: function (){
      return !!this.ticket.projectId
    },
    validateStatus: function (){
      return this.ticket.status !== null
    }
  },

  data() {
    return {
      isClick: false,
      ticket: {
        description:'',
        initiatorId: null,
        projectId: 0,
        status: null,
        dateOfClosing: null,
        executorId: null
      }
    }
  }
}
</script>

<style scoped>

</style>