using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatasLayer;

namespace Zad4.DataService
{
    public static class Gamble
    {

        private static int ClientThrow = 0;
        private static int BankThrow = 0;

        public static int ClientThrow1 { get => ClientThrow; set => ClientThrow = value; }
        public static int BankThrow1 { get => BankThrow; set => BankThrow = value; }

        public static void GambleWithDices (Client c, Bank b, int bet)
        {
            Random mach = new Random();
            ClientThrow1 = mach.Next(7);
            BankThrow1 = mach.Next(7);


            if (c.Cash >= bet)
            {
                if (ClientThrow1 > BankThrow1)
                {
                    c.Cash += bet;
                    b.Cash -= bet;
                    b.Winner = c.Id;
                    DataRepository.UpdateClient(c);
                    DataRepository.UpdateBank(b);
                }
                else
                {

                    c.Cash -= bet;
                    b.Cash += bet;
                    DataRepository.UpdateClient(c);
                    DataRepository.UpdateBank(b);
                }
            }
        }
    }
}
