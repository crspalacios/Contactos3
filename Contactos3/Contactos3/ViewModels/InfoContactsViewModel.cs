namespace Contactos3.ViewModels
{
    using System.Collections.Generic;
    using Contactos3.Models;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class InfoContactsViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private List<Address> addresses;
        ObservableCollection<Address> _addresses;
        private List<Job> jobs;
        ObservableCollection<Job> _jobs;
        private List<Phone> phones;
        ObservableCollection<Phone> _phones;
        private List<Social> socials;
        ObservableCollection<Social> _socials;
        private List<Url> urls;
        ObservableCollection<Url> _urls;
        private List<Email> emails;
        ObservableCollection<Email> _emails;
        private List<Brouchure> brouchures;
        ObservableCollection<Brouchure> _brouchures;

        #endregion

        #region Constructor
        public InfoContactsViewModel(List<Address> addresses,
                             List<Job> jobs,
                             List<Phone> phones,
                             List<Social> socials,
                             List<Url> urls,
                             List<Email> emails,
                             List<Brouchure> brouchures)
        {
            this.addresses = addresses;
            Addresses = new ObservableCollection<Address>(addresses.OrderBy(a => a.NameAddress));
            this.jobs = jobs;
            Jobs = new ObservableCollection<Job>(jobs.OrderBy(j => j.JobPosition));
            this.phones = phones;
            Phones = new ObservableCollection<Phone>(phones.OrderBy(p => p.PhoneNumber));
            this.socials = socials;
            Socials = new ObservableCollection<Social>(socials.OrderBy(s => s.SocialPerfil));
            this.urls = urls;
            Urls = new ObservableCollection<Url>(urls.OrderBy(u => u.NameUrl));
            this.emails = emails;
            Emails = new ObservableCollection<Email>(emails.OrderBy(e => e.NameEmail));
            this.brouchures = brouchures;
            Brouchures = new ObservableCollection<Brouchure>(brouchures.OrderBy(b => b.BrochureDescription));
        }
        #endregion

        #region Properties
        public ObservableCollection<Address> Addresses
        {
            get
            {
                return _addresses;
            }
            set
            {
                if (_addresses != value)
                {
                    _addresses = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }

        public ObservableCollection<Job> Jobs
        {
            get
            {
                return _jobs;
            }
            set
            {
                if (_jobs != value)
                {
                    _jobs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Jobs)));
                }
            }
        }

        public ObservableCollection<Phone> Phones
        {
            get
            {
                return _phones;
            }
            set
            {
                if (_phones != value)
                {
                    _phones = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Phones)));
                }
            }
        }

        public ObservableCollection<Social> Socials
        {
            get
            {
                return _socials;
            }
            set
            {
                if (_socials != value)
                {
                    _socials = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }

        public ObservableCollection<Url> Urls
        {
            get
            {
                return _urls;
            }
            set
            {
                if (_urls != value)
                {
                    _urls = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }

        public ObservableCollection<Email> Emails
        {
            get
            {
                return _emails;
            }
            set
            {
                if (_emails != value)
                {
                    _emails = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }

        public ObservableCollection<Brouchure> Brouchures
        {
            get
            {
                return _brouchures;
            }
            set
            {
                if (_brouchures != value)
                {
                    _brouchures = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
                }
            }
        }
        #endregion
    }
}
