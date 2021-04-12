<template>
  <div class="cart-page">
    <cart-items />
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'CartPage',
  setup() {
    return {
      cartItems: computed(() => AppState.cartItems)

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
