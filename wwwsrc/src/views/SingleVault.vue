<template>
  <div class="container-fluid vault">
    <div class="row">
      <div class="col-6 offset-3 title">
        <h2>Welcome to your vault, {{ vault.name }}</h2>
      </div>
      <div class="col-1 offset-2">
        <button class="btn deleteBtn" type="button" @click="deleteVault(vault.id)">Delete Vault</button>
      </div>
      <div class="col-12 d-flex justify-content-center mb-3">
        <div class="dropdown">
          <button
            type="button"
            class="btn keeps dropdown-toggle"
            data-toggle="dropdown"
          >Remove Keeps</button>
          <div class="dropdown-menu">
            <p
              v-for="keep in keeps"
              :key="keep.id"
              class="dropdown-item"
              @click="removeKeep(vault.id, keep.id)"
            >{{keep.name}}</p>
          </div>
        </div>
      </div>
    </div>
    <div class="card-columns">
      <keep v-for="keep in keeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "singlevault",
  methods: {
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    },
    removeKeep(vaultId, keepId) {
      let vaultKeep = {
        VaultId: vaultId,
        KeepId: keepId
      };
      this.$store.dispatch("deleteVaultKeep", vaultKeep);
      //   TODO Lower keep count upon removal
      // debugger;
      // let keepToUpdate = this.$store.state.publicKeeps.find(
      //   k => k.id == keepId
      // );
      // if (keepToUpdate == null) {
      //   let privateKeepToUpdate = this.$store.state.privateKeeps.find(
      //     k => k.id == keepId
      //   );
      //   if (privateKeepToUpdate == null) {
      //     let myKeepToUpdate = this.$store.state.myKeeps.find(
      //       k => k.id == keepId
      //     );
      //     this.$store.dispatch("removeKeepKeeps", myKeepToUpdate);
      //   }
      //   this.$store.dispatch("removeKeepKeeps", privateKeepToUpdate);
      // } else if (keepToUpdate != null) {
      //   this.$store.dispatch("removeKeepKeeps", keepToUpdate);
      // }
    }
  },
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    keeps() {
      return this.$store.state.myKeeps;
    }
  },
  components: {
    Keep
  }
};
</script>

<style scoped>
.vault {
  font-family: "Press Start 2P";
  color: orange;
  background-image: url("../assets/backgrounds/darkWall.jpg");
  background-position: center;
  background-size: cover;
  background-repeat: repeat-y;
  /* background-color: grey; */
  height: 93.5vh;
  width: 100vw;
  overflow-x: hidden;
}
.deleteBtn {
  border: 1pt solid orange;
  background-color: rgb(46, 46, 46);
  color: orange;
  text-shadow: 0 0 6px black;
  margin-top: 7pt;
}
.deleteBtn:hover {
  text-shadow: 0 0 6px red;
  box-shadow: 0 0 10px red;
  color: red;
  border: 1pt solid red;
  background-color: black;
}
.title {
  text-align: center;
  text-shadow: 0 0 6px black;
  margin-top: 7pt;
}
.keeps {
  color: orange;
  text-shadow: 0 0 6px black;
  border: 1pt solid orange;
  background-color: rgb(46, 46, 46);
}
.keeps:hover {
  text-shadow: 0 0 6px red;
  box-shadow: 0 0 10px red;
  color: red;
  border: 1pt solid red;
  background-color: black;
}
.dropdown-menu {
  background-color: black;
  border: 1pt solid orange;
}
.dropdown-item {
  color: orange;
}
.dropdown-item:hover {
  cursor: pointer;
  text-shadow: 0 0 6px orange;
  color: black;
}
</style>
