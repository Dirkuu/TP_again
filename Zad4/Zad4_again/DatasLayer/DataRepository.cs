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

    }
}
