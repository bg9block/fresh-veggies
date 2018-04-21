const Controller = require('../../lib/controller');
const faresFacade = require('./facade');

class FaresController extends Controller {
    
}

module.exports = new FaresController(faresFacade);
