using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyMangerLibrary.Model
{
    public class Serializer
    {
        public static void Serialize(List<Movies> movies, string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, movies);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }

        public static List<Movies> Deserialize(string filePath)
        {
            List<Movies> movies = new List<Movies>();

            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    if (fileStream.Length > 0)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        movies = (List<Movies>)formatter.Deserialize(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return movies;
        }
    }
}
