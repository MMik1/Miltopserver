<script setup>
import { ref, computed } from 'vue'

import Header from './components/Header.vue'
import WhatsHappening from './components/WhatsHappening.vue'
import Quiz from './components/Quiz.vue'
import Footer from './components/Footer.vue'
import qrcode from './components/qrcode.vue'
import Grondwaterstand from './components/Grondwater.vue'

import winterboom from './assets/winterboomimage.png'
import lenteboom from './assets/lenteboomimage.png'
import zomerboom from './assets/zomerboomimage.png'
import herstboom from './assets/herfstboomimage.png'

import zomerAchtergrond from './assets/Achtergrond-zomer.png'
import herfstAchtergrond from './assets/Achtergrond-herfst.png'
import winterAchtergrond from './assets/Achtergrond-winter.png'
import lenteAchtergrond from './assets/Achtergrond-lentev2.png'

const waterHeight = ref(0)
const grondwaterRef = ref(null)
const sliderRef = ref(null)

const MAX_WATER_PERCENT = 70

let resetTimer

const treeImage = computed(() => {
  const month = new Date().getMonth() + 1

  if (month === 12 || month === 1 || month === 2) return winterboom
  if (month >= 3 && month <= 5) return lenteboom
  if (month >= 6 && month <= 8) return zomerboom

  return herstboom
})

const backgroundImage = computed(() => {
  const month = new Date().getMonth() + 1

  if (month === 12 || month === 1 || month === 2) return winterAchtergrond
  if (month >= 3 && month <= 5) return lenteAchtergrond
  if (month >= 6 && month <= 8) return zomerAchtergrond
  return herfstAchtergrond
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
  waterHeight.value = (value / 190) * MAX_WATER_PERCENT

  grondwaterRef.value?.veranderGrondwaterDoorSlider(value)

  startResetTimer()
}

function updateTemperature(value) {
  const omgekeerdeWaarde = 190 - value

  waterHeight.value = (omgekeerdeWaarde / 190) * MAX_WATER_PERCENT

  grondwaterRef.value?.veranderGrondwaterDoorSlider(omgekeerdeWaarde)

  startResetTimer()
}
</script>

<template>
  <div id="mainContent">
    <img class="bgLayer" :src="backgroundImage" alt="" />
    <div id="Header">
      <Header />
    </div>
    <div id="water" :style="{ height: waterHeight + '%' }"></div>

    <div id="tree">
      <img :src="treeImage" alt="Seizoensboom" />
    </div>

    <div id="grondwaterkastje">
      <Grondwaterstand ref="grondwaterRef" />
    </div>

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
</template>

<style scoped>

#mainContent {
  position: relative;
  width: 100%;
  overflow: hidden;
}

.bgLayer {
  display: block;
  width: 100%;
  height: auto;
}

#tree {
  position: absolute;
  left: 50%;
  bottom: 69%;                
  transform: translateX(-50%);
  width: 22%;                
  z-index: 4;
}

#tree img {
  display: block;
  width: 100%;
  height: auto;
}

#grondwaterkastje {
  position: absolute;
  left: 2%;
  bottom: 69%;               
  width: clamp(8rem, 15%, 15rem);
  height: clamp(11rem, 20%, 20rem);
  background-color: gray;
  z-index: 20;
}

#sliders {
  position: absolute;
  left: 50%;
  top: 4%;                     
  transform: translateX(-50%);
  width: 100%;
  display: flex;
  justify-content: center;
  z-index: 30;
}

#water {
  position: absolute;
  left: 0;
  bottom: 0;
  width: 100%;
  background-color: rgba(11, 132, 183, 0.55);
  z-index: 1;
  pointer-events: none;
  transition: height 0.3s ease;
}

#Header {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 40;           
}

#footer {
  margin-top: 64px;
}
</style>