using System.Linq;

namespace SharedLibrary
{
    public static class ReflectionExtensions
    {
        public static void SetValuesFrom<T>(this T original, T newObj) where T : class
        {
            foreach (var prop in original.GetType().GetProperties().Where(p => p.CanWrite))
                prop.SetValue(original, prop.GetValue(newObj));
        }
    }
}
