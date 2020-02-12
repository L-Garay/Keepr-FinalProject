<template>
  <div class="card">
    <router-link :to="{ name: 'singlekeep', params: { keepId: keepData.id } }"
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
        <button type="button" class="btn views">
          Views {{ keepData.views }}
        </button>
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
  props: ["keepData"]
};
</script>

<style>
.views {
  border: 1pt solid green;
  background-color: lightgreen;
}
.shares {
  border: 1pt solid blue;
  background-color: lightskyblue;
}
.keeps {
  border: 1pt solid yellow;
  background-color: lightyellow;
}
</style>
