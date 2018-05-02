const Controller = require('../../lib/controller');
const faresFacade = require('./facade');
const ipfsService = require('../../services/ipfsService');
const fs = require('fs');


class FaresController extends Controller {
    manifestAgreement(req, res, next) {
        var promise = new Promise((resolve, reject) => {
            fs.readFile("/Users/I_L_I_A/Projects/test.txt", "utf8", function(err, data) {
                if(!ipfsService){
                    reject("ipfsService not present");
                    return;
                }
                var hash = null;
                ipfsService.storeFile(data).then((hash) => {
                    if(!hash){
                        reject("failed to store in ipfs");
                        return;
                    }
                    res.status(200).json({hash: hash});
                    resolve({hash: hash});
                });
            });
        });
        return promise;
    }
}

module.exports = new FaresController(faresFacade);
