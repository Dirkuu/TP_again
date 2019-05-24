using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using DatasLayer;
using Zad4.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Zad4.VIew;

namespace Zad4.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        ObservableCollection<Client> clients;
        ObservableCollection<Bank> Banks;
        DataModel model;
        private Client currentClient;
        public MainViewModel()
        {
            model = new DataModel();
            clients = new ObservableCollection<Client>(model.clients);
            Banks = new ObservableCollection<Bank>(model.banks);
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        public ObservableCollection<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
                this.RaisePropertyChanged("ClientChanged");
            }
        }

        public Client CurrentClient
        {
            get => currentClient;
            set
            {
                currentClient = value;
                NewFirstName = currentClient.firstName;
                NewLastName = currentClient.lastName;
                Coins = (int)currentClient.Cash;
                this.RaisePropertyChanged("CurrentClient");
            }
        }

        private string newFirstName;
        private string newLastName;
        private int coins;
        private void updateCurrentClient()
        {
            currentClient.firstName = NewFirstName;
            currentClient.lastName = NewLastName ;
            currentClient.Cash = Coins;
            Task.Run(() =>DataRepository.UpdateClient(currentClient));

        }

        private ICommand _updateClient;
        public ICommand UpdateClient
        {
            get
            {
                if (_updateClient == null)
                {
                    _updateClient = new RelayCommand(
                    p => this.CanAddClient(),
                    p => this.updateCurrentClient());
                }
                return _updateClient;
            }
        }

        private bool CanAddClient()
        {
            return currentClient == null ? false : true;
        }
       
        private ICommand _handleEdit;
        public ICommand HandleEdit
        {
            get
            {
                if (_handleEdit == null)
                {
                    _handleEdit = new RelayCommand(
                    p => this.CanAddClient(),
                    p => WindowController.ShowWindow());
                }
                return _handleEdit;
            }
        }

        public string NewFirstName { get => newFirstName; set => newFirstName = value; }
        public string NewLastName { get => newLastName; set => newLastName = value; }
        public int Coins { get => coins; set => coins = value; }
    }
}