<template>
  <div>
    <div class="container">
      <div class="row">&nbsp;</div>
      <div class="row">
        <div class="col-2">User</div>
        <div class="col-4">
          <input type="text" id="userInput" v-model="username" />
        </div>
      </div>
      <div class="row">
        <div class="col-2">Message</div>
        <div class="col-4">
          <input type="text" id="messageInput" v-model="message" />
        </div>
      </div>
      <div class="row">&nbsp;</div>
      <div class="row">
        <div class="col-6">
          <input type="button" id="sendButton" value="Send Message" :disabled="buttonDisabled" />
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <hr />
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <ul id="messagesList"></ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String,
  },
  data() {
    return {
      username: "",
      message: "",
      buttonDisabled: true
    };
  },
  mounted() {
    this.$chatHub.start().then( () => {
      this.buttonDisabled = false;
      this.addListeners();
    })
  },
  methods: {
    addListeners: function() {
      this.$chatHub.client.on("ReceiveMessage", function (user, message) {
      var li = document.createElement("li");
      document.getElementById("messagesList").appendChild(li);
      // We can assign user-supplied strings to an element's textContent because it
      // is not interpreted as markup. If you're assigning in any other way, you
      // should be aware of possible script injection concerns.
      li.textContent = `${user} says ${message}`;
    });

    document
      .getElementById("sendButton")
      .addEventListener("click", (event) => {
        this.$chatHub.client.invoke("SendMessage", this.username, this.message).catch(function (err) {
          return console.error(err.toString());
        });
        event.preventDefault();
      });
    },
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
