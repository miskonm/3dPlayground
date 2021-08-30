namespace Playground.Game
{
    public interface IFileIO
    {
        void Write<T>(string path, T data) where T : class;
        T Read<T>(string path) where T : class;
    }
}
