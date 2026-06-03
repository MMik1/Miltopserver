<script setup>
import { ref, computed } from 'vue'

import Header from './components/Header.vue'
import WhatsHappening from './components/WhatsHappening.vue'
import Quiz from './components/Quiz.vue'
import Footer from './components/Footer.vue'
import qrcode from './components/qrcode.vue'

import winterboom from './assets/test1.png'
import lenteboom from './assets/test3.png'
import zomerboom from './assets/zomerboom.png'
import herstboom from './assets/test1.png'

const previousRain = ref(0)
const previousTemp = ref(0)
const waterHeight = ref(200)

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

function updateRain(value) {
  if (value > previousRain.value) {
    const difference = value - previousRain.value
    waterHeight.value += difference
  }

  previousRain.value = value
}

function updateTemperature(value) {
  if (value > previousTemp.value) {
    const difference = value - previousTemp.value
    waterHeight.value -= difference

    if (waterHeight.value < 0) {
      waterHeight.value = 0
    }
  }

  previousTemp.value = value
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


#grass{
  position: relative;
  width: 100%;
  height: 100px;
  background-color: #598F29;
  z-index: 2;
}

#dirt{
  position: relative;
  width: 100%;
  height: 600px;
  background-color: #7C6034;
  z-index: 2;
}

#water{
  position: absolute;
  bottom: 0;
  width: 100%;
  background-color: #0B84B7;
  z-index: 5;
}

#footer{
  margin-top: 64px;
}

img{
  width: 400px;
  height: 500px;
}
</style>
