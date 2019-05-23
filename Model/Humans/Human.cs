using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Human
    {
        private string firstName;
        private string lastName;
        private short id;

        public short ID { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }

        public override string ToString()
        {
            return $"first name {FirstName} last name {LastName} ID {ID}";
        }
    }
}
