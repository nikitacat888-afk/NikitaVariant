using Avalonia.Controls;
using Avalonia.Input;
using efCrud.Models;
using efCrud.ViewModels;

namespace efCrud.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnUserDoubleTapped(object sender, TappedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm && vm.SelectedUser != null)
            {
                var profileWindow = new UserProfileWindow(vm.SelectedUser, () =>
                {
                    // Обновляем список после редактирования профиля
                    vm.LoadCommand.Execute(null);
                });

                await profileWindow.ShowDialog(this);
            }
        }
    }
}