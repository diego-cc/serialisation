using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SerialisationExercise
{
    class Deserialiser
    {
        public static ISerializable Deserialise(string fileName)
        {
            ISerializable objectToDeserialise = null;
            Stream stream = null;

            try
            {
                stream = File.Open(fileName, FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();

                objectToDeserialise = (ISerializable)b.Deserialize(stream);                
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Serialisation exception: Could not deserialise file");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O Error: could not open file");
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

            return objectToDeserialise;
        }
    }
}
