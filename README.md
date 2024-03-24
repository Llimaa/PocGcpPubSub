# Google Cloud Pub/Sub with .NET 8 and Docker

This repository provides a publisher and subscriber example with GCP Pub/Sub. 

This project provers a local environment for working with Google Cloud Pub/Sub using a Docker and .NET 

#### For this example, we use those Docker images: 
- messagebird/gcloud-pubsub-emulator:latest
- ghcr.io/neoscript/pubsub-emulator-ui:latest

See the docs here if you'd like to learn more: 
- https://cloud.google.com/pubsub/docs/overview
- https://github.com/NeoScript/pubsub-emulator-ui


## Running the Code

Clone the project

```bash
  git clone https://github.com/Llimaa/PocGcpPubSub
```

Go to the project directory

```bash
  cd PocGcpPubSub
```
Next, up docker environment

```
docker-compose up
```

Next, run the publisher and the subscriber:

```
cd Publisher
dotnet run
```

and:

```
cd Subscriber
dotnet run
```

Next, Open this path: http://localhost:7200 in your browser to see a pub/sub UI.

For this default example, in your UI, create a new project with value: gcp-demo
