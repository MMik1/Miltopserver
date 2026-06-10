<script setup>
import TemperatureSlider from "@/components/TemperatureSlider.vue";
import RainfallSlider from "@/components/RainfallSlider.vue";


const emit = defineEmits(['rain', 'temperature'])

function handleRain(value){
  emit('rain', value)
}

function handleTemperature(value){
  emit('temperature', value)
}
</script>

<template>
<div id="container">
<h2>Wat gebeurt er?</h2>
  <div id="circles">
    <div id="temp" class="circle">
      <img id="tempImg" src="../assets/Temperature.png" alt="a temperature measure">
    </div>
    <div id="rain" class="circle">
      <img src="../assets/rainyCloud.png" alt="raining cloud image cartoon png">
    </div>
  </div>
  <div id="sliders">
    <div id="tempSlider">
      <TemperatureSlider @change="handleTemperature" />
    </div>
    <div id="rainSlider">
      <RainfallSlider @change="handleRain"/>
    </div>
  </div>
</div>
</template>

<style scoped>

img{
  width: 70%;
}

#tempImg{
  width: 80%;
}

#container {
  margin-top: 50px;
  display: flex;
  flex-direction: column;
  width: 490px;
  background-color: #FEF8E2;
  border-radius: 30px;
  position: relative;
  z-index: 10;
}

h2{
  font-family: Bahnschrift, sans-serif;
  text-align: center;
  color: #D94423;
  font-size: 30px;
  font-weight: bolder;
}

.circle{
  width: 120px;
  height: 120px;
  background-color: #B9E8E5;
  border: 10px solid #B3B3B3;
  border-radius: 80px;
  display: flex;
  justify-content: center;
  align-items: center;
}

#circles{
  margin: 20px;
  display: flex;
  flex-direction: row;
  gap: 100px;
  justify-content: center;
}

#sliders{
  margin-top: 10px;
  display: flex;
  justify-content: space-between;
  width: 90%;
  padding: 0 25px;
}
</style>