using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Playground.Game
{
    public class JsonFileIO : IFileIO
    {
        public void Write<T>(string path, T data)
        {
            if (!File.Exists(path))
                File.Create(path);
                
            var json = JsonUtility.ToJson(data);
            
            using (var stream = new StreamWriter(path))
            {
                stream.Write(json);
            }
            
            // var serializer = new JsonSerializer();
            //
            // using (var stream = new FileStream(path, FileMode.Create))
            // {
            //     serializer.Serialize(stream, data);
            // }
        }

        public T Read<T>(string path)
        {
            if (!File.Exists(path))
                return default;
            
            try
            {
                using (var stream = new StreamReader(path))
                {
                    var json = stream.ReadToEnd();
                    var data = JsonUtility.FromJson<T>(json);

                    return data;
                }
            }
            catch
            {
                return default;
            }
        }
    }
}
