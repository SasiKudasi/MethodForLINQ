using System.Linq;

namespace MethodForLINQ
{
    static class Program
    {
        delegate int Field<T>(T field);
        static void Main(string[] args)
        {
            var rnd = new Random(1);
            var list = new List<int>() { 1, 2, 3, 45, 5, 7, 9, 3, 9 };
            var listTop = list.Top(30);
            foreach (var i in listTop)
            {
                Console.Write($"{i} ");
            }
            var personList = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                personList.Add(new Person());
            }
            foreach(var person in personList)
                person.Age = rnd.Next(60);
            var personsAge = personList.Top(30, person => person.Age);
            Console.WriteLine();
            foreach (Person person in personsAge)
            {
                Console.Write($"{person.Age} ");
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
        static IEnumerable<T> Top<T>(this IEnumerable<T> source, int count, Field<T> field)
        {
            var test = source.Top(count).OrderByDescending(x => field(x));

            var needElementsCount = source.Count() * (count / 100.0);
            if (needElementsCount != (int)needElementsCount)
            {
                needElementsCount++;
            }

            var result = source.OrderByDescending(x=> field(x))
                 .Take((int)needElementsCount);
            return test;
        }

       
    }
}