<template>
  <div class="home-page">
    <create-listing />
  </div>
</template>

<script>
import { onMounted } from 'vue'
import { listingSerivce } from '../services/ListingService'
export default {
  name: 'HomePage',
  setup() {
    onMounted(() => listingSerivce.getListings())
    return {

    }
  }

}
</script>

<style scoped lang="scss">

</style>
