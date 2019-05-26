using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Events;

namespace DatasManagment
{
    public class DataRepository
    {
       
        private DataContext dataBase;
        private DataFill filler;

        public DataContext DataBase { get => dataBase; set => dataBase = value; }

        public DataRepository(DataFill fill)
        {

            dataBase = new DataContext();
            filler = fill;
        }

        public void init ()
        {
            filler.Fill(ref dataBase);

        }

        public void AddClient(Client name)
        {

            this.DataBase.ClientList.Add(name);
        }

        public void AddWorker(Worker name)
        {

            this.DataBase.WorkerList.Add(name);
        }

        public void AddMachine(Machines machineId)
        {
            this.DataBase.MachinesDictionary.Add(machineId.Name, machineId);
        }
        public void AddEvent(Event eventName)
        {
            this.DataBase.EventCollection.Add(eventName);
        }
        public void AddState(MachineState sName)
        {
            //this.dataBase.EventCollection.CollectionChanged+=dataBase.
            this.dataBase.MachinesState.Add(sName);
        }
        public void UpdateState(MachineState vStateNameOld, MachineState vStateNew)
        {
            vStateNameOld.CashInside = vStateNew.CashInside;
            vStateNameOld.IsTaken = vStateNew.IsTaken;
            vStateNameOld.IsWorking = vStateNew.IsWorking;
            vStateNameOld.Machine = vStateNew.Machine;

        }

        public Machines GetMachine(string id)
        {
            return DataBase.MachinesDictionary[id];
        }
        public IEnumerable<Machines> GetAllMachines()
        {
            return DataBase.MachinesDictionary.Values;
        }

        public IEnumerable<Human> GetAllWorkers()
        {
            return DataBase.WorkerList;
        }
        public void UpdateMachine(string id, Machines name)
        {
            DataBase.MachinesDictionary[id] = name;
        }
        public MachineState GetMachineState(Machines name)
        {
            return DataBase.MachinesState.Find(x => x.Machine == name);
        }
        public IEnumerable<MachineState> GetAllStates()
        {
            return DataBase.MachinesState;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return DataBase.EventCollection;
        }
        public IEnumerable<Human> GetAllClients()
        {
            return DataBase.ClientList;
        }
        //Not sure about this one, did it like thi becaus of UMLS
        public void DeleteMachine(Machines name)
        {
            DataBase.MachinesDictionary.Remove(name.Name);
        }
        public Client GetClient(int id)
        {
            return (Client)DataBase.ClientList.Find( x=> x.ID == id);
        }
        public void UpdateClient(int id, Client name)
        {
            DataBase.ClientList[id] = name;

        }
        public void DeleteClient(Client name)
        {
            DataBase.ClientList.Remove(name);
        }

        public void DeleteState(MachineState name)
        {
            DataBase.MachinesState.Remove(name);
        }
    }
}
   
