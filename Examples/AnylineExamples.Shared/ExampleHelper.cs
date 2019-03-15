using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnylineExamples.Shared
{
    public static class ExampleHelper
    {
        public static void MoveElementToIndex<T>(this Dictionary<string, T> dict, string identifier, int pos)
        {
            var result = new Dictionary<string, T>();

            if (dict.ContainsKey(identifier))
            {
                var list = dict.ToList();

                var currentIndex = list.FindIndex(x => x.Key == identifier);
                var currentElement = list.ElementAt(currentIndex);

                list.Remove(currentElement);
                list.Insert(pos, currentElement);

                dict.Clear();
                list.ForEach(x => dict.Add(x.Key, x.Value));
            }
        }
    }
}
