using Contactos3.Services;
using Contactos3.View;
using Contactos3.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Contactos3.Models
{

    public class Perfil
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Constructors
        public Perfil()
        {
            navigationService = new NavigationService();
        }
        #endregion

        #region Properties
        public int PerfilId { get; set; }
        public string ImagePerfil { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImagePerfilFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePerfil))
                {
                    return "contacto_sin_imagen";
                }
                return string.Format("http://contactos3api.azurewebsites.net/{0}", ImagePerfil.Substring(1));
            }
        }
        public List<Address> Addresses { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Social> Socials { get; set; }
        public List<Url> Urls { get; set; }
        public List<Email> Emails { get; set; }
        public List<Brouchure> Brouchures { get; set; } 
        #endregion

        #region Commands
        public ICommand SelectPerfilCommand
        {
            get
            {
                return new RelayCommand(SelectPerfil);
            }
        }

        async void SelectPerfil()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.InfoContacts = new InfoContactsViewModel(Addresses, Jobs, Phones, Socials, Urls, Emails, Brouchures);
            await navigationService.Navigate("InfoContactsView");

        }
        #endregion


    }
}
