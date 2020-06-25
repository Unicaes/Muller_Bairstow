using System;
using System.Collections.Generic;
using System.Text;

namespace MetodosNumericos.ViewModel
{
    class MullerViewModel
    {
        List<Double> origin = new List<double>();
        public double DoFunction(double x)
        {
            double resultado=0;
            int exp;
            for (int i = 0; i < origin.Count; i++)
            {
                exp = origin.Count-1 - i;
                if (exp!=0)
                {
                    resultado += origin[i] * Math.Pow(x, exp);
                }
                else
                {
                    resultado += origin[origin.Count - 1];
                }
                
            }
            return resultado;
        }
        public void calcular(List<Double> coefi,double x1,double x2)
        {
            this.origin = coefi;
            List<Double> numbers = new List<double>();
            List<Double> origin = new List<double>();
            double error = 10;
            origin.Add(x1);
            origin.Add(x2);
            origin.Add((x1+x2)/2);
            origin.Add(0);
            int i = 0;
            do
            {


                numbers.Add(DoFunction(origin[0]));
                numbers.Add(DoFunction(origin[1]));
                numbers.Add(DoFunction(origin[2]));
                double h0 = origin[1] - origin[0];
                double h1 = origin[2] - origin[1];
                double delta0 = (numbers[1 + (i * 3)] - numbers[0 + (i * 3)]) / h0;
                double delta1 = (numbers[2 + (i * 3)] - numbers[1 + (i * 3)]) / h1;
                double a = (delta1 - delta0) / (h1 - h0);
                double b = (a * h1) + delta1;
                double c = numbers[2 + (i * 3)];
                if (b < 0)
                {
                    origin[3] = (origin[2] - ((2 * c) / (b - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)))));
                }
                else
                {
                    origin[3] = (origin[2] - ((2 * c) / (b + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)))));

                }
                if (i > 0)
                {
                    error = (origin[3] - origin[2]) / origin[3];
                    error *= 100;
                }
                origin[0] = origin[1];
                origin[1] = origin[2];
                origin[2] = origin[3];
                i++;
            } while (Math.Abs(error) >= 0.00001);
            App.Current.MainPage.DisplayAlert("Exito", "El error es:" + error + "\nCon un valor de:" + origin[3], "Aceptar");

        }
    }
}
