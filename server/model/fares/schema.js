const mongoose = require('mongoose');
const Schema = mongoose.Schema;


const faresSchema = new Schema({
  title: { type: String, required: true },
  description: { type: String, required: true },
  productId: { type: Number, required: true },
  productName: { type: String, required: true },
  amountAvailable: { type: Number, required: true },
  pricePerMonth: { type: Number, required: true },
  pricePerYear: { type: Number, required: true }, 
  ownerId: { type: Number, required: true },
  ownerName: { type: String, required: true },
}); 


module.exports = mongoose.model('Fares', faresSchema);
