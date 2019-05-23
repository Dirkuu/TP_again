using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Events
{
    public class UseMachine : Event
    {

        private int outCome;

        public UseMachine (int a, int b, Client arg, Machines argMachines)
        {
            this.Client = arg;
            this.Machine = argMachines;
            outCome = Gamble(a, b);

        }
        private int Gamble (int a, int b)
        {
            Random rand = new Random();
            return rand.Next(a, b) ;
        }

        public Client Client { get => Client; set => Client = value; }

    }
}
