namespace Contactos3.ViewModels
{
    using Contactos3.Models;
    using Contactos3.Services;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;


    public class MainViewModel
    {
        #region Service
        NavigationService navigationService;
        #endregion
        #region Properties
        public LoginViewModel Login
        {
            get;
            set;
        }
        public PerfilsViewModel Perfils
        {
            get;
            set;
        }
        public TokenResponse Token
        {
            get;
            set;
        }
        public InfoContactsViewModel InfoContacts
        {
            get;
            set;
        }
        public Job Jobs
        {
            get; set;
        }
        public NewContactViewModel NewContacts
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();

            navigationService = new NavigationService();
        }
        #endregion

        #region Sigleton
        static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();

            }
            return instance;
        }
        #endregion
        #region Commands
        public ICommand NewContactCommand
        {
            get
            {
                return new RelayCommand(GoNewContact);
            }
        }

        async void GoNewContact()
        {
            NewContacts = new NewContactViewModel();
            await navigationService.Navigate("NewContactView");
        }
        #endregion
    }

}
