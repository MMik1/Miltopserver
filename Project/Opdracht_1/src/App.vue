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

const waterHeight = ref(0)
const grondwaterRef = ref(null)
const sliderRef = ref(null)

let resetTimer

const treeImage = computed(() => {
  const month = new Date().getMonth() + 1

  if (month === 12 || month === 1 || month === 2) return winterboom
  if (month >= 3 && month <= 5) return lenteboom
  if (month >= 6 && month <= 8) return zomerboom

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
  waterHeight.value = (value / 190) * 600

  grondwaterRef.value?.veranderGrondwaterDoorSlider(value)

  startResetTimer()
}

function updateTemperature(value) {
  const omgekeerdeWaarde = 190 - value

  waterHeight.value = (omgekeerdeWaarde / 190) * 600

  grondwaterRef.value?.veranderGrondwaterDoorSlider(omgekeerdeWaarde)

  startResetTimer()
}
</script>

<template>
  <div>
    <div id="Header">
      <Header />
    </div>

    <div id="mainContent">
      <div id="tree">
        <img :src="treeImage" alt="Seizoensboom">

        <div id="grondwaterkastje">
          <Grondwaterstand ref="grondwaterRef" />
        </div>
      </div>

      <div id="grass"></div>
      <div id="dirt"></div>

      <div
        id="water"
        :style="{ height: `${waterHeight}px` }"
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
#mainContent {
  position: relative;
  overflow: hidden;
}

#sliders {
  position: absolute;
  top: 650px;
  width: 100%;
  display: flex;
  justify-content: center;
  z-index: 30;
}

#tree {
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
  z-index: 20;
}

#grass {
  position: relative;
  width: 100%;
  height: 100px;
  background-color: #598F29;
  z-index: 2;
}

#dirt {
  position: relative;
  width: 100%;
  height: 600px;
  background-color: #7C6034;
  z-index: 2;
}

#water {
  position: absolute;
  bottom: 0;
  width: 100%;
  background-color: rgba(11, 132, 183, 0.75);
  z-index: 3;
  max-height: 600px;
  min-height: 0;
  pointer-events: none;
  transition: height .3s ease;
}

#footer {
  margin-top: 64px;
}

img {
  width: 400px;
  height: 500px;
}
</style>