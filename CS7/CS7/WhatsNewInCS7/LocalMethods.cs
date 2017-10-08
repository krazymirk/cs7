using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsNewInCS7
{
    public class LocalMethods
    {
        private string localVar;
        public LocalMethods(string localVar) => this.Propery = localVar;
        
        ~LocalMethods() => localVar = null;
        
        public string Propery
        {
            get => localVar;
            set => this.localVar = value ?? throw new ArgumentException("The value of local var cannot be null");
        }

        /// <summary>
        /// Converts name tuples collection into a name collection
        /// </summary>
        /// <param name="nameTuples">The tuples that have to be converted</param>
        /// <returns>A collection of all names in the tuples</returns>
        public static IEnumerable<string> ListNameTupleElements(IEnumerable<(string FirstName, string MiddleName, string FamilyName)> nameTuples)
        {
            if(!nameTuples.Any())
            {
                throw new ArgumentException("The collection of names should not be empty");
            }

            return listNames();

            IEnumerable<string> listNames()
            {
                foreach (var nameTuple in nameTuples)
                {
                    yield return nameTuple.FirstName;
                    yield return nameTuple.MiddleName;
                    yield return nameTuple.FamilyName;
                }
            }
        }
    }
}
