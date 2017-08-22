﻿using Microsoft.Practices.Unity;
using WPFTest.Infraestructure;
using WPFTest.Servicios.Interfaces;
using WPFTest.View;

namespace WPFTest.ViewModel
{
    public class ViewModelEditUser : IViewModelEditUser
    {
        #region Servicios
        private IUsuarioService _usuarioService;
        #endregion

        #region Metodos Privados
        public RelayCommand SaveChangesCommand { get; set; }

        void SaveChanges(object parameter)
        {
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelMain>();
            var window = new MainWindow() { DataContext = viewModel };
            window.Show();
            ((EditUserWindow)parameter).Close();
        } 
        #endregion

        #region Constructor con IoC
        public ViewModelEditUser()
        {
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        public ViewModelEditUser(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }
        #endregion
    }
}
