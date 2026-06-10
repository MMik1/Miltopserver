<script setup>
import { ref } from 'vue'

import TemperatureSlider from "@/components/TemperatureSlider.vue";
import RainfallSlider from "@/components/RainfallSlider.vue";

const emit = defineEmits([
  'rain',
  'temperature'
])

const rainRef = ref(null)
const tempRef = ref(null)

function handleRain(value) {
  emit('rain', value)
}

function handleTemperature(value) {
  emit('temperature', value)
}

function resetSliders() {
  rainRef.value?.resetSlider()
  tempRef.value?.resetSlider()
}

defineExpose({
  resetSliders
})
</script>

<template>

<div id="container">

<h2>
Wat gebeurt er?
</h2>

<div id="circles">

<div id="temp" class="circle">
<img
id="tempImg"
src="../assets/Temperature.png"
alt="temperature"
/>
</div>

<div id="rain" class="circle">
<img
src="../assets/rainyCloud.png"
alt="rain cloud"
/>
</div>

</div>

<div id="sliders">

<div id="tempSlider">

<TemperatureSlider
ref="tempRef"
@change="handleTemperature"
/>

</div>

<div id="rainSlider">

<RainfallSlider
ref="rainRef"
@change="handleRain"
/>

</div>

</div>

</div>

</template>

<style scoped>

img{
width:70%;
}

#tempImg{
width:80%;
}

#container{
margin-top:50px;

display:flex;

flex-direction:column;

width:490px;

background:#FEF8E2;

border-radius:30px;

position:relative;

z-index:10;
}

h2{
font-family:Bahnschrift,sans-serif;

text-align:center;

color:#D94423;

font-size:30px;

font-weight:bolder;
}

.circle{
width:120px;

height:120px;

background:#B9E8E5;

border:10px solid #B3B3B3;

border-radius:80px;

display:flex;

justify-content:center;

align-items:center;
}

#circles{
margin:20px;

display:flex;

gap:100px;

justify-content:center;
}

#sliders{
margin-top:10px;

display:flex;

justify-content:space-between;

width:90%;

padding:0 25px;
}

#tempSlider{
display:flex;
}

#rainSlider{
display:flex;
}

</style>