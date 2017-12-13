namespace Contactos3.ViewModels
{
    using Contactos3.Services;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;

    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Attributes
        string _email;
        string _password;
        bool _isToggled;
        bool _isRunning;
        bool _isEnabled;

        #endregion

        #region Services
        DialogService dialogService;
        ApiService apiService;
        NavigationService navigationService;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            Email = "cpalacios@crealodigital.com";
            Password = "123456";

            dialogService = new DialogService();
            apiService = new ApiService();
            navigationService = new NavigationService();

            
            IsEnabled = true;
            IsToggled = true;
        }
        #endregion


        #region Properties
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));

                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));

                }
            }
        }

        public bool IsToggled
        {
            get
            {
                return _isToggled;
            }
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsToggled)));

                }
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));

                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));

                }
            }
        }


        #endregion




        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        


        async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await dialogService.ShowMessage("Error", "You  must enter an email.");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Error", "You  must enter an password.");
                return;
            }
            IsRunning = true;
            IsEnabled = false;


            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var response = await apiService.GetToken("http://contactos3api.azurewebsites.net", 
                                                       Email, 
                                                       Password);
            if (response == null)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", "The service is not available, please try latter.");
                Password = null;
                return;
            }
            if (string.IsNullOrEmpty(response.AccessToken))
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", response.ErrorDescription);
                Password = null;
                return;

            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = response;
            mainViewModel.Perfils = new PerfilsViewModel();

            await navigationService.Navigate("PerfilsView");
                
            IsRunning = false;
            IsEnabled = true;
        }
        #endregion
    }

}

