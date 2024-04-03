using System.Linq;

namespace MethodForLINQ
{
    static class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int>() { 1, 2, 3, 45, 5, 7, 9, 3, 9 };
            var list1 = list.Top(30);
            foreach (int i in list1)
            {
                Console.Write($"{i} ");
            }

        }

        static IEnumerable<T> Top<T>(this IEnumerable<T> source, int count)
        {
            if (count < 0 || count > 100)
                throw new ArgumentException("Недопустимое значение");

            var needElementsCount = source.Count() * (count / 100.0);
            if (needElementsCount != (int)needElementsCount)
            {
                needElementsCount++;
            }
            var result = source.OrderByDescending(x => x)
                .Take((int)needElementsCount);
            return result;
        }
        static IEnumerable<T> Top<T>(this IEnumerable<T> source, int count, T field)
        {
            return source;
        }
    }
}