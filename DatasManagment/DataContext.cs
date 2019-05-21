using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Model.Events;

namespace DatasManagment
{
    public class DataContext
    {
        private IEnumerable<Client> clientList;
        private IEnumerable<MachineState> machinesState;
        private ObservableCollection<Event> eventCollection;
        private Dictionary<string, Machines> machinesDictionary;

        public DataContext()
        {
            MachinesState = new List<MachineState>();
            ClientList = new List<Client>();
            EventCollection = new ObservableCollection<Event>();
            EventCollection.CollectionChanged += Events_CollectionChanged;
        }

        public IEnumerable<Client> ClientList { get => clientList; set => clientList = value; }
        public IEnumerable<MachineState> MachinesState { get => machinesState; set => machinesState = value; }
        public ObservableCollection<Event> EventCollection { get => eventCollection; set => eventCollection = value; }

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
