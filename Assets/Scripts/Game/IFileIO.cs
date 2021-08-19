namespace Playground.Game
{
    public interface IFileIO
    {
        void Write<T>(string path, T data);
        T Read<T>(string path);
    }
}
