docker run -d --name ipfs-node \
  -v /tmp/ipfs-docker-staging:/export -v /tmp/ipfs-docker-data:/data/ipfs \
  -p 8083:8080 -p 4001:4001 -p 127.0.0.1:5001:5001 \
  jbenet/go-ipfs:latest