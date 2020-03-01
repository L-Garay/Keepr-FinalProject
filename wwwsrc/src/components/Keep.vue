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
        <!-- <p @click="updateViews(keepData.id)" class="card-text">{{ keepData.description }}</p> -->
      </router-link>
      <div class="d-flex">
        <router-link
          @click="updateViews(keepData.id)"
          :to="{ name: 'singlekeep', params: { keepId: keepData.id } }"
        >
          <button
            type="button"
            @click="updateViews(keepData.id)"
            class="btn keepBtns"
          >View {{ keepData.views }}</button>
        </router-link>
        <button type="button" class="btn keepBtns">Share {{ keepData.shares }}</button>
        <div class="dropdown">
          <button
            type="button"
            class="btn keepBtns dropdown-toggle"
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
        <!-- <div class="dropdown">
          <button type="button" class="btn keeps dropdown-toggle" data-toggle="dropdown">Remove Me</button>
          <div class="dropdown-menu">
            <p
              v-for="vaultKeep in vaultKeeps"
              :key="vaultKeep.id"
              class="dropdown-item"
              @click="removeKeep(vault.id, keepData.id)"
            >{{vaultKeep.id}}</p>
          </div>
        </div>-->
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
    // removeKeep(vaultId, keepId) {
    //   let vaultKeep = {
    //     VaultId: vaultId,
    //     KeepId: keepId
    //   };
    //   this.$store.dispatch("deleteVaultKeep", vaultKeep);
    //   debugger;
    //   let keepToUpdate = this.$store.state.publicKeeps.find(
    //     k => k.id == keepId
    //   );
    //   if (keepToUpdate == null) {
    //     let privateKeepToUpdate = this.$store.state.privateKeeps.find(
    //       k => k.id == keepId
    //     );
    //     if (privateKeepToUpdate == null) {
    //       let myKeepToUpdate = this.$store.state.myKeeps.find(
    //         k => k.id == keepId
    //       );
    //       this.$store.dispatch("removeKeepKeeps", myKeepToUpdate);
    //     }
    //     this.$store.dispatch("removeKeepKeeps", privateKeepToUpdate);
    //   } else if (keepToUpdate != null) {
    //     this.$store.dispatch("removeKeepKeeps", keepToUpdate);
    //   }
    // }
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
    // vaultKeeps() {
    //   return this.$store.state.vaultKeeps;
    //   // .filter(vk => vk.KeepId == this.$store.state.publicKeeps.find(k => k.id == ))
    // }
  }
};
</script>

<style scoped>
.card {
  background-color: rgba(0, 0, 0, 0.822);
}
a {
  color: orange;
  text-shadow: 1pt 1pt 3pt black;
  font-family: "Press Start 2P";
}
a:hover {
  color: orange;
  text-shadow: 0 0 7pt orange;
  font-family: "Press Start 2P";
}
button.btn {
  font-family: "Press Start 2P";
  font-size: 0.7rem;
}
/* img {
  max-width: 350px;
  max-height: 550px;
} */
.keepBtns {
  border: 1pt solid orange;
  color: orange;
  background-color: rgb(49, 49, 49);
  margin: 5pt;
}
.keepBtns:hover {
  text-shadow: 0 0 3px orange;
  box-shadow: 0 0 8px orange;
}
.dropdown-menu {
  background-color: rgb(0, 0, 0);
  border: 1pt solid orange;
}
.dropdown-item {
  color: orange;
  font-family: "Press Start 2P";
  font-size: 0.7rem;
  background-color: black;
}
.dropdown-item:hover {
  cursor: pointer;
  color: rgb(255, 201, 100);
  text-shadow: 0 0 7px orange;
}
</style>
