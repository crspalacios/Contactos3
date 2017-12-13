namespace Contactos3.ViewModels
{
    using Contactos3.Services;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using System;
    using Contactos3.Models;
    using Xamarin.Forms;
    using Plugin.Media.Abstractions;
    using Plugin.Media;

    public class NewContactViewModel : INotifyPropertyChanged
    {
        #region Attributes

        bool _isRunning;
        bool _isEnabled;

        ImageSource _imageSource;
        MediaFile file;


        #endregion

        #region Services
        DialogService dialogService;
        ApiService apiService;
        NavigationService navigationService;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public NewContactViewModel()
        {


            dialogService = new DialogService();
            apiService = new ApiService();
            navigationService = new NavigationService();

            IsEnabled = true;


        }

        #region Properties
        public ImageSource ImageSource
        {
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ImageSource)));
                }
            }
            get
            {
                return _imageSource;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
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

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        async  void Save()
        {


            if (string.IsNullOrEmpty(Name))
            {
                await dialogService.ShowMessage("Error", "Escribe tu nombre para continuar...");
                return;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                await dialogService.ShowMessage("Error", "Falto tu apellido. Todos tenemos uno.");
                return;
            }


            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var perfil = new Perfil
            {
                Name = Name,
                LastName = LastName,
            };

            var mainViewModel = MainViewModel.GetInstance();
            var response = await apiService.Post("http://contactos3api.azurewebsites.net",
                                           "/api",
                                           "/Perfils",
                                           mainViewModel.Token.TokenType,
                                           mainViewModel.Token.AccessToken,
                                           perfil);
            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            await dialogService.ShowMessage("En hhorabuena", "ya tenemos tus numbres");
            IsRunning = false;
            IsEnabled = true;
        }

        public ICommand ChangeImageCommand
        {
            get
            {
                return new RelayCommand(ChangeImage);
            }
        }

        async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable &&
                CrossMedia.Current.IsTakePhotoSupported)
            {
                var source = await dialogService.ShowImageOptions();

                if (source == "Cancel")
                {
                    file = null;
                    return;
                }

                if (source == "From Camera")
                {
                    file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
                }
                else
                {
                    file = await CrossMedia.Current.PickPhotoAsync();
                }
            }
            else
            {
                file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (file != null)
            {
                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        #endregion
    }
}
