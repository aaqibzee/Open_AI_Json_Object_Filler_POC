using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;


class Program
{
    static async Task Main()
    {
        await ProcessUserInput();
    }

    public static async Task ProcessUserInput()
    {
        try
        {
            Console.WriteLine("Tell me what kind of credit card you want, type some benefits that you are looking for and press enter!");
            string? prompt = Console.ReadLine();
            Console.WriteLine("\n" + ".....Processing your data.....");
            await ExecuteAPIRequestAsync(Constants.apiKey, Constants.endPointUrl, Constants.modelType, Constants.maxTokens, prompt);
            await CheckRetry();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occured while parsing the response. Exception:" + ex.Message);
            await CheckRetry();
        }
    }

    public static async Task CheckRetry()
    {
        Console.WriteLine("\n" + "Press 'R' to get my suggestion again or any other key to exit!");
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.R)
        {
            Console.WriteLine();
            await ProcessUserInput();
        }
    }

    public static async Task ExecuteAPIRequestAsync(string apiKey, string endPoint, string modelType, int maxtokens, string prompt)
    {
        var api = new OpenAIAPI(apiKey);
        var chatRequest = new ChatRequest()
        {
            Model = modelType,
            ResponseFormat = ChatRequest.ResponseFormats.JsonObject,
            Messages = new List<ChatMessage>()
            {
                new ChatMessage()
                {
                    TextContent = Constants.SystemConent,
                    Role = ChatMessageRole.System,
                },
                new ChatMessage()
                {
                    TextContent = prompt,
                    Role = ChatMessageRole.User,
                }
            }
        };

        var result = await api.Chat.CreateChatCompletionAsync(chatRequest);
        string? content = String.Empty;

        try
        {
            content = result.Choices[0]?.Message?.Content;
            if (!string.IsNullOrEmpty(content))
            {
                var card = JsonConvert.DeserializeObject<CreditCard>(content);

            }
            Console.WriteLine("\n" + "You are looking for a card with these specifications: " + content);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occured while parsing the response. Exception:" + ex.Message);
        }
    }
}
