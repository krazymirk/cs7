// Copyright 2017 Krasimir Kostadinov. All rights reserved. Use of this source code is governed by the Apache License 2.0, as found on https://www.apache.org/licenses/LICENSE-2.0

using System;

namespace WhatsNewInCS7
{
    public static class DeconstructionExtensions
    {
        public static void Deconstruct(this DateTime date, out int month, out int day, out int year)
        {
            day = date.Day;
            month = date.Month;
            year = date.Year;
        }
    }

    public class Person
    {
        private string _firstName;
        private string _middleName;
        private string _familyName;

        public Person()
        {
        }

        public Person(string FirstName, string MiddleName, string FamilyName) : this()
        {
            _firstName = FirstName;
            _middleName = MiddleName;
            _familyName = FamilyName;
        }

        public void Deconstruct(out string FirstName, out string MiddleName, out string FamilyName)
        {
            FirstName = _firstName;
            MiddleName = _middleName;
            FamilyName = _familyName;
        }
    }
}
