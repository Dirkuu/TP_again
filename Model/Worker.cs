using System;

namespace Model
{
    public class Worker
    {
        private string firstName;
        private string lastName;
        private short id;

        public short ID { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
    }
}
