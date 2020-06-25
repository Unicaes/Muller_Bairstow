using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MetodosNumericos.ViewModel
{
    class MatrizViewModel : BaseViewModel
    {

        private double _i1;
        private double _i2;
        private double _i3;
        private double _i4;
        private double _i5;
        private double _i6;
        private double _i7;
        private double _i8;
        private double _i9;
        public double n1 { get; set; }
        public double n2 { get; set; }
        public double n3 { get; set; }
        public double n4 { get; set; }
        public double n5 { get; set; }
        public double n6 { get; set; }
        public double n7 { get; set; }
        public double n8 { get; set; }
        public double n9 { get; set; }
        public double i1 { get { return _i1; } set { _i1 = value;OnPropertyChanged(); } }
        public double i2 { get { return _i2; } set { _i2 = value; OnPropertyChanged(); } }
        public double i3 { get { return _i3; } set { _i3 = value; OnPropertyChanged(); } }
        public double i4 { get { return _i4; } set { _i4 = value; OnPropertyChanged(); } }
        public double i5 { get { return _i5; } set { _i5 = value; OnPropertyChanged(); } }
        public double i6 { get { return _i6; } set { _i6 = value; OnPropertyChanged(); } }
        public double i7 { get { return _i7; } set { _i7 = value; OnPropertyChanged(); } }
        public double i8 { get { return _i8; } set { _i8 = value; OnPropertyChanged(); } }
        public double i9 { get { return _i9; } set { _i9 = value; OnPropertyChanged(); } }
        public ICommand Calcular
        {
            get
            {
                return new RelayCommand(calcular);
            }
        }

        private void calcular()
        {
            double[,] matriz = { { n1, n2, n3 }, { n4, n5, n6 }, { n7, n8, n9 } };
            double[,] cof = new double[3, 3];
            double[,] tras = new double[3, 3];
            //Matriz inversa
            double[,] inversa = new double[3, 3];
            double det = ((matriz[0, 0] * matriz[1, 1] * matriz[2, 2]) + (matriz[0, 1] * matriz[1, 2] * matriz[2, 0]) + (matriz[1, 0] * matriz[2, 1] * matriz[0, 2])
                - ((matriz[0, 2] * matriz[1, 1] * matriz[2, 0]) + (matriz[0, 1] * matriz[1, 0] * matriz[2, 2]) + (matriz[0, 0] * matriz[1, 2] * matriz[2, 1])));
            if (det == 0)
            {
                return;
            }
            double[] indices = new double[4];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    #region indicesJ
                    if (i == 0 && j == 0)
                    {
                        indices[0] = matriz[1, 1];
                        indices[1] = matriz[1, 2];
                        indices[2] = matriz[2, 1];
                        indices[3] = matriz[2, 2];
                    }
                    if (i == 0 && j == 1)
                    {
                        indices[0] = matriz[1, 0];
                        indices[1] = matriz[1, 2];
                        indices[2] = matriz[2, 0];
                        indices[3] = matriz[2, 2];
                    }
                    if (i == 0 && j == 2)
                    {
                        indices[0] = matriz[1, 0];
                        indices[1] = matriz[1, 1];
                        indices[2] = matriz[2, 0];
                        indices[3] = matriz[2, 1];
                    }
                    if (i == 1 && j == 0)
                    {
                        indices[0] = matriz[0, 1];
                        indices[1] = matriz[0, 2];
                        indices[2] = matriz[2, 1];
                        indices[3] = matriz[2, 2];
                    }
                    if (i == 1 && j == 1)
                    {
                        indices[0] = matriz[0, 0];
                        indices[1] = matriz[0, 2];
                        indices[2] = matriz[2, 0];
                        indices[3] = matriz[2, 2];
                    }
                    if (i == 1 && j == 2)
                    {
                        indices[0] = matriz[0, 0];
                        indices[1] = matriz[0, 1];
                        indices[2] = matriz[2, 0];
                        indices[3] = matriz[2, 1];
                    }
                    if (i == 2 && j == 0)
                    {
                        indices[0] = matriz[0, 1];
                        indices[1] = matriz[0, 2];
                        indices[2] = matriz[1, 1];
                        indices[3] = matriz[1, 2];
                    }
                    if (i == 2 && j == 1)
                    {
                        indices[0] = matriz[0, 0];
                        indices[1] = matriz[0, 2];
                        indices[2] = matriz[1, 0];
                        indices[3] = matriz[1, 2];
                    }
                    if (i == 2 && j == 2)
                    {
                        indices[0] = matriz[0, 0];
                        indices[1] = matriz[0, 1];
                        indices[2] = matriz[1, 0];
                        indices[3] = matriz[1, 1];
                    }
                    #endregion
                    cof[i, j] = (indices[0] * indices[3]) - (indices[1] * indices[2]);
                    if ((i + j) % 2 != 0)
                    {
                        cof[i, j] *= -1;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tras[i, j] = cof[j, i];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    inversa[i, j] = tras[i, j] / det;
                }
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                i1 = inversa[0, 0];
                i2 = inversa[0, 1];
                i3 = inversa[0, 2];
                i4 = inversa[1, 0];
                i5 = inversa[1, 1];
                i6 = inversa[1, 2];
                i7 = inversa[2, 0];
                i8 = inversa[2, 1];
                i9 = inversa[2, 2];
            });
        }
    }
}
