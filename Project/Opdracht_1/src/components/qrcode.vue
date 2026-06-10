<script setup>
function goToPage() {
  window.location.href = '/FinalWebBuild/index.html'
}
</script>

<template>
<section>
<div class="container">
<div class="card">
 <h3 class="title">Speel onze game!</h3>
  <button @click="goToPage">Start</button>
<!-- <div class="image-container">-->

<!-- </div>-->
</div>
</div>
</section>
</template>

<style scoped>
.container{
display: flex;
  justify-content: center;
  align-items: center;
    height: 60vh;
    width: 100vw;
    background: #0E87CC;

}

.card{
display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  width: 650px;
height: 310px;
border-radius: 10px;
background: #036ECE;
}

.title{
color: #F4EFE8;
font-family: "DM Serif Display";
margin-bottom: 0px;
margin-top: 0px;
font-size: 42px;
font-style: normal;
font-weight: 400;
line-height: normal;
}
.image-container{
width: 200px;
height: 200px;
aspect-ratio: 1/1;
background: url(../assets/qr-code.png)
}

button{
  margin-top: 20px;
  font-size: 20px;
  background: #C4191F;
  border-radius: 15px;
  font-weight: bold;
  width: 80px;
  color: #fff;
}
</style> 