const IPFS = require('ipfs-api');
const ipfsInstance = new IPFS({ host: 'localhost', port: 8083, protocol: 'http' });

class IPFSService {
    constructor() {
        this.instance = ipfsInstance;
    }

    storeFile(buffer) {
        var promise = new Promise((resolve, reject) => {
            this.instance.add(buffer, (err, ipfsHash) => {
                resolve(ipfsHash);
            });
        })
        return promise;
    }
}

module.exports = new IPFSService();