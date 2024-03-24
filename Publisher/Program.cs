

using PopGCPPubSub.Publisher;

var projectId = "gcp-demo";
var topicId = "test-pub";

await PublishMessage.InitialConfigAsync(projectId, topicId);

Console.WriteLine(
@"Write a message and press ENTER to send.  Write 'quit' to exit
--------------------------------------------------------------"
);

while (true)
{
    var message = Console.ReadLine() ?? "";
    await PublishMessage.PublishMessagesAsync(projectId, topicId, message);

    if (message?.Trim().ToLowerInvariant() == "quit")
        break;
}
