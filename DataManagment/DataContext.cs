using System;
using System.Collections.Generic;
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

        private void collectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action for this event: {0}", e.Action);

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the new items:");
                foreach (var p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the old items:");
                foreach (var p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }
        }

        public List<Worker> WorkerList { get => workerList; set => workerList = value; }
        public List<Machine> MachineList { get => machineList; set => machineList = value; }
    }
}
