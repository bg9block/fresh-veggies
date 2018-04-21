const Facade = require('../../lib/facade');
const faresSchema = require('./schema');

class FaresFacade extends Facade {
    find(...args) {
        var promise = new Promise(function (resolve, reject) {
            var array = [{
                title: "Organic Juicy Pineapples in LA", 
                description: "This year brings a nice harvest which exceeds our needs, so we are ready to sell with the discount",
                productName: "Pineapple",
                amountAvailable: 10,
                pricePerMonth: 4,
                pricePerYear: 2,
                ownerName: "OrganicFruits ltd"
            },
            {
                title: "Organic Juicy Oranges in LA", 
                description: "This year brings a nice harvest which exceeds our needs, so we are ready to sell with the discount",
                productName: "Orange",
                amountAvailable: 40,
                pricePerMonth: 2,
                pricePerYear: 1,
                ownerName: "OrganicFruits ltd"
            }];

            resolve(array);
        })
        return promise;
    }
}

module.exports = new FaresFacade(faresSchema);
