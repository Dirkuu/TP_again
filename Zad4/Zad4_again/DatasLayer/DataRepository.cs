using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatasLayer
{
    public class DataRepository
    {

        private static DataContextDataContext dataContext = new DataContextDataContext();
        public DataRepository()
        {
            if (!dataContext.DatabaseExists())
                dataContext.CreateDatabase();
        }

        public static void init()
        {
            if (!dataContext.DatabaseExists())
                dataContext.CreateDatabase();
        }

        public static List<Client> GetAllClients()
        {
            return (from Client in dataContext.Clients
                    select Client).ToList();
        }

        public static List<Bank> GetAllBanks()
        {
            return (from Bank in dataContext.Banks
                    select Bank).ToList(); 
        }

        public static void UpdateClient(Client v)
        {
            var query = from Client in dataContext.Clients where Client.Id == v.Id select Client;
            foreach (Client cl in query)
            {
                cl.firstName = v.firstName;
                cl.lastName = v.lastName;
                cl.Cash = v.Cash;
            }
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void UpdateBank(Bank v)
        {
            var query = from Bank in dataContext.Banks where Bank.Id == v.Id select Bank;
            foreach (Bank cl in query)
            {
                cl.Cash = v.Cash;
                cl.Winner = v.Winner;
                cl.Id = v.Id;
            }
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void DeleteBank(Bank V)
        {
            var query = (from Bank in dataContext.Banks
                         where Bank == V
                         select Bank);

            if (query != null)
                foreach (var CL in query)
                {
                    dataContext.Banks.DeleteOnSubmit(CL);
                }
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void DeleteClient(Client V)
        {
            var query = (from clients in dataContext.Clients
                         where clients == V
                         select clients);

            if (query != null)
                foreach (var CL in query)
                {
                    dataContext.Clients.DeleteOnSubmit(CL);
                }
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void CreateClient(Client v)
        {
            dataContext.Clients.InsertOnSubmit(v);
            try
            {
                dataContext.SubmitChanges();

            }
            catch (Exception e)
            {

            }
        }
        public static void CreateBank(Bank v)
        {
            dataContext.Banks.InsertOnSubmit(v);
            try
            {
                dataContext.SubmitChanges();

            }
            catch (Exception e)
            {

            }
        }





    }
}
