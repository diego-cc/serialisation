using System;
using System.Collections.Generic;

namespace SerialisationExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogPost post1 = new BlogPost
            {
                Id = 1,
                UserId = 1,
                Title = "A Beautiful Scenery",
                Content = "Ain't it pretty?"
            };

            BlogPost post2 = new BlogPost
            {
                Id = 2,
                UserId = 1,
                Title = "Bon Voyage",
                Content = "Off I go!"
            };

            User user = new User
            {
                Id = 1,
                Username = "john",
                Posts = new List<BlogPost> { post1, post2 }
            };

            Serialiser.Serialise("output.txt", user);

            User deserialisedUser = (User) Deserialiser.Deserialise("output.txt");

            Console.WriteLine("Deserialised user:");
            Console.WriteLine(deserialisedUser);
        }
    }
}
