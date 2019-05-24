using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using DatasLayer;
using Zad4.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Zad4.VIew;
using Zad4.DataService;
using System.ComponentModel;
using System.Text.RegularExpressions;

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
    public class MainViewModel : ViewModelBase , IDataErrorInfo
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        ObservableCollection<Client> clients;
        ObservableCollection<Bank> banks;
        DataModel model;
        private Client currentClient;
        private Bank currentBank;
        public MainViewModel()
        {
            model = new DataModel();
            clients = new ObservableCollection<Client>(model.clients);
            banks = new ObservableCollection<Bank>(model.banks);
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


        public ObservableCollection<Bank> Banks
        {
            get
            {
                return banks;
            }
            set
            {
                banks = value;
                this.RaisePropertyChanged("BankChanged");
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

        private int Cash;
        private int Winner;
        public Bank CurrentBank
        {
            get => currentBank;
            set
            {
                currentBank = value;
                Winner = (int)currentBank.Winner;
                Coins = (int)currentBank.Cash;
                this.RaisePropertyChanged("CurrentBank");
            }
        }


        private string newFirstName;
        private string newLastName;
        private int coins;
        private int betAmmount = 0;
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

        private ICommand _handleNewClient;
        public ICommand HandleNewClient
        {
            get
            {
                if(_handleNewClient == null)
                {
                    _handleNewClient = new RelayCommand(
                        p =>
                        {
                            return NewFirstName != null && NewLastName != null;
                        },
                        p =>
                        {
                            var client = new Client
                            {
                                firstName = newFirstName,
                                lastName = NewLastName,
                                Cash = 0,
                                Id = clients.Last<Client>().Id + 1
                            };
                            clients.Add(client);
                            Task.Run(() =>DataRepository.CreateClient(client));
                        });

                }
                return _handleNewClient;
            }
        }
        private ICommand _deteleCLient;
        public ICommand DeleteClient
        {
            get
            {
                if (_deteleCLient == null)
                {
                    _deteleCLient = new RelayCommand(
                        p => CanAddClient(),
                        p =>
                        {
                            clients.Remove(currentClient);
                            Task.Run(() => DataRepository.DeleteClient(currentClient));
                        });
                } return _deteleCLient;
            }
        }

        private ICommand _handleGamble;
        public ICommand HandleGamble
        {
            get
            {
                if (_handleGamble == null)
                {
                    _handleGamble = new RelayCommand(
                        p => true,
                        p =>
                        {
                            Gamble.GambleWithDices(currentClient, currentBank, betAmmount);
                            this.RaisePropertyChanged("PropertyChanged");
                        }
                        );
                }
                return _handleGamble;
            }
        }

        string IDataErrorInfo.Error => throw new NotImplementedException();
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                return GetValidationError(columnName);
            }
        }
        //TODO FINISH VALIDATIONS
        static readonly string[] ValidatesProperties =
        {
            "NewFirstName",
            "NewLastName",
           
        };

        string GetValidationError(string columnName)
        {

            string error = null;

            switch (columnName)
            {
                case "NewFirstName":
                    error = ValidateClientName();
                    break;
                case "NewLastName":
                    error = ValidateClientLastName();
                    break;
            }
            return error;
        }
        string ValidateClientName()
        {
            if (String.IsNullOrWhiteSpace(newFirstName))
                return "Name Cannot be Empty";
            if (!Regex.IsMatch(newFirstName, @"^[a-zA-Z]+$"))
                return "Name cannot contain special characters";
            return null;
        }
        string ValidateClientLastName()
        {
            if (String.IsNullOrWhiteSpace(newLastName))
                return "Last Name Cannot be Empty";
            if (!Regex.IsMatch(newLastName, @"^[a-zA-Z]+$"))
                return "Last Name cannot contain special characters";
            return null;
        }
        string ValidateClientPesel()
        {
            /*if (String.IsNullOrWhiteSpace(newPesel))
                return "Name Cannot be Empty";
            if (!Regex.IsMatch(newFirstName, @"^[a-zA-Z]+$"))
                return "Name cannot contain special characters or numbers";
                */
            return null;
        }
        public bool isValid
        {
            get
            {
                foreach (string property in ValidatesProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return true;
            }
        }

        public string NewFirstName { get => newFirstName; set => newFirstName = value; }
        public string NewLastName { get => newLastName; set => newLastName = value; }
        public int Coins { get => coins; set => coins = value; }
        public int BetAmmount { get => betAmmount; set => betAmmount = value; }
    }
}