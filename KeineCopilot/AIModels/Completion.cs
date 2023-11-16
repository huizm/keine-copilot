using Azure;
using Azure.AI.OpenAI;

namespace KeineCopilot.AIModels;

public class Completion
{
    private readonly string _endpoint;
    private readonly string _key;
    private readonly string _deployment;
    private readonly OpenAIClient _client;

    public Completion(string endpoint, string key, string deployment)
    {
        _endpoint = endpoint;
        _key = key;
        _deployment = deployment;
        _client = new OpenAIClient(new Uri(_endpoint), new AzureKeyCredential(_key));
    }

    public string Complete(string prompt)
    {
        CompletionsOptions completionsOptions = new()
        {
            DeploymentName = _deployment,
            Prompts = { prompt },
        };
        Response<Completions> responses = _client.GetCompletions(completionsOptions);
        var reply = responses.Value.Choices[0].Text;
        return reply;
    }
}
