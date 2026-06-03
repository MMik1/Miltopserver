```
<script setup>

</script>

<template>
  <div id="background">
    <div class="logo-container">
      <a class="image" href="https://www.linkedin.com/company/miltop-bv/" target="_blank"></a>
    </div>
    <div class="icon-container">
      <a class="linkedin-icon" href="https://www.linkedin.com/company/miltop-bv/" target="_blank"></a>
      <a class="mail-icon" href="mailto:info@mailtop.nl"></a>
      <a class="telefoon-icon" href="tel:+31736235843"></a>
    </div>
  </div>
</template>

<style scoped>
#background{
  background: white;
  display: flex;
  width: 100%;
  height: 209px;
  padding: 10px 50px;
  justify-content: space-between;
  align-items: center;
  box-sizing: border-box;
}
.logo-container {
  display: flex;
  width: 21.24rem;
  height: 10rem;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  flex-shrink: 0;
}
.image{
  height: 115px;
  align-self: stretch;
  aspect-ratio: 263/89;
  background: url(../assets/logo.png);
  background-repeat: no-repeat;
  background-size: cover;
}
.icon-container {
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 36px;
  min-width: 216px;
}
.linkedin-icon{
  background: url(../assets/Linkedin.png);
  background-repeat: no-repeat;
  border: 4px solid black;
  border-radius: 10px;
  height: 48px;
  width: 48px;
  cursor: pointer;
}
.mail-icon{
  background: url(../assets/Mail.png);
  background-repeat: no-repeat;
  border: 4px solid black;
  border-radius: 10px;
  height: 48px;
  width: 48px;
  cursor: pointer;
}
.telefoon-icon{
  background: url(../assets/Phone.png);
  background-repeat: no-repeat;
  border: 4px solid black;
  border-radius: 10px;
  height: 48px;
  width: 48px;
  cursor: pointer;
}
</style>