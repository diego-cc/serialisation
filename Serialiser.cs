using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SerialisationExercise
{
    class Serialiser
    {
        public static void Serialise(string fileName, ISerializable objectToSerialise)
        {
            Stream stream = null;

            try
            {
                stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();

                b.Serialize(stream, objectToSerialise);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Serialisation exception: Could not serialise file");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O Error: could not create file");
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unauthorised Error: could not access file");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
