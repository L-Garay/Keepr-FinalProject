<template>
  <div class="card">
    <img class="card-img-top" :src="keepData.img" alt="Testing image" />
    <div class="card-body">
      <h5 class="card-title">{{ keepData.name }}</h5>
      <p class="card-text">{{ keepData.description }}</p>
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
