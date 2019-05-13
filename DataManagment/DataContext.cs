using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DataManagment
{
    class DataContext
    {
        private List<Worker> workerList;
        private List<Machine> machineList;

        public DataContext()
        {
            WorkerList = new List<Worker>();
            MachineList = new List<Machine>();
        }

        public List<Worker> WorkerList { get => workerList; set => workerList = value; }
        public List<Machine> MachineList { get => machineList; set => machineList = value; }
    }
}
