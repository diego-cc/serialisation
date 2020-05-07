using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace SerialisationExercise
{
    [Serializable]
    class User : ISerializable
    {
        public ulong Id { get; set; }
        public string Username { get; set; }

        [XmlArrayItem]
        public IList<BlogPost> Posts { get; set; }

        public User()
        {

        }

        public User(SerializationInfo info, StreamingContext ctxt)
        {
            Id = (ulong)info.GetValue("Id", typeof(ulong));
            Username = (string)info.GetValue("Username", typeof(string));
            Posts = (IList<BlogPost>)info.GetValue("Posts", typeof(IList<BlogPost>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Username", Username);
            info.AddValue("Posts", Posts);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Id: {Id}, Username: {Username}");
            sb.AppendLine();

            foreach (var post in Posts)
            {
                sb.AppendLine(post.ToString());
            }

            return sb.ToString();
        }
    }
}
