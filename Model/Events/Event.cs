using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Events
{
    public class Event
    {
        private Machines machine;
        private DateTimeOffset time;
        protected Client client;

        public Machines Machine { get => machine; set => machine = value; }
        public DateTimeOffset Time { get => time; set => time = value; }
        public Client Client { get => client; set => client = value; }
    }
}
