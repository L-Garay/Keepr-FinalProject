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
        <button
          v-if="showBtn"
          @click="deleteKeep(keep.id)"
          type="button"
          class="btn delete"
        >
          Delete
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "singlekeep",
  data() {
    return {
      showBtn: false
    };
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
    if (this.keep.UserId == this.$auth.UserId) {
      this.showBtn = true;
    } else if (this.keep.UserId != this.$auth.UserId) {
      this.showBtn = false;
    }
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
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
.delete {
  border: 1pt solid red;
  background-color: rgb(233, 179, 179);
  margin: 5pt;
}
</style>
