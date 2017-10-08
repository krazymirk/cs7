using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsNewInCS7
{
    public class PatternMatching
    {

        /// <summary>
        /// Returns a tuple, from an array or IEnumerable
        /// </summary>
        /// <param name="values">The collection that will be returned as a tuple. It has to have 3 elements, or an exception will be thrown</param>
        /// <returns></returns>
        public static (string FirstName, string MiddleName, string FamilyName) ConvertTotTuple(object values)
        {
            if (values is int num)
            {
                throw new ArgumentException($"Only arrays and IEnnumerable implementations are allowed. The number {num} was passed");
            }
            else if (!(values is string[] || values is string || values is IEnumerable<string>))
            {
                throw new ArgumentException("Only string[] and IEnnumerable<string> implementations are allowed.");
            }
            switch (values)
            {
                case string val:
                    return (val, null, null);
                case IEnumerable<string> list when list.Any() && list.Count() == 3:
                    using (var e = list.GetEnumerator())
                    {
                        e.MoveNext();
                        var first = e.Current;
                        e.MoveNext();
                        var middle = e.Current;
                        e.MoveNext();
                        var last = e.Current;
                        return (first, middle, last);
                    }
                case string[] array when array.Length == 3:
                    return (array[0], array[1], array[2]);
                case null:
                    throw new ArgumentException("Null is not acceptable as an argument");
                default:
                    throw new ArgumentException("The elements in the collection should be 3 - First, Middle and Family name");
            }
        }
    }
}
