using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatasLayer;

namespace Zad4_again
{
    public class DataCollection
    {

        public IEnumerable<Client> clients
        {
            get
            {
                return DataRepository.GetAllClients();
                 
            }
        }

        public IEnumerable<Bank> banks
        {
            get
            {
                return DataRepository.GetAllBanks();
            }
        }
    }
}
