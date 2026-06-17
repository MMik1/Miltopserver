<script setup>
import {ref} from 'vue'
import QuizCard from './Quizcard.vue'

import quiz1 from '../assets/test1.png'
import quiz2 from '../assets/test2.png'
import quiz3 from '../assets/test3.png'
import confetti from 'canvas-confetti'
import quiz4 from '../assets/test1.png'
import quiz5 from '../assets/test2.png'
import quiz6 from '../assets/test3.png'
import quiz7 from '../assets/test1.png'
import quiz8 from '../assets/test1.png'
import quiz9 from '../assets/test1.png'
import quiz10 from '../assets/test1.png'
import quiz11 from '../assets/test1.png'
import quiz12 from '../assets/test1.png'
import quiz13 from '../assets/test1.png'
import quiz14 from '../assets/test1.png'
import quiz15 from '../assets/test1.png'
import quiz16 from '../assets/test1.png'
import quiz17 from '../assets/test1.png'
import quiz18 from '../assets/test1.png'
import quiz19 from '../assets/test1.png'
import quiz20 from '../assets/test1.png'
import quiz21 from '../assets/test1.png'

import goedImage from '../assets/test3.png'
import foutImage from '../assets/image.png'

const showPopup = ref(false)
const popupMessage = ref('')
const popupCorrect = ref(false)
const currentQuestion = ref(0)
const goedAantal = ref(0)
const foutAantal = ref(0)
const quizKlaar = ref(false)
const popupImage = ref('')

const questions = [
  {
    text: 'Waar komt ongeveer een derde van het drinkwater op aarde vandaan',
    correct: 0,
    images: [quiz1, quiz2, quiz3]
  },
  {
    text: 'Waarom is grondwater belangrijk voor planten?',
    correct: 1,
    images: [quiz4, quiz5, quiz6]
  },
  {
    text: 'Wat gebeurt er met een deel van het regenwater dat op de grond valt?',
    correct: 2,
    images: [quiz1, quiz4, quiz5]
  },
  {
    text: 'Waarvoor wordt grondwater in Nederland veel gebruikt?',
    correct: 2,
    images: [quiz1, quiz4, quiz5]
  },
  {
    text: 'Wat is een risico van te veel grondwater oppompen?',
    correct: 0,
    images: [quiz1, quiz4, quiz5]
  },
  {
    text: 'Hoe wordt grondwater meestal naar boven gehaald?',
    correct: 0,
    images: [quiz1, quiz4, quiz5]
  },
  {
    text: 'Welke uitspraak over regenwater is juist?',
    correct: 0,
    images: [quiz1, quiz4, quiz5]
  }
]

function fireConfetti() {
  const count = 200

  const defaults = {
    origin: {y: 0.7}
  }

  function fire(particleRatio, opts) {
    confetti({
      ...defaults,
      ...opts,
      particleCount: Math.floor(count * particleRatio)
    })
  }

  fire(0.25, {
    spread: 26,
    startVelocity: 55
  })

  fire(0.2, {
    spread: 60
  })

  fire(0.35, {
    spread: 100,
    decay: 0.91,
    scalar: 0.8
  })

  fire(0.1, {
    spread: 120,
    startVelocity: 25,
    decay: 0.92,
    scalar: 1.2
  })

  fire(0.1, {
    spread: 120,
    startVelocity: 45
  })
}

function volgendeVraagOfEinde() {
  if (currentQuestion.value < questions.length - 1) {
    currentQuestion.value++
  } else {
    quizKlaar.value = true

    setTimeout(() => {
      resetQuiz()
    }, 4000)
  }
}

function resetQuiz() {
  currentQuestion.value = 0
  goedAantal.value = 0
  foutAantal.value = 0
  quizKlaar.value = false
  showPopup.value = false
}

function checkAnswer(index) {
  if (index === questions[currentQuestion.value].correct) {
    goedAantal.value++

    fireConfetti()

    popupMessage.value = 'Antwoord goed!'
    popupCorrect.value = true
    showPopup.value = true
    popupImage.value = goedImage
  } else {
    foutAantal.value++

    popupMessage.value = 'Antwoord fout!'
    popupCorrect.value = false
    showPopup.value = true
    popupImage.value = foutImage
  }

  setTimeout(() => {
    showPopup.value = false
    volgendeVraagOfEinde()
  }, 1500)
}
</script>

<template>
  <section class="uw-100">
    <div class="container">

      <div class="title-container">
        <p class="title">
          {{ quizKlaar ? 'Quiz klaar!' : 'Kies het juiste plaatje!' }}
        </p>

        <p class="text" v-if="!quizKlaar">
          {{ questions[currentQuestion].text }}
        </p>

        <template v-else>
          <p class="goedeind">Goed: {{ goedAantal }}</p>
          <p class="fouteind">Fout: {{ foutAantal }}</p>
        </template>
      </div>

      <div class="card-container" v-if="!quizKlaar">
        <QuizCard
            v-for="(image, index) in questions[currentQuestion].images"
            :key="index"
            :backgroundImage="image"
            @click="checkAnswer(index)"
        />
      </div>

      <div
          v-if="showPopup"
          class="popup-container"
      >
        <div class="popup-wrapper">
          <img class="image-icon" :src="popupImage" alt=""/>

          <p
              class="popup-text"
              :class="popupCorrect ? 'goed' : 'fout'"
          >
            {{ popupMessage }}
          </p>
        </div>
      </div>

    </div>
  </section>
</template>

<style scoped>
.uw-100 {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba(23, 121, 148, 0.9);
}

.container {
  width: 1240px;
  height: 547px;
  gap: 95px;
  display: flex;
  flex-direction: column;
  padding-bottom: 6rem;
}

.title-container {
  width: 784px;
  height: 130px;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;

  gap: 20px;
  margin: 0 auto;
}

.title {
  margin: 0;

  color: #F4EFE8;
  font-family: "DM Serif Display", sans-serif;
  font-size: 42px;
  font-style: normal;
  font-weight: 400;
  line-height: normal;
}

.text {
  margin: 0;

  color: #F4EFE8;
  width: 784px;

  text-align: center;

  font-family: "DM Serif Display", sans-serif;
  font-size: 28px;
  font-style: normal;
  font-weight: 400;
  line-height: 26px;
}

.card-container {
  width: 100%;

  gap: 80px;
  display: flex;
  justify-content: space-between;

  margin-top: auto;
}

.image-icon {
  height: 4rem;
  width: 4rem;
  background-repeat: no-repeat;
  background-size: cover;
}

.popup-container {
  position: fixed;

  top: 50%;
  left: 50%;

  transform: translate(-50%, -50%);

  display: flex;
  width: 373px;
  align-items: flex-start;
  gap: 32px;

  background: #0B83B7;

  border-radius: 16px;

  z-index: 999;
}

.popup-wrapper {
  width: 100%;
  display: flex;
  padding: 25px;
  flex-direction: column;
  align-items: center;
  gap: 25px;

  border-radius: 16px;
  border: 1px solid #F2F2F2;
}

.popup-text {
  margin: 0;

  color: #F4EFE8;
  text-align: center;

  font-family: Inter, sans-serif;
  font-size: 22px;
  font-style: normal;
  font-weight: 600;
  line-height: normal;
}

.goed {
  color: #7CFFB2;
}

.goedeind {
  font-size: 3rem;
  color: #7CFFB2;
}

.fout {
  color: #FFB3B3;
}

.fouteind {
  font-size: 3rem;
  color: #FFB3B3;
}

.result-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 20px;
}
</style>