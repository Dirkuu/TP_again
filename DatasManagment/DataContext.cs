using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Model.Events;

namespace DatasManagment
{
    public class DataContext
    {
        private List<Human> clientList;
        private List<Human> workerList;
        private List<MachineState> machinesState;
        private ObservableCollection<Event> eventCollection;
        private Dictionary<string, Machines> machinesDictionary;

        public DataContext()
        {
            MachinesState = new List<MachineState>();
            ClientList = new List<Human>();
            WorkerList = new List<Human>();
            EventCollection = new ObservableCollection<Event>();
            machinesDictionary = new Dictionary<string, Machines>();
            EventCollection.CollectionChanged += Events_CollectionChanged;
        }

        public List<Human> ClientList { get => clientList; set => clientList = value; }
        public List<MachineState> MachinesState { get => machinesState; set => machinesState = value; }
        public ObservableCollection<Event> EventCollection { get => eventCollection; set => eventCollection = value; }
        public Dictionary<string, Machines> MachinesDictionary { get => machinesDictionary; set => machinesDictionary = value; }
        public List<Human> WorkerList { get => workerList; set => workerList = value; }

        private void Events_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event?
            Console.WriteLine("Action for this event: {0}", e.Action);

            // They removed something. 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Event p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }

            // They added something. 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:");
                foreach (Event p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

    }
}
