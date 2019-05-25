using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Events;

namespace DatasManagment
{
    public class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository datRep)
        {
            this.dataRepository = datRep;
        }

        public void FillMachine(Machines argMachine, Worker argWorker, int coins)
        {
            if (dataRepository.GetMachineState(argMachine).IsWorking
                && dataRepository.GetMachineState(argMachine).IsTaken == false) {
                var Event = new FillMachine(argWorker, argMachine, coins);
                dataRepository.AddEvent(Event);
                }


        }

        public void UseMachine(int a, int b, Client argClient, Machines argMachine)
        {
            if (dataRepository.GetMachineState(argMachine).IsWorking == true &&
                dataRepository.GetMachineState(argMachine).IsTaken == false &&
                dataRepository.GetClient(argClient.ID).Tokens > 0)


            {
        
                var Event = new UseMachine(a, b, argClient, argMachine);
                dataRepository.AddEvent(Event);
                dataRepository.GetMachineState(argMachine).IsTaken = true;
                dataRepository.GetClient(argClient.ID).Tokens--;

            }
        }

        public void AddMachine(Machines Name)
        {
            if (!dataRepository.DataBase.MachinesDictionary.ContainsKey(Name.Id.ToString()))
                dataRepository.AddMachine(Name);
            else throw new Exception("You cannot add existing machine!");
        }

        public void AddClient(Client Name)
        {
            dataRepository.AddClient(Name);
                            }
        public void AddWorker(Worker name)
        {
            dataRepository.AddWorker(name);
        }
        public void AddState(MachineState state)
        {
            if (!dataRepository.DataBase.MachinesState.Contains(state))
                dataRepository.AddState(state);
            else throw new Exception("This state already exist ");
        }
        public void DeleteMachine(Machines name)
        {
            if (dataRepository.DataBase.MachinesDictionary.Count == 0)
                throw new Exception("There are no Maachines to delete!");
            if (dataRepository.DataBase.MachinesDictionary.ContainsKey(name.Id.ToString()))
                dataRepository.DeleteMachine(name);
            else throw new Exception("Data base doesn't contain machine like that!");
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
        public string ShowMachines(IEnumerable<Machines> machines)
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
