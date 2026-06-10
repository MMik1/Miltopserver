<script setup>
import { ref, onMounted, onUnmounted } from "vue";

const date = ref("");
const currentTime = ref("");

let timer;

function updateDateTime() {
  const now = new Date();

  date.value =
    now.getDate() + "/" + (now.getMonth() + 1) + "/" + now.getFullYear();

  currentTime.value =
    now.getHours().toString().padStart(2, "0") +
    ":" +
    now.getMinutes().toString().padStart(2, "0");
}

onMounted(() => {
  updateDateTime();
  timer = setInterval(updateDateTime, 1000);
});

onUnmounted(() => {
  clearInterval(timer);
});
</script>

<template>
  <div id="headers">
    <h2>Een kijkje naar...</h2>
    <h1>Grondwater</h1>

    <div id="currentDate">
      <h1 id="date">{{ date }}</h1>
      <h3 id="time">{{currentTime}}</h3>
    </div>
  </div>
</template>

<style scoped>
#headers{
  width: 100%;
  height: 100%;
}

#currentDate{
  position: absolute;
  top: 10px;
  right: 20px;
  background: transparent;
  z-index: 20;
}

#date{
  color: #fff;
  font-size: 40px;
}

#time{
  position: absolute;
  top: 15px;
  right: 0;
  color: #fff;
  font-size: 30px;
}

  h1, h2{
    color: #fff;
  }

  h1{
    padding-left: 5rem;
    font-size: 80px;
    margin-top: 0px;
    margin-bottom: 0px;

  }

  h2{
    padding-left: 5rem;
    font-size: 30px;
    
    margin-top: 0px;
    margin-bottom: 0px;

  }


</style>