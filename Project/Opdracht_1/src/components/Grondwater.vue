<script setup>
import { ref, onMounted, onUnmounted } from "vue";

const date = ref("");
const currentTime = ref("");
const grondWaterStand = ref("Laden...");

let timer;

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

    console.log("Request:", url);

    const response = await fetch(url);

    if (!response.ok) {
      throw new Error(`HTTP ${response.status}`);
    }

    const result = await response.json();

    console.log("API RESULT:", result);

if (result?.data && Array.isArray(result.data) && result.data.length > 0) {
  const laatsteMeting = result.data[result.data.length - 1];

  grondWaterStand.value = laatsteMeting.value + " m";
} else {
  grondWaterStand.value = "Geen meting gevonden";
}

  } catch (err) {
    console.error("Fout:", err);

    grondWaterStand.value =
      "Fout bij ophalen";
  }
}

onMounted(() => {
  updateDateTime();

  timer = setInterval(updateDateTime, 1000);

  haalGrondWaterStandOp();

  setInterval(haalGrondWaterStandOp, 1800000);
});

onUnmounted(() => {
  clearInterval(timer);
});
</script>

<template>
  <div>
    <h2>Grondwaterstand</h2>

    <h3>{{ grondWaterStand }}</h3>
  </div>
</template>

<style scoped>
div {
  padding: 20px;
}

h2 {
    color: white;
  margin-bottom: 10px;
}

h3 {
    font-size: 50px;
  color: #0099ff;
}
</style>