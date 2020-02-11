<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 d-flex flex-column align-items-center">
        <h2>Welcome to your Dashboard!</h2>
        <h5>Here you can see the keeps you've created OR create and view your Vaults.</h5>
      </div>
      <div class="col-12">
        <button class="btn btn-success" type="button" @click="toggleForm">Create a Vault</button>
      </div>
      <div class="col-12" v-if="showForm">
        <div id="form">
          <form class="form-group" @submit.prevent="addVault">
            <div>
              Name:
              <input
                v-model="newVault.name"
                class="form-control"
                required
                type="text"
                placeholder="Name of vault"
              />
            </div>
            <div>
              Description:
              <textarea
                v-model="newVault.description"
                class="form-control"
                cols="30"
                rows="3"
                maxlength="300"
                placeholder="What's your vault about"
                required
              ></textarea>
            </div>
            <button class="btn btn-success" type="submit">Submit Vault</button>
          </form>
        </div>
      </div>
    </div>
    <div class="row card-section">
      <div class="card-deck">
        <vault v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
      </div>
    </div>
    <div class="row yourKeeps-section"></div>
  </div>
</template>

<script>
import Vault from "@/components/Vault.vue";
export default {
  data() {
    return {
      showForm: false,
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    toggleForm() {
      if (this.showForm == false) {
        this.showForm = true;
      } else if (this.showForm == true) {
        this.showForm = false;
      }
    },
    addVault() {
      let vault = {
        Name: this.newVault.name,
        Description: this.newVault.description
      };
      this.$store.dispatch("addVault", vault);
      this.newVault = { name: "", description: "" };
    }
  },
  components: {
    Vault
  }
};
</script>

<style></style>
