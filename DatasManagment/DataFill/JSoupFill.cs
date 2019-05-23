using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using Model.Events;

namespace DatasManagment
{
    public class JSoupFill : DataFill
    {
        public void Fill(ref DataContext data)
        {
            {
                string fileName = "Clients.txt";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                string content;
                int counter;
                StreamReader str = new StreamReader(path, Encoding.UTF8);

                while ((content = str.ReadLine()) != null)
                {
                    string[] toSplit;
                    toSplit = content.Split(' ');
                    var Client = new Client{
                        FirstName = toSplit[0],
                        LastName = toSplit[1],
                        ID = (short)Convert.ToInt32(toSplit[2]),
                        Tokens = Convert.ToInt32(toSplit[3])
                    };
                    data.ClientList.Add(Client);
                };

                fileName = "Workers.txt";
                path = Path.Combine(Environment.CurrentDirectory, fileName);
                StreamReader srrtr = new StreamReader(path, Encoding.UTF8);

                while ((content = srrtr.ReadLine()) != null)
                {
                    string[] toSplit;
                    toSplit = content.Split(' ');
                    var worker = new Worker
                    {
                        FirstName = toSplit[0],
                        LastName = toSplit[1],
                        ID = (short)Convert.ToInt32(toSplit[2]),
                    };
                    data.WorkerList.Add(worker);
                };


                fileName = "Machines.txt";
                path = Path.Combine(Environment.CurrentDirectory, fileName);
                StreamReader strc = new StreamReader(path, Encoding.UTF8);
                List<Machines> hold = new List<Machines>();

                while ((content = strc.ReadLine()) != null)
                {
                    string[] toSplit;
                    toSplit = content.Split(' ');
                    var Machine = new Machines()
                    {
                        Id = Convert.ToInt32(toSplit[0]),
                        Name = toSplit[1],
                        Coins = Convert.ToInt32(toSplit[2])
                    };
                    data.MachinesDictionary[Machine.Id.ToString()] = Machine;
                    hold.Add(Machine);
                }


                fileName = "State.txt";
                path = Path.Combine(Environment.CurrentDirectory, fileName);
                StreamReader State = new StreamReader(path, Encoding.UTF8);
                counter = 0;
                while ((content = State.ReadLine()) != null)
                {
                    string[] toSplit;
                    toSplit = content.Split(' ');
                    var mechState = new MachineState()
                    {
                        IsTaken = Convert.ToBoolean(Convert.ToInt32(toSplit[0])),
                        Machine = hold[counter],
                        DateOfUsage = DateTimeOffset.Now,
                        CashInside = counter,
                        IsWorking = Convert.ToBoolean(Convert.ToInt32(toSplit[0])),
                    };
                    data.MachinesState.Add(mechState);
                    ++counter;
                }
                fileName = "Events.txt";
                path = Path.Combine(Environment.CurrentDirectory, fileName);
                StreamReader Events = new StreamReader(path, Encoding.UTF8);
                counter = 0;
                /*_________________________TODO___________________________________
                 * Finish rest of readers, it's going to be the same way as Client
                 */


            }
        }
    }
}
    }
}
