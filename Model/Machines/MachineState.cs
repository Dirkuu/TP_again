using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Model
{
    public class MachineState
    {
        private Machines machine;
        private bool isWorking;
        private double cashInside;
        private DateTimeOffset dateOfUsage;
        private bool isTaken;

        public Machines Machine { get => machine; set => machine = value; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }
        public double CashInside { get => cashInside; set => cashInside = value; }
        public bool IsTaken { get => isTaken; set => isTaken = value; }
        public DateTimeOffset DateOfUsage { get => dateOfUsage; set => dateOfUsage = value; }

        public override string ToString()
        {
            return $"Machine : {machine.ToString()} Availibility : {isTaken} Is working : {isWorking} : date : {DateOfUsage} ";
        }
    }
}
