using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Events
{
    public class FillMachine : Event
    {
        private Worker worker;
        private int ammountAdded;


        public FillMachine (Worker argWorker, Machines argMachine, int a)
        {
            this.worker = argWorker;
            this.Machine = argMachine;
            this.Machine.addCoins(a);
        }
        public Worker Worker { get => worker; set => worker = value; }

    }
}
