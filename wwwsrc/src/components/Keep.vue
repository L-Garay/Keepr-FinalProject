<template>
  <div class="card">
    <img class="card-img-top" :src="keepData.Img" alt="Testing image" />
    <div class="card-body">
      <h5 class="card-title">{{keepData.Name}}</h5>
      <p class="card-text">{{keepData.Description}}</p>
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
</style>