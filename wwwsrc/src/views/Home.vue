<template>
  <div class="container-fluid home">
    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <h1>Welcome Home</h1>
        <button class="btn btn-success" type="button" @click="toggleForm">Create a keep</button>
      </div>
      <div class="col-8" v-if="showForm">
        <div id="form">
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
            <button class="btn btn-success" type="submit">Submit Keep</button>
          </form>
        </div>
      </div>
      <div class="card-columns">
        <keep v-for="keep in publicKeeps" :key="keep.id" :keepData="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep.vue";
export default {
  name: "home",
  data() {
    return {
      showForm: false,
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
    toggleForm() {
      if (this.showForm == false) {
        this.showForm = true;
      } else if (this.showForm == true) {
        this.showForm = false;
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
