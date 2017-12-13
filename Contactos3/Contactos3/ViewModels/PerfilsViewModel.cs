namespace Contactos3.ViewModels
{
    using Contactos3.Models;
    using Contactos3.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    public class PerfilsViewModel : INotifyPropertyChanged
    {

        #region Attributes
        ObservableCollection<Perfil> _perfil;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ObservableCollection<Perfil> Perfils
        {
            get
            {
                return _perfil;
            }
            set
            {
                if(_perfil !=value)
                {
                    _perfil = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Perfils)));
                }
            }
        }
        public string JobPosition
        {
            get;
            set;
        }

        #endregion

        #region Constructos
        public PerfilsViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            LoadPerfils();

        }
        #endregion

        #region Methods
        async void LoadPerfils()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();


            var response = await apiService.GetList<Perfil>("http://contactos3api.azurewebsites.net",
                                           "/api",
                                           "/Perfils", 
                                           mainViewModel.Token.TokenType,
                                           mainViewModel.Token.AccessToken);

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }



            var perfils = (List<Perfil>)response.Result;
            Perfils = new ObservableCollection<Perfil>(perfils.OrderBy(c => c.Name));

        }
        #endregion
    }
}
