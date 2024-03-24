# Google Cloud Pub/Sub with .NET 8 and Docker

This repository provides a environment for working with Google Cloud Pub/Sub using a Docker and .NET 

For this example, we use a Google Cloud Pub/Sub Docker images: 
    - https://github.com/marcelcorso/gcloud-pubsub-emulator
    - ghcr.io/neoscript/pubsub-emulator-ui:latest

See the docs here if you'd like to learn more: https://cloud.google.com/pubsub/docs/overview
see the doc here if you'd like to know about the pubsub-emulator-ui project: https://github.com/NeoScript/pubsub-emulator-ui


## Running the Code

```
docker-compose up
```
Next, Open this path: http://localhost:7200 in your browser to see a pub/sub UI.
For this default demo, in this UI, creating a new project with value: gcp-demo

Next, run the publisher and the subscriber:

```
cd publisher
dotnet run
```

and:

```
cd subscriber
dotnet run
```
Next, click in F5 key to reload the UI, you can see the Topics and Subscriptions.
