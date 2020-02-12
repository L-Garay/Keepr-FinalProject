<template>
  <div class="container-fluid">
    <div class="row">
      <h2>Welcom to your vault, {{ vault.name }}</h2>
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

<style></style>
