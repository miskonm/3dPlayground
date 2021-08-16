namespace Playground
{
    public static class MonoExtension
    {
        public static T NotNull<T>(this T obj) where T : UnityEngine.Object
        {
            return obj == null ? null : obj;
        }
    }
}
