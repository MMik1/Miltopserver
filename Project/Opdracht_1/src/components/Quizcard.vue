<script setup>
defineProps({
  backgroundImage: String
})
</script>

<template>
  <div
      class="quizcard"
      :style="{ backgroundImage: `url(${backgroundImage})` }"
  ></div>
</template>

<style scoped>
.quizcard {
  height: 20.125rem;
  width: 22.5rem;
  cursor: pointer;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  border-radius: 0.625rem;
  border: 0.5rem solid #036ECE;
}

.text-container {
  color: #F4EFE8;
  padding: 16px;
}

.test {
  color: #F4EFE8;

  font-family: Inter;
  font-size: 18px;
  font-style: normal;
  font-weight: 400;
  line-height: 26px;
}

.button-container {
  width: 100%;
  display: flex;
  justify-content: flex-end;
}

.quizcard:hover {
  border-color: #0056A4;
}

</style>