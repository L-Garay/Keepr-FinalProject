<template>
  <div class="card">
    <div class="card-body">
      <h5 class="card-title">{{ vaultData.name }}</h5>
      <p class="card-text">{{ vaultData.description }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vaultData"]
};
</script>

<style></style>
