using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DatasManagment
{
    public class DataFillStatic : DataFill
    {
        public void Fill(ref DataContext db)
        {
            short counter = 0;
            short k = 15;

            while (k-- != 0)
            {
                Human client = new Client
                {
                    FirstName = "FillMeUp",
                    LastName = "Filll",
                    ID = counter,
                    Tokens = 0,
                };

                Human Worker = new Worker
                {
                    FirstName = "FillMeUp",
                    LastName = "Filll",
                    ID = counter,
                };

                Machines machine = new Machines
                {
                    Id = counter,
                    Name = "To_Be_tested",
                };

                MachineState state = new MachineState
                {
                    IsTaken = false,
                    CashInside = counter,
                    IsWorking = true,
                    Machine = machine,
                };

                counter++;
                db.ClientList.Add(client);
                db.WorkerList.Add(Worker);
                db.MachinesDictionary.Add(machine.Id.ToString(), machine);
                db.MachinesState.Add(state);
            }
        }

    }
}
