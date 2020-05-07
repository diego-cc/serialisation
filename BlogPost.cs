using System;
using System.Runtime.Serialization;

namespace SerialisationExercise
{
    [Serializable]
    class BlogPost : ISerializable
    {
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public BlogPost()
        {

        }

        public BlogPost(SerializationInfo info, StreamingContext ctxt)
        {
            Id = (ulong)info.GetValue("Id", typeof(ulong));
            UserId = (ulong)info.GetValue("UserId", typeof(ulong));
            Title = (string)info.GetValue("Title", typeof(string));
            Content = (string)info.GetValue("Content", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("UserId", UserId);
            info.AddValue("Title", Title);
            info.AddValue("Content", Content);
        }

        public override string ToString()
        {
            return $"Id: {Id}, UserId: {UserId}, Title: {Title}, Content: {Content}";
        }
    }
}
