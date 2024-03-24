
using PopGCPPubSub.Subscriber;

Console.WriteLine("Starting subscriber...");

var projectId = "gcp-demo";
var topicId = "test-pub";
var subscriptionId = "test-sub";

await SubscribeMessage.InitialConfigAsync(projectId, topicId, subscriptionId);

await SubscribeMessage.PullMessagesAsync(projectId, subscriptionId);
