<template>
  <div class="create-listing">
    <form class="form-group" @submit.prevent="createListing">
      <input
        type="text"
        class="form-control"
        aria-describedby="nameId"
        v-model="state.newListing.name"
        placeholder="Item name..."
      />
      <textarea
        rows="15"
        class="form-control"
        aria-describedby="description"
        v-model="state.newListing.description"
        placeholder="Description..."
      />
      <input
        type="number"
        class="form-control"
        min="1"
        step="any"
        aria-describedby="price"
        v-model="state.newListing.price"
        placeholder="0"
      />
      <button type="submit" class="btn btn-primary">
        Post
      </button>
    </form>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { logger } from '../utils/Logger'
export default {
  name: 'CreateListing',
  setup() {
    const state = reactive({
      newListing: {}
    })
    return {
      state,
      createListing() {
        logger.log(state.newListing)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
