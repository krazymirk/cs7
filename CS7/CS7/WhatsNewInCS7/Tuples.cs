using System;

namespace WhatsNewInCS7
{
    public class Tuples
    {
        /// <summary>
        /// Converts it's arguments into a tuple
        /// </summary>
        /// <param name="items">Expects 3 names - first, middle and family. Exception will be thrown if more or less arguments than 3 are supplied</param>
        /// <returns>A ValueTuple, containing the names</returns>
        public static (string FirstName, string MiddleName, string FamilyName) ConvertToTuple(params string[] items)
        {
            // To use ValueTuples, you should install the Nuget package System.ValueTuple
            if (items == null || items.Length != 3)
                throw new ArgumentException("Three names should be supplied for a tuple to be created.");
            return (items[0], items[1], items[2]);
        }

        /// <summary>
        /// Converts it's arguments into a tuple with no named elements
        /// </summary>
        /// <param name="items">Expects 3 names - first, middle and family. Exception will be thrown if more or less arguments than 3 are supplied</param>
        /// <returns>A ValueTuple, containing the names</returns>
        public static (string, string, string) ConvertToTupleOldStyle(params string[] items)
        {
            return ConvertToTuple(items);
        }
    }
}
