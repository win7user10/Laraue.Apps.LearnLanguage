<template>
  <link
      href="https://fonts.googleapis.com/css2?family=Source+Sans+Pro:ital,wght@0,400;1,700&display=swap"
      rel="stylesheet"
  />
  <link
      href="https://fonts.googleapis.com/icon?family=Material+Icons"
      rel="stylesheet"
  />
  <div class="content">
    <main>
      <router-view />
    </main>
  </div>
</template>

<style scoped>
.content {
  display: flex;
  gap: 20px;
}
</style>
<script setup lang="ts">
</script>