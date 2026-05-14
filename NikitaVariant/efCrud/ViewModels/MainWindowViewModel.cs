using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using efCrud.Database;
using efCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace efCrud.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly AppDbContext _db = new();

        [ObservableProperty]
        private ObservableCollection<User> users = new();

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private User selectedUser;

        public MainWindowViewModel()
        {
            Load();
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            if (Age <= 0)
            {
                return false;
            }

            return true;
        }

        [RelayCommand]
        public void Load()
        {
            Users = new ObservableCollection<User>(_db.Users.Include(u => u.Profile).ToList());
        }

        [RelayCommand]
        private void Add()
        {
            if (!Validate())
            {
                return;
            }

            User user = new User
            {
                Name = Name,
                Age = Age,
                Profile = new Profile
                {
                    Bio = "Описание пользователя"
                }
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            Name = string.Empty;
            Age = 0;

            Load();
        }

        [RelayCommand]
        private void Update()
        {
            if (SelectedUser == null || !Validate()) return;

            SelectedUser.Name = Name;
            SelectedUser.Age = Age;

            Name = string.Empty;
            Age = 0;

            _db.SaveChanges();
            Load();
        }

        [RelayCommand]
        private void Delete()
        {
            if (SelectedUser == null) return;

            _db.Users.Remove(SelectedUser);
            _db.SaveChanges();
            Load();
        }

        [RelayCommand]
        private void ClearAll()
        {
            _db.Users.RemoveRange(_db.Users);
            _db.SaveChanges();

            Load();
        }
    }
}