<template>
  <div class="card">
    <router-link :to="{ name: 'singlekeep', params: { keepId: keepData.id } }">
      <img
        @click="updateViews(keepData.id)"
        class="card-img-top"
        :src="keepData.img"
        alt="Testing image"
      />
    </router-link>
    <div class="card-body">
      <router-link :to="{ name: 'singlekeep', params: { keepId: keepData.id } }">
        <h5 @click="updateViews(keepData.id)" class="card-title">{{ keepData.name }}</h5>
        <p @click="updateViews(keepData.id)" class="card-text">{{ keepData.description }}</p>
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
          >View {{ keepData.views }}</button>
        </router-link>
        <button type="button" class="btn shares">Share {{ keepData.shares }}</button>
        <div class="dropdown">
          <button
            type="button"
            class="btn keeps dropdown-toggle"
            data-toggle="dropdown"
          >Keep Me {{ keepData.keeps }}</button>
          <div class="dropdown-menu">
            <p
              v-for="vault in vaults"
              :key="vault.id"
              class="dropdown-item"
              @click="saveKeep(vault.id, keepData.id)"
            >{{vault.name}}</p>
          </div>
        </div>
        <div class="dropdown">
          <button type="button" class="btn keeps dropdown-toggle" data-toggle="dropdown">Remove Me</button>
          <div class="dropdown-menu">
            <p
              v-for="vaultKeep in vaultKeeps"
              :key="vaultKeep.id"
              class="dropdown-item"
              @click="removeKeep(vault.id, keepData.id)"
            >{{this.$store.state.vaultKeeps.find(vk => vk.id == vaultKeep.id)}}</p>
          </div>
        </div>
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
        if (privateKeepToUpdate == null) {
          let myKeepToUpdate = this.$store.state.myKeeps.find(
            k => k.id == keepId
          );
          this.$store.dispatch("editKeep", myKeepToUpdate);
        }
        this.$store.dispatch("editKeep", privateKeepToUpdate);
      } else if (keepToUpdate != null) {
        this.$store.dispatch("editKeep", keepToUpdate);
      }
    },
    saveKeep(vaultId, keepId) {
      let vaultKeep = {
        VaultId: vaultId,
        KeepId: keepId
      };
      this.$store.dispatch("createVaultKeep", vaultKeep);
      // debugger;
      let keepToUpdate = this.$store.state.publicKeeps.find(
        k => k.id == keepId
      );
      if (keepToUpdate == null) {
        let privateKeepToUpdate = this.$store.state.privateKeeps.find(
          k => k.id == keepId
        );
        if (privateKeepToUpdate == null) {
          let myKeepToUpdate = this.$store.state.myKeeps.find(
            k => k.id == keepId
          );
          this.$store.dispatch("editKeepKeeps", myKeepToUpdate);
        }
        this.$store.dispatch("editKeepKeeps", privateKeepToUpdate);
      } else if (keepToUpdate != null) {
        this.$store.dispatch("editKeepKeeps", keepToUpdate);
      }
    }
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps.filter(vk => vk.KeepId == this.$store.state.publicKeeps.find(k => k.id == ))
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
