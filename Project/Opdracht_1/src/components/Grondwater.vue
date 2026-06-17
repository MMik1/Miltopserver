<script setup>
import {ref, onMounted, onUnmounted} from "vue";

const date = ref("");
const currentTime = ref("");

const grondWaterStand = ref("Laden...");
const apiGrondWaterStand = ref(null);

let timer;
let grondwaterTimer;
let resetTimer;

// Datum + tijd
function updateDateTime() {
  const now = new Date();

  date.value =
      now.getDate().toString().padStart(2, "0") +
      "/" +
      (now.getMonth() + 1).toString().padStart(2, "0") +
      "/" +
      now.getFullYear();

  currentTime.value =
      now.getHours().toString().padStart(2, "0") +
      ":" +
      now.getMinutes().toString().padStart(2, "0");
}

// Grondwater ophalen
async function haalGrondWaterStandOp() {
  try {
    const start = new Date();
    start.setHours(0, 0, 0, 0);

    const end = new Date();
    end.setHours(23, 59, 59, 999);

    const startDate = Math.floor(start.getTime() / 1000);
    const endDate = Math.floor(end.getTime() / 1000);

    const url =
        `/api/grondwater` +
        `?start_date=${startDate}` +
        `&end_date=${endDate}`;

    const response = await fetch(url);

    if (!response.ok) {
      throw new Error(`HTTP ${response.status}`);
    }

    const result = await response.json();

    if (result?.data && Array.isArray(result.data) && result.data.length > 0) {
      const laatsteMeting = result.data[result.data.length - 1];

      apiGrondWaterStand.value = Number(laatsteMeting.value);
      grondWaterStand.value = apiGrondWaterStand.value.toFixed(2) + " m";
    } else {
      grondWaterStand.value = "Geen meting gevonden";
    }
  } catch (err) {
    console.error("Fout:", err);
    grondWaterStand.value = "Fout bij ophalen";
  }
}

function veranderGrondwaterDoorSlider(sliderWaarde) {
  if (apiGrondWaterStand.value === null) return;

  const maxSlider = 190;

  // 0 → laag
  // 190 → hoog
  const percentage = sliderWaarde / maxSlider;

  // maximaal verschil in meters
  const maxVerschil = 1;

  const simulatorStand =
      apiGrondWaterStand.value + percentage * maxVerschil;

  grondWaterStand.value =
      simulatorStand.toFixed(2) + " m";

  clearTimeout(resetTimer);

  resetTimer = setTimeout(() => {
    grondWaterStand.value =
        apiGrondWaterStand.value.toFixed(2) + " m";
  }, 10000);
}

function resetNaarApi() {
  if (apiGrondWaterStand.value !== null) {
    grondWaterStand.value =
        apiGrondWaterStand.value.toFixed(2) + " m"
  }
}

defineExpose({
  veranderGrondwaterDoorSlider,
  resetNaarApi
});

onMounted(() => {
  updateDateTime();

  timer = setInterval(updateDateTime, 1000);

  haalGrondWaterStandOp();

  grondwaterTimer = setInterval(haalGrondWaterStandOp, 1800000);
});

onUnmounted(() => {
  clearInterval(timer);
  clearInterval(grondwaterTimer);
  clearTimeout(resetTimer);
});

</script>

<template>
  <div>
    <h5>Grondwaterstand</h5>
    <h4>{{ grondWaterStand }}</h4>
  </div>
</template>

<style scoped>
div {
  padding: 20px;
}

h5 {
  color: white;
  font-family: sans-serif;
  text-align: center;
  margin-top: -10px;
}

h4 {
  font-size: 20px;
  font-family: sans-serif;
  text-align: center;
  margin-top: -20px;
  color: #0099ff;
}

h5, h4{
  padding-left: 10px;
}
</style>