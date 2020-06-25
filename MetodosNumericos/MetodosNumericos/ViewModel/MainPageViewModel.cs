using GalaSoft.MvvmLight.Command;
using MetodosNumericos.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MetodosNumericos.ViewModel
{
    class MainPageViewModel
    {
        public ICommand Muller
        {
            get
            {
                return new RelayCommand(muller);
            }
        }
        public ICommand Bairstow
        {
            get
            {
                return new RelayCommand(bairstow);
            }
        }
        public ICommand Matriz
        {
            get
            {
                return new RelayCommand(matriz);
            }
        }

        private void matriz()
        {
            App.Current.MainPage.Navigation.PushAsync(new Matriz());
        }

        private void bairstow()
        {
            App.Current.MainPage.Navigation.PushAsync(new Bairstow());
        }

        private void muller()
        {
            App.Current.MainPage.Navigation.PushAsync(new Muller());
        }
    }
}
