import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ListingService {
  async createListing(newList) {
    try {
      const res = await api.post('api/listings', newList)
      AppState.itemListings = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async getListings() {
    try {
      const res = await api.get('api/listings')
      AppState.itemListings = res.data
    } catch (error) {
      logger.log(error)
    }
  }
}
export const listingSerivce = new ListingService()
