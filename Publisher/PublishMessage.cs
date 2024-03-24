using Google.Cloud.PubSub.V1;
using Google.Api.Gax;

namespace PopGCPPubSub.Publisher;

public static class PublishMessage 
{
    public static  async Task PublishMessagesAsync(string projectId, string topicId, string message)
    {
        Console.WriteLine("Starting publisher...");

        var topicName = TopicName.FromProjectTopic(projectId, topicId);

        var publisher = await new PublisherClientBuilder 
        {
            TopicName = topicName,
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction
        }.BuildAsync();
        
        try
        {
            await publisher.PublishAsync(message);
            Console.WriteLine($"Published message {message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"An error occurred when publishing message {message}: {exception.Message}");
        }
    }

    public static async Task InitialConfigAsync(string projectId, string topicId)
    {
        Environment.SetEnvironmentVariable("PUBSUB_EMULATOR_HOST", "localhost:8681");
        var publisherService = await new PublisherServiceApiClientBuilder
        {
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction
        }.BuildAsync();

        var topicName = new TopicName(projectId, topicId);

        publisherService.CreateTopic(topicName);
    }
}
