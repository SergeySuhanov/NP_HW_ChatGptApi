using NP_ChatGptApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_ChatGptApi
{
    public class ChatCompletionContent
    {
        public string Content { get; set; }

        public override string ToString()
        {
            string message = @"{""model"": ""gpt-3.5-turbo"", ""messages"": [{""role"": ""user"", ""content"": """;
            message += Content;
            message += @"""}]}";
            return message;
        }
    }
}