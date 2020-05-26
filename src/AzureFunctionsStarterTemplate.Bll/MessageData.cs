using System;

namespace AzureFunctionsStarterTemplate.Bll
{
    public class MessageData
    {
        public Guid Id { get; }
        public string Value { get; }

        public MessageData(Guid id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}