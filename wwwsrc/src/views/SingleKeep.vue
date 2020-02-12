<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-9 keepSection">
        <h3>{{ keep.name }}</h3>
        <img :src="keep.img" alt="should be keep image" />
        <p>{{ keep.description }}</p>
      </div>
      <div class="col-3 buttonSection">
        <button type="button" class="btn views">Views {{ keep.views }}</button>
        <button type="button" class="btn shares">
          Share {{ keep.shares }}
        </button>
        <button type="button" class="btn keeps">Keep {{ keep.keeps }}</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "singlekeep",
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  }
};
</script>

<style>
.keepSection {
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 90vh;
}
.buttonSection {
  display: flex;
  flex-direction: column;
  place-content: center;
  height: 90vh;
}
img {
  max-width: 660px;
}
</style>
