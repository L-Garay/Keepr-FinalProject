<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-10 title">
        <h2>Welcom to your vault, {{ vault.name }}</h2>
      </div>
      <div class="col-2">
        <i class="far fa-trash-alt fa-lg deleteIcon" @click="deleteVault(vault.id)"></i>
      </div>
      <div class="col-12 d-flex justify-content-center">
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
      <div class="card-columns">
        <keep v-for="keep in keeps" :key="keep.id" :keepData="keep" />
      </div>
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

<style>
.deleteIcon {
  color: red;
  margin-top: 11pt;
}
.title {
  text-align: center;
}
</style>
