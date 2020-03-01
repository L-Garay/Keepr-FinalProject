<template>
  <div class="container-fluid keep">
    <div class="row">
      <div class="col-12 title">
        <h1>{{ keep.name }}</h1>
      </div>
      <div class="col-9 keepSection">
        <img :src="keep.img" alt="should be keep image" />
        <p>{{ keep.description }}</p>
      </div>
      <div class="col-3 buttonSection">
        <button type="button" class="btn">Views {{ keep.views }}</button>
        <button type="button" class="btn">Share {{ keep.shares }}</button>
        <div class="dropdown">
          <button
            type="button"
            class="btn keepBtns dropdown-toggle"
            data-toggle="dropdown"
            v-if="this.$auth.user.sub != false"
          >Keep Me {{ keep.keeps }}</button>
          <div class="dropdown-menu">
            <p
              v-for="vault in vaults"
              :key="vault.id"
              class="dropdown-item"
              @click="saveKeep(vault.id, keep.id)"
            >{{vault.name}}</p>
          </div>
        </div>
        <button
          v-if="this.keep.userId == this.$auth.user.sub"
          @click="deleteKeep(keep.id)"
          type="button"
          class="btn delete"
        >Delete</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "singlekeep",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
    this.$store.dispatch("getVaults");
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
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
      this.updateViews(keepId);
    },
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
    }
  }
};
</script>

<style scoped>
.container-fluid {
  color: orange;
  font-family: "Press Start 2P";
  text-shadow: 1pt 1pt 4pt black;
  background-image: url("../assets/backgrounds/darkWall.jpg");
  background-position: center;
  background-size: cover;
  background-repeat: repeat-y;
}
.title {
  text-align: center;
  margin-top: 8pt;
  /* animation: neon 2.58s ease-in-out infinite alternate; */
}
@keyframes neon {
  from {
    text-shadow: 0 0 20px rgba(252, 239, 52, 0.76),
      0 0 30px rgba(250, 191, 65, 0.774), 0 0 12px rgba(242, 132, 30, 0.945),
      0 0 21px rgba(245, 163, 12, 0.92), 0 0 34px rgba(242, 62, 30, 0.78),
      0 0 54px rgba(243, 113, 26, 0.92);
  }
  to {
    text-shadow: 0 0 20px rgba(252, 73, 41, 0.92),
      0 0 30px rgba(238, 84, 57, 0.34), 0 0 12px rgba(242, 97, 30, 0.52),
      0 0 21px rgba(245, 47, 12, 0.92), 0 0 34px rgba(245, 66, 12, 0.78),
      0 0 54px rgba(245, 39, 12, 0.92);
  }
}
.keepSection {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 90vh;
}
img {
  max-width: 660px;
  box-shadow: 8pt 8pt 4pt black;
}
p {
  margin-top: 15pt;
  padding: 10pt;
  border: 2pt solid orange;
  background-color: rgba(49, 49, 49, 0.842);
  width: 640px;
}
.buttonSection {
  display: flex;
  flex-direction: column;
  place-content: center;

  height: 90vh;
}
button {
  border: 1pt solid orange;
  color: orange;
  background-color: rgb(49, 49, 49);
  margin: 5pt;
  width: 35%;
}
button:hover {
  text-shadow: 0 0 4px orange;
  box-shadow: 0 0 15px orange;
  color: orange;
}
button.delete:hover {
  border: 1pt solid red;
  background-color: black;
  border: 1pt solid re;
  color: red;
  box-shadow: 0 0 15px red;
  text-shadow: 0 0 8px red;
  margin: 5pt;
}
.dropdown-menu {
  background-color: black;
  width: 450px;
  border: 1pt solid orange;
}
p.dropdown-item {
  color: orange;
  width: 445px;
  border: none;
  background-color: black;
}
p.dropdown-item:hover {
  cursor: pointer;
  color: rgb(255, 199, 94);
  text-shadow: 0 0 10px orange;
}
</style>
