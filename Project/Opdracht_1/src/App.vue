<script setup>
import { ref, computed } from 'vue'

import Header from './components/Header.vue'
import WhatsHappening from './components/WhatsHappening.vue'
import Quiz from './components/Quiz.vue'
import Footer from './components/Footer.vue'
import qrcode from './components/qrcode.vue'
import Grondwaterstand from './components/Grondwater.vue'

import winterboom from './assets/test1.png'
import lenteboom from './assets/test3.png'
import zomerboom from './assets/zomerboom.png'
import herstboom from './assets/test1.png'

const waterHeight = ref(0)
const grondwaterRef = ref(null)
const sliderRef = ref(null)

const treeImage = computed(() => {
  const month = new Date().getMonth() + 1

  if (month === 12 || month === 1 || month === 2) {
    return winterboom
  }

  if (month >= 3 && month <= 5) {
    return lenteboom
  }

  if (month >= 6 && month <= 8) {
    return zomerboom
  }

  return herstboom
})

function startResetTimer() {
  clearTimeout(resetTimer)

  resetTimer = setTimeout(() => {
    waterHeight.value = 0
    grondwaterRef.value?.resetNaarApi()
    sliderRef.value?.resetSliders()
  }, 10000)
}

function updateRain(value) {
  waterHeight.value = (value / 190) * 700

  grondwaterRef.value?.veranderGrondwaterDoorSlider(
    value
  )
}

function updateTemperature(value) {
  waterHeight.value = ((190 - value) / 190) * 700

  grondwaterRef.value?.veranderGrondwaterDoorSlider(
    190 - value
  )
}
</script>

<template>

  <body>
  <div id="Header">
    <Header/>
  </div>
  <div id="mainContent">
    <div id="waterMeasure">

    </div>

    <div id="tree">
      <img :src="treeImage" alt="Seizoensboom">
  <div id="grondwaterkastje">
<Grondwaterstand ref="grondwaterRef" />
</div>
    </div>
    <div id="grass"></div>
    <div id="dirt">
    </div>
      <div id="sliders">
        <WhatsHappening @rain="updateRain" @temperature="updateTemperature" />
      </div>
    <div id="water" :style="{height: `${waterHeight}px`}"></div>
  </div>
  <div id="Quiz">
    <Quiz />
  </div>
    <div id="qrcode">
    <qrcode />
  </div>
  <div id="footer">
    <Footer />
  </div>
  </body>

</div>

<div id="grass"></div>

<div id="dirt"></div>

<div
id="water"
:style="{
height: `${waterHeight}px`
}"
></div>

<div id="sliders">
<WhatsHappening
  ref="sliderRef"
  @rain="updateRain"
  @temperature="updateTemperature"
/>
</div>

</div>

<div id="Quiz">
<Quiz />
</div>

<div id="qrcode">
<qrcode />
</div>

<div id="footer">
<Footer />
</div>

</div>
</template>

<style scoped>
#mainContent{
  position: relative;
  overflow: hidden;
}

#sliders{
  position: absolute;
  top: 650px;
  width: 100%;
  display: flex;
  justify-content: center;
  z-index: 10;
}

#tree{
  position: relative;
  display: flex;
  justify-content: center;
  z-index: 2;
  background-color: #7cd1ff;
}

#grondwaterkastje {
  position: absolute;
  left: 2vw;            
  top: calc(500px - 20rem); 
  
  width: 15rem;
  height: 20rem;
  background-color: gray;
  z-index: 10;
}

#grass{
  position: relative;
  width: 100%;
  height: 100px;
  background-color: #598F29;
  z-index: 2;
}

#water{
  position: absolute;
  bottom: 0;

  width: 100%;

  background-color: #0B84B7;

  z-index: 5;

  height: v-bind(waterHeight + 'px');

  min-height: 0;

  max-height: 700px;
}

#water{
  position: absolute;
  bottom: 0;
  width: 100%;
  background-color: #0B84B7;
  z-index: 5;
  max-height: 670px;
  min-height: 5px;
}

#footer{
  margin-top: 64px;
}

img{
  width: 400px;
  height: 500px;
}
</style>
