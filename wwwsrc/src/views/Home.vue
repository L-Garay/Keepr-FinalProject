<template>
  <div class="container-fluid home">
    <!-- <video v-if="modalOpen" autoplay muted loop id="video">
      <source src="../assets/backgrounds/wallAnimated.mp4" type="video/mp4" />
    </video>-->
    <div class="row">
      <div class="col-12 my-3 d-flex justify-content-center">
        <h1>Welcome To Keepr</h1>
        <button
          class="btn create"
          type="button"
          data-toggle="modal"
          data-target="#createModal"
          @click="toggleModal"
        >Create a keep</button>
      </div>

      <div class="modal fade" id="createModal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="createModalTitle">Create a keep</h5>
              <button type="button" @click="toggleModal" class="close" data-dismiss="modal">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form class="form-group" @submit.prevent="addKeep">
                <div>
                  Name:
                  <input
                    v-model="newKeep.name"
                    class="form-control"
                    required
                    type="text"
                    placeholder="Name of keep"
                  />
                </div>
                <div>
                  Image URL:
                  <input
                    v-model="newKeep.imgUrl"
                    class="form-control"
                    type="text"
                    placeholder="What's your keep about"
                  />
                </div>
                <div>
                  Description:
                  <textarea
                    v-model="newKeep.description"
                    class="form-control"
                    cols="30"
                    rows="3"
                    maxlength="300"
                    placeholder="What's your keep about"
                    required
                  ></textarea>
                </div>
                <div>
                  <input
                    v-model="newKeep.private"
                    class="form-check-input"
                    type="checkbox"
                    value
                    id="privacyCheck"
                  />
                  <label
                    class="form-check-label"
                    for="privacyCheck"
                  >Check this if you want to make it private</label>
                </div>
                <div class="buttons">
                  <button class="btn submit" @click="toggleModal" type="submit">Submit Keep</button>
                  <button
                    type="button"
                    @click="toggleModal"
                    class="btn close2"
                    data-dismiss="modal"
                  >Close</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="card-columns">
      <keep v-for="keep in publicKeeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "home",
  data() {
    return {
      modalOpen: false,
      newKeep: {
        name: "",
        description: "",
        imgUrl: "",
        private: false
      }
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    // this.$store.dispatch("getVaultKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    toggleModal() {
      if (this.modalOpen == false) {
        this.modalOpen = true;
      } else if (this.modalOpen == true) {
        this.modalOpen = false;
      }
    },
    addKeep() {
      let keep = {
        Name: this.newKeep.name,
        Description: this.newKeep.description,
        Img: this.newKeep.imgUrl,
        IsPrivate: this.newKeep.private
      };
      this.$store.dispatch("addKeep", keep);
      this.newKeep = {
        name: "",
        description: "",
        imgUrl: "",
        private: false
      };
    },
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Keep
  }
};
</script>

<style scoped>
h1 {
  font-family: "Press Start 2P";
  color: orange;
  text-shadow: 1pt 1pt 3pt black;
}
.home {
  background-image: url("../assets/backgrounds/darkWall.jpg");
  background-position: center;
  background-size: cover;
  background-repeat: repeat-y;
}
.form-check-input {
  margin: 12pt 0 0 5pt;
}
.form-check-input:hover {
  margin: 12pt 0 0 5pt;
  cursor: pointer;
}
.form-check-label {
  margin: 7.5pt 0 0 20pt;
}
.buttons {
  display: flex;
  justify-content: space-between;
  margin-top: 10pt;
  padding-top: 10pt;
  border-top: 1pt solid white;
}
.create {
  border: 1pt solid orange;
  color: orange;
  background-color: rgb(49, 49, 49);
  margin-left: 15pt;
}
.create:hover {
  border: 1pt solid orange;
  color: orange;
  background-color: rgb(49, 49, 49);
  text-shadow: 0 0 5px orange;
  box-shadow: 0 0 20px orange;
}
.close {
  color: orange;
}
.close:hover {
  color: red;
  text-shadow: 0 0 15px red;
}
.submit {
  border: 1pt solid orange;
  background-color: rgba(0, 0, 0, 0.39);
  color: orange;
}
.submit:hover {
  border: 1pt solid orange;
  background-color: rgba(0, 0, 0, 0.39);
  color: orange;
  text-shadow: 0 0 10px orange;
  box-shadow: 2pt 2pt 5pt orange;
}
.close2 {
  border: 1pt solid orange;
  background-color: rgba(0, 0, 0, 0.39);
  color: orange;
}
.close2:hover {
  border: 1pt solid red;
  background-color: rgba(0, 0, 0, 0.39);
  color: red;
  text-shadow: 0 0 10px red;
  box-shadow: 2pt 2pt 5pt red;
}
.modal-header {
  background-color: black;
  color: orange;
}
.modal-body {
  background-color: rgb(46, 46, 46);
  color: orange;
}
.form-control {
  background-color: grey;
  border: 1pt solid orange;
}
::placeholder {
  color: white;
}
/* #video {
  width: 100vw;
  height: 100vh;
  object-fit: cover;
} */
</style>
