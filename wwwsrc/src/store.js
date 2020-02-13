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
    myKeeps: [],
    vaults: [],
    vaultKeeps: [],
    activeVault: {},
    activeKeep: {},
    user: {}
  },
  mutations: {
    setKeeps(state, keepData) {
      console.log(keepData);
      state.publicKeeps = keepData;
    },
    setVaults(state, vaultData) {
      console.log(vaultData);
      state.vaults = vaultData;
    },
    setMyKeeps(state, keepData) {
      console.log(keepData);
      state.myKeeps = keepData;
    },
    setActiveVault(state, vaultData) {
      console.log("this should be active vault", vaultData);
      state.activeVault = vaultData;
    },
    setActiveKeep(state, keepData) {
      console.log("this should be active keep", keepData);
      state.activeKeep = keepData;
    },
    setVaultKeeps(state, vaultKeepData) {
      console.log(vaultKeepData);
      state.vaultKeeps = vaultKeepData;
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
    },
    async getMyKeeps({ commit, dispatch }) {
      let res = await api.get("keeps/User");
      commit("setMyKeeps", res.data);
    },
    async getKeepById({ commit, dispatch }, keepId) {
      let res = await api.get("keeps/" + keepId);
      commit("setActiveKeep", res.data);
    },
    async getKeepsByVaultId({ commit, dispatch }, vaultId) {
      let res = await api.get("vaults/" + vaultId + "/keeps");
      commit("setMyKeeps", res.data);
      console.log("this is the data from keepbyvaultid", res.data);
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      await api.delete("keeps/" + keepId);
      dispatch("getKeeps");
      router.push({ name: "home" });
    },

    //#endregion

    //#region -- VAULTS --
    async addVault({ commit, dispatch }, newVault) {
      await api.post("vaults", newVault);
      dispatch("getVaults");
    },
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("setVaults", res.data);
    },
    async getVaultById({ commit, dispatch }, vaultId) {
      let res = await api.get("vaults/" + vaultId);
      commit("setActiveVault", res.data);
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      await api.delete("vaults/" + vaultId);
      dispatch("getVaults");
      router.push({ name: "dashboard" });
    },

    //#endregion

    //#region -- SOCIAL --
    async editKeep({ commit, dispatch }, updatedKeep) {
      await api.put("keeps/keepview", updatedKeep);
      await dispatch("getKeepById", updatedKeep.id);
      dispatch("getKeeps");
    },
    async editKeepKeeps({ commit, dispatch }, updatedKeep) {
      // debugger;
      await api.put("keeps/keepkeeps", updatedKeep);
      dispatch("getKeeps");
    },

    //#endregion

    //#region -- VAULTKEEPS --
    async createVaultKeep({ commit, dispatch }, vaultKeep) {
      await api.post("vaultkeeps", vaultKeep);
      dispatch("getKeeps");
      dispatch("getMyKeeps");
      dispatch("getVaultKeeps");
    },

    async getVaultKeeps({ commit, dispatch }) {
      let res = await api.get("vaultkeeps");
      commit("setVaultKeeps", res.data);
    }

    //#endregion
  }
});
