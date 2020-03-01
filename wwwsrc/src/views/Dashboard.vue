<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 d-flex flex-column align-items-center">
        <h2>Welcome to your Dashboard!</h2>
        <h5>
          Here you can see the keeps you've created OR create and view your
          Vaults.
        </h5>
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
    <div class="vaultSection">
      <div class="row">
        <div class="col-2 fakeCard" v-for="vault in vaults" :key="vault.id">
          <router-link :to="{ name: 'singlevault', params: { vaultId: vault.id } }">
            <h5>{{ vault.name }}</h5>
          </router-link>
          <p>{{ vault.description }}</p>
        </div>
        <!-- <vault  :vaultData="vault" /> -->
      </div>
    </div>
    <div class="row yourKeeps-section">
      <div class="card-columns">
        <keep v-for="keep in myKeeps" :key="keep.id" :keepData="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "@/components/Vault.vue";
import Keep from "@/components/Keep.vue";
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
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    myKeeps() {
      return this.$store.state.myKeeps;
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
    Vault,
    Keep
  }
};
</script>

<style scoped>
.vaultSection {
  border: 3pt solid red;
  height: 40vh;
  overflow-x: auto;
  max-width: 100%;
  margin: 10pt 0 10pt 0;
}
.vaultSection .row {
  width: 300%;
  padding-left: 10pt;
}
.fakeCard {
  border: 1pt solid black;
  margin: 5pt;
  max-width: 18em;
  padding: 10pt;
}
.yourKeeps-section {
  height: 100vh;
  overflow-y: scroll;
}
</style>
