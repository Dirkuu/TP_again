using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Events

namespace DatasManagment
{
    public class DataService
    {
        private DataRepository dataRepository;

        public DataRepository DataRepository { get => dataRepository; set => dataRepository = value; }

        public void AddVehicle(Machines Name)
        {
            if (!dataRepository.DataBase.MachinesDictionary.ContainsKey(Name.Id.ToString()))
                dataRepository.AddMachine(Name);
            else throw new Exception("You cannot add existing vehicle!");
        }
        public void AddState(MachineState state)
        {
            if (!dataRepository.DataBase.MachinesState.Contains(state))
                dataRepository.AddState(state);
            else throw new Exception("This state already exist ");
        }
        public void DeleteVehicle(Machines name)
        {
            if (dataRepository.DataBase.MachinesDictionary.Count == 0)
                throw new Exception("There are no Maachines to delete!");
            if (dataRepository.DataBase.MachinesDictionary.ContainsKey(name.Id.ToString()))
                dataRepository.DeleteMachine(name);
            else throw new Exception("Data base doesn't contain vehicle like that!");
        }
        public void DeleteState(MachineState name)
        {
            if (dataRepository.DataBase.MachinesState.Count == 0)
                throw new Exception("There are no states to delete!");
            if (dataRepository.DataBase.MachinesState.Contains(name))
                dataRepository.DeleteState(name);
            else throw new Exception("Data base doesn't contain state like that!");

        }
        public void DeleteClient(Client name)
        {
            if (dataRepository.DataBase.ClientList.Count == 0)
                throw new Exception("There are no clients to detele!");
            if (dataRepository.DataBase.ClientList.Contains(name))
                dataRepository.DeleteClient(name);
            else throw new Exception("Data base doesn't contain state like that!");
        }
        public string ShowVehicles(IEnumerable<Machines> machines)
        {
            string machinesReport = "";
            foreach (var x in machines)
            {
                machinesReport += x + "\n";
            }
            return machinesReport;
        }
        public string ShowClients(IEnumerable<Client> Clients)
        {
            string clientReport = "";
            foreach (var x in Clients)
            {
                clientReport += x + "\n";
            }
            return clientReport;
        }
        public string ShowStates(IEnumerable<MachineState> machines)
        {
            string machinesReport = "";
            foreach (var x in machines)
            {
                machinesReport+= x + "\n";
            }
            return machinesReport;
        }
        public string ShowEvents(IEnumerable<Event> eventReport)
        {
            string eventsReport = "";
            foreach (var x in eventReport)
            {
                eventsReport += x + "\n";
            }
            return eventsReport;
        }
        public string ShowBinded()
        {
            string Binded = "";
            foreach (var Clients in dataRepository.GetAllClients())
            {
                Binded += Clients + "\n";
                foreach (var Events in dataRepository.GetAllEvents())
                {
                    if (Events.Client == Clients)
                    {
                        Binded += Events.ToString() + "\n";
                    }
                }
                Binded += "\n\n";
            }
            return Binded;
        }


    }
}
