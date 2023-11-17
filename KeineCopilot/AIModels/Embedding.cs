using Azure;
using Azure.AI.OpenAI;

namespace KeineCopilot.AIModels;

public class Embedding
{
    private readonly string _endpoint;
    private readonly string _key;
    private readonly string _deployment;
    private readonly OpenAIClient _client;

    public Embedding(string endpoint, string key, string deployment)
    {
        _endpoint = endpoint;
        _key = key;
        _deployment = deployment;
        _client = new OpenAIClient(new Uri(_endpoint), new AzureKeyCredential(_key));
    }

    public IReadOnlyList<EmbeddingItem> Embed(string input)
    {
        EmbeddingsOptions embeddingsOptions = new()
        {
            DeploymentName = _deployment,
            Input = { input },
        };
        Response<Embeddings> responses = _client.GetEmbeddings(embeddingsOptions);
        // if (responses.HasValue) Console.WriteLine("embedding has value");
        var embeddingVector = responses.Value.Data;
        return embeddingVector;
    }
}
