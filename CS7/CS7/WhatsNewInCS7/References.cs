// Copyright 2017 Krasimir Kostadinov. All rights reserved. Use of this source code is governed by the Apache License 2.0, as found on https://www.apache.org/licenses/LICENSE-2.0

using System;
using System.Collections.Generic;

namespace WhatsNewInCS7
{
    public class References
    {
        /// <summary>
        /// Finds a tuple in an array and returns a reference to it
        /// </summary>
        /// <param name="nameToFind">The name of the person that has to be found</param>
        /// <param name="nameTuplesToSearch">The array with tuples to search</param>
        /// <returns>A reference to the tuple that any of the names mathches the nameToFind or throws a KeyNotFound exception if it does not find it  </returns>
        public static ref (string FirstName, string MiddleName, string FamilyName) FindTuple(string nameToFind, (string FirstName, string MiddleName, string FamilyName)[] nameTuplesToSearch)
        {
            nameToFind = nameToFind ?? throw new ArgumentException("The name to find should not be null");
            nameTuplesToSearch = nameTuplesToSearch ?? throw new ArgumentException("The array of names should not be null and should have at least one item");
            for (var i = 0; i < nameTuplesToSearch.Length; i++)
            {
                if (string.Compare(nameTuplesToSearch[i].FirstName, nameToFind, StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(nameTuplesToSearch[i].MiddleName, nameToFind, StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(nameTuplesToSearch[i].FamilyName, nameToFind, StringComparison.OrdinalIgnoreCase) == 0)
                    return ref nameTuplesToSearch[i];
            }
            throw new KeyNotFoundException("The supplied key was not found");
        }
    }
}
