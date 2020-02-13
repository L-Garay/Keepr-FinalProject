<template>
  <div class="container-fluid">
    <div class="row ">
      <div class="col-10 title">
        <h2>Welcom to your vault, {{ vault.name }}</h2>
      </div>
      <div class="col-2">
        <i
          class="far fa-trash-alt fa-lg deleteIcon"
          @click="deleteVault(vault.id)"
        ></i>
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
      return this.$store.state.keeps;
    }
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
