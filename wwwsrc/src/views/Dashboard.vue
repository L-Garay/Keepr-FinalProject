<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 d-flex flex-column align-items-center mt-2">
        <h2>Welcome to your Dashboard!</h2>
        <h5>
          Here you can see the keeps you've created OR create and view your
          Vaults.
        </h5>
      </div>
      <div class="col-12 d-flex justify-content-center">
        <button class="btn" type="button" @click="toggleForm">Create a Vault</button>
      </div>
      <div class="col-6 offset-3" v-if="showForm">
        <div class="d-flex justify-content-center" id="form">
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
            <div class="formBtn">
              <button class="btn submitBtn" type="submit">Submit Vault</button>
            </div>
          </form>
        </div>
      </div>
    </div>

    <div class="vaultSection">
      <div class="row">
        <div class="col-2 fakeCard" v-for="vault in vaults" :key="vault.id">
          <router-link :to="{ name: 'singlevault', params: { vaultId: vault.id } }">
            <h4>{{ vault.name }}</h4>
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
      this.toggleForm();
    }
  },
  components: {
    Vault,
    Keep
  }
};
</script>

<style scoped>
.dashboard {
  background-image: url("../assets/backgrounds/darkWall.jpg");
  background-position: center;
  background-size: cover;
  background-repeat: repeat-y;
  font-family: "Press Start 2P";
}
h2,
h5,
h4 {
  color: orange;
  text-shadow: 0 0 8px black;
}
p {
  text-shadow: 0 0 6px orange;
  color: black;
}
button {
  border: 1pt solid orange;
  color: orange;
  background-color: rgb(49, 49, 49);
}
button:hover {
  text-shadow: 0 0 5px orange;
  box-shadow: 0 0 15px orange;
  color: orange;
}
form {
  color: orange;
  text-shadow: 0 0 6px black;
}
form button {
  justify-self: center;
}
.formBtn {
  text-align: center;
  margin-top: 10pt;
}
.submitBtn {
  animation: neon 1.08s ease-in-out infinite alternate;
}
@keyframes neon {
  from {
    text-shadow: 0 0 20px rgba(252, 238, 52, 0.92),
      0 0 30px rgba(250, 191, 65, 0.774), 0 0 12px rgba(242, 132, 30, 0.945),
      0 0 21px rgba(245, 163, 12, 0.92), 0 0 34px rgba(242, 62, 30, 0.78),
      0 0 54px rgba(243, 113, 26, 0.92);
  }
  to {
    text-shadow: 0 0 20px rgba(252, 73, 41, 0.92),
      0 0 30px rgba(238, 84, 57, 0.34), 0 0 12px rgba(242, 97, 30, 0.52),
      0 0 21px rgba(245, 47, 12, 0.92), 0 0 34px rgba(245, 66, 12, 0.78),
      0 0 54px rgba(245, 39, 12, 0.92);
  }
}
.form-control {
  border: 1pt solid orange;
  background-color: rgb(46, 46, 46);
  color: white;
}
.vaultSection {
  /* box-shadow: 4pt 4pt 4pt black; */
  box-shadow: 0 0 20px orange;
  background-color: rgba(0, 0, 0, 0.541);
  height: 40vh;
  margin: 10pt 0 10pt 0;
  overflow-y: scroll;
  overflow-x: hidden;
}
.vaultSection .row {
  padding-left: 10pt;
  flex-wrap: wrap;
}
#video {
  position: fixed;
  right: 0;
  bottom: 0;
  max-width: 100%;
  max-height: 100%;
}
.fakeCard {
  text-align: center;
  background-color: rgba(63, 63, 63, 0.815);
  border: 1pt solid orange;
  margin: 5pt;
  padding: 10pt;
}
a {
  color: orange;
}
h4:hover {
  text-shadow: 0 0 6px orange !important;
}
.yourKeeps-section {
  height: 100vh;
  overflow-y: scroll;
}
</style>
