using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Playground.Game
{
    public class BinaryFileIO : IFileIO
    {
        public void Write<T>(string path, T data) where T : class
        {
            if (!File.Exists(path))
                File.Create(path);

            var serializer = new BinaryFormatter();

            using var stream = new FileStream(path, FileMode.Create);

            serializer.Serialize(stream, data);
        }

        public T Read<T>(string path) where T : class
        {
            var serializer = new BinaryFormatter();

            using var stream = new FileStream(path, FileMode.Create);

            try
            {
                return serializer.Deserialize(stream) as T;
            }
            catch
            {
                return null;
            }
        }
    }
}
