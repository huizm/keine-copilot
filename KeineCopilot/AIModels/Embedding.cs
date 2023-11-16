using Azure;
using Azure.AI.OpenAI;

namespace KeineCopilot.AIModels;

public class Embedding
{
    private readonly string _endpoint;
    private readonly string _key;
    private readonly string _deployment;

    public Embedding(string endpoint, string key, string deployment)
    {
        _endpoint = endpoint;
        _key = key;
        _deployment = deployment;
    }
}
