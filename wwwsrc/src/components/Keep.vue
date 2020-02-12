<template>
  <div class="card">
    <router-link
      @click="updateViews(keepData.id)"
      :to="{ name: 'singlekeep', params: { keepId: keepData.id } }"
      ><img class="card-img-top" :src="keepData.img" alt="Testing image"
    /></router-link>
    <div class="card-body">
      <router-link
        :to="{ name: 'singlekeep', params: { keepId: keepData.id } }"
      >
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">{{ keepData.description }}</p>
      </router-link>
      <div class="d-flex">
        <router-link
          @click="updateViews(keepData.id)"
          :to="{ name: 'singlekeep', params: { keepId: keepData.id } }"
        >
          <button
            type="button"
            @click="updateViews(keepData.id)"
            class="btn views"
          >
            View {{ keepData.views }}
          </button></router-link
        >
        <button type="button" class="btn shares">
          Share {{ keepData.shares }}
        </button>
        <button type="button" class="btn keeps">
          Keep {{ keepData.keeps }}
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"],
  methods: {
    updateViews(keepId) {
      let keepToUpdate = this.$store.state.publicKeeps.find(
        k => k.id == keepId
      );
      if (keepToUpdate == null) {
        let privateKeepToUpdate = this.$store.state.privateKeeps.find(
          k => k.id == keepId
        );
        privateKeepToUpdate.views = privateKeepToUpdate.views + 1;
        this.$store.dispatch("editKeep", privateKeepToUpdate);
      } else if (keepToUpdate != null) {
        keepToUpdate.views = keepToUpdate.views + 1;
        this.$store.dispatch("editKeep", keepToUpdate);
      }
    }
  }
};
</script>

<style>
.views {
  border: 1pt solid green;
  background-color: lightgreen;
  margin: 5pt;
}
.shares {
  border: 1pt solid blue;
  background-color: lightskyblue;
  margin: 5pt;
}
.keeps {
  border: 1pt solid yellow;
  background-color: lightyellow;
  margin: 5pt;
}
</style>
