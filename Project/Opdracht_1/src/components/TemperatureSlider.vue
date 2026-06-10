<script setup>
import { ref } from 'vue'

const position = ref(0)

const emit = defineEmits(['change'])

function startDrag(event) {

  const slider = event.target.parentElement
  const sliderWidth = 190

  function moveCircle(e) {

    const rect = slider.getBoundingClientRect()

    let x = e.clientX - rect.left

    // keep inside line
    if (x < 0) x = 0
    if (x > sliderWidth) x = sliderWidth

    position.value = x
    emit('change', x)
  }

  function stopDrag() {
    window.removeEventListener('mousemove', moveCircle)
    window.removeEventListener('mouseup', stopDrag)
  }

  window.addEventListener('mousemove', moveCircle)
  window.addEventListener('mouseup', stopDrag)
}
</script>

<template>
  <div id="sliderContainer">
    <div id="line"></div>

    <div
        id="circle"
        :style="{ left: `${position}px` }"
        @mousedown="startDrag"
    ></div>
  </div>
</template>

<style scoped>
#sliderContainer {
  position: relative;
  height: 30px;
  width: 190px;
}

#line{
  position: absolute;
  width: 190px;
  height: 7px;
  border-radius: 15px;
  background-color: #D9D9D9;
}

#circle{
  position: absolute;
  width: 10px;
  height: 10px;
  background-color: #F1B0B3;
  border: 8px solid #D94423;
  border-radius: 50px;
  top: -9px;
  left: 0;
  cursor: pointer;
}
</style>
