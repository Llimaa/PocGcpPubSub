
using Google.Api.Gax;
using Google.Cloud.PubSub.V1;

namespace PopGCPPubSub.Subscriber;

public sealed class SubscribeMessage 
{
    public static async Task GetMessagesAsync(string projectId, string subscriptionId, bool acknowledge = true)
    {
        var subscriptionName = new SubscriptionName(projectId, subscriptionId);

        var subscriber = await new SubscriberClientBuilder 
        {
            SubscriptionName = subscriptionName,
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction
        }.BuildAsync();

        await subscriber.StartAsync((message, cancellationToken) =>
        {
            Console.WriteLine($"Received message with Id:  {message.MessageId}, published at {message.PublishTime.ToDateTime()}");
            Console.WriteLine($"Message: '{message.Data.ToStringUtf8()}'");

            return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
        });
    }

    public static async Task InitialConfigAsync(string projectId, string topicId, string subscriptionId)
    {
        Environment.SetEnvironmentVariable("PUBSUB_EMULATOR_HOST", "localhost:8681");
        var subscriptionName = new SubscriptionName(projectId, subscriptionId);
        
        var subscriberService = await new SubscriberServiceApiClientBuilder
        {
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction
        }.BuildAsync();

        var topicName = new TopicName(projectId, topicId);
        subscriberService.CreateSubscription(subscriptionName, topicName, pushConfig: null, ackDeadlineSeconds: 60);
    }
}