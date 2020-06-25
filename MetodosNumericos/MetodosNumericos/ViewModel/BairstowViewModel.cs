using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MetodosNumericos.ViewModel
{
    public class BairstowViewModel : BaseViewModel
    {

        public void calcular(List<Double> coefi, double pr, double ps, int g)
        {
            double r, s;
            double tol = 1;
            List<double> coeficientes = new List<double>();
            double b0, b1, c0, c1, c2, dr, ds, er;
            List<Double> valores = new List<double>();
            int grado, iteraciones = 1;
            grado = g;
            coeficientes = coefi;
            r = pr;
            s = ps;
            //agregar los coeficientes
            do
            {

                valores.Clear();
                for (int i = 0; i <= grado; i++)
                {
                    double temp;
                    if (i == 0)
                    {
                        temp = coeficientes[i];
                    }
                    else if (i == 1)
                    {
                        temp = coeficientes[i] + (valores[0] * r);
                    }
                    else
                    {
                        temp = coeficientes[i] + (valores[i - 1] * r) + (valores[i - 2] * s);
                    }
                    valores.Add(temp);
                }
                b0 = valores[valores.Count - 1];
                b1 = valores[valores.Count - 2];
                List<Double> val = new List<double>();
                for (int i = 0; i < grado; i++)
                {
                    double temp;
                    if (i == 0)
                    {
                        temp = valores[i];
                    }
                    else if (i == 1)
                    {
                        temp = valores[i] + (val[0] * r);
                    }
                    else
                    {
                        temp = valores[i] + (val[i - 1] * r) + (val[i - 2] * s);
                    }
                    val.Add(temp);
                }
                c0 = val[val.Count - 1];
                c1 = val[val.Count - 2];
                c2 = val[val.Count - 3];
                Double[,] Vinv = new double[2, 2];
                Vinv[0, 0] = c1;
                Vinv[0, 1] = c2;
                Vinv[1, 0] = c0;
                Vinv[1, 1] = c1;
                //problema al calcular los deltas
                Double[,] Inversa = CalcInversa(Vinv);
                double[] deltas = CalcDeltas(Inversa, b1, b0);
                dr = deltas[0];
                ds = deltas[1];
                er = dr / r;
                er *= 100;
                if (Math.Abs(er)
                    <= tol)
                {
                    App.Current.MainPage.DisplayAlert("Iteracion #" + iteraciones, "Valor en r=" + r + " \nValor en s=" + s+"\nError: "+Math.Abs(er)+"%", "Aceptar");
                    return;
                }
                r = dr + r;
                s = ds + s;
                iteraciones++;
            } while (true);
        }
        private static Double[,] CalcInversa(Double[,] matriz)
        {
            double det = (matriz[0, 0] * matriz[1, 1]) - (matriz[0, 1] * matriz[1, 0]);
            if (det == 0)
            {
                Console.WriteLine("El determinante es 0");
                Console.ReadKey();
                return null;
            }
            Double[,] cofactor = new double[2, 2];
            cofactor[0, 0] = matriz[1, 1];
            cofactor[1, 0] = -1 * matriz[0, 1];
            cofactor[0, 1] = -1 * matriz[1, 0];
            cofactor[1, 1] = matriz[0, 0];
            Double[,] transpuesta = new double[2, 2];
            transpuesta[0, 0] = cofactor[0, 0];
            transpuesta[1, 0] = cofactor[0, 1];
            transpuesta[0, 1] = cofactor[1, 0];
            transpuesta[1, 1] = cofactor[1, 1];
            Double[,] Inversa = new double[2, 2];
            Inversa[0, 0] = transpuesta[0, 0] / det;
            Inversa[0, 1] = transpuesta[0, 1] / det;
            Inversa[1, 0] = transpuesta[1, 0] / det;
            Inversa[1, 1] = transpuesta[1, 1] / det;
            return Inversa;
        }
        private static double[] CalcDeltas(double[,] inversa, double b1, double b0)
        {
            double[] deltas = new double[2];
            deltas[0] = (inversa[0, 0] * b1 * -1) + (inversa[0, 1] * b0 * -1);
            deltas[1] = (inversa[1, 0] * b1 * -1) + (inversa[1, 1] * b0 * -1);
            return deltas;
        }
    }
}
