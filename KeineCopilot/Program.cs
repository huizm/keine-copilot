using KeineCopilot.AIModels;
using KeineCopilot.DataModels;

var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
var key = Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY");
const string completionEngine = "keine"; // gpt-35-turbo-instruct
const string  embeddingEngine = "patchouli"; // text-embedding-ada-002

Completion completion = new(endpoint, key, completionEngine);
var dummyPrompt = "When was Microsoft founded?";
var reply = completion.Complete(dummyPrompt);
Console.WriteLine(reply);
