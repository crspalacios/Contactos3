using Contactos3.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contactos3.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "PerfilsView":
                    await Application.Current.MainPage.Navigation.PushAsync(new PerfilsView());
                    break; 

                case "InfoContactsView":
                    await Application.Current.MainPage.Navigation.PushAsync(new InfoContactsView());
                    break;

                case "NewContactView":
                   await Application.Current.MainPage.Navigation.PushAsync(new NewContactView());
                    break;
            }
        }
        
    }
}
