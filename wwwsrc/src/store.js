import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    privateKeeps: [],
    vaults: [],
    user: {}
  },
  mutations: {
    setKeeps(state, keepData) {
      state.publicKeeps = keepData;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#region -- KEEPS --
    async addKeep({ commit, dispatch }, newKeep) {
      await api.post("keeps", newKeep);
      dispatch("getKeeps");
    },
    async getKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setKeeps", res.data);
    }

    //#endregion
  }
});
