using NP_ChatGptApi;
using System.Net.Http.Headers;
using System.Net.Http.Json;

var openAiKey = "pk-KrClgUVPimLgghChTuLnsSRKbWiNSYuytExgVoiikdhquVsA";

using var httpClient = new HttpClient()
{
    DefaultRequestHeaders =
    {
        Authorization = AuthenticationHeaderValue.Parse($"Bearer {openAiKey}")
    }
};

var chatCompletionUri = "https://api.pawan.krd/v1/chat/completions";
var completionContent = new ChatCompletionContent();

Console.WriteLine("Задайте свой вопрос: (напишите exit чтобы выйти из программы)\n");

while (true)
{
    Console.Write("Вы: ");
    completionContent.Content = Console.ReadLine();

    if (completionContent.Content == "")
    {
        Console.WriteLine("напишите свой вопрос\n");
        continue;
    }

    if (completionContent.Content == "exit")
    {
        break;
    }

    var content = new StringContent(completionContent.ToString(), MediaTypeHeaderValue.Parse("application/json"));
    var response = await httpClient.PostAsync(chatCompletionUri, content);
    var chatGptResponse = await response.Content.ReadFromJsonAsync<ChatGptResponse>();

    Console.WriteLine("\nChatGPT ответил: " + chatGptResponse.Choices[0].Message.Content + "\n");
}
