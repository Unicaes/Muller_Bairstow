using MetodosNumericos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetodosNumericos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Muller : ContentPage
    {
        int grado;
        public Muller()
        {
            InitializeComponent();
            txt0.IsVisible = false;
            txt0.IsVisible = false;
            txt1.IsEnabled = false;
            txt1.IsVisible = false;
            txt2.IsEnabled = false;
            txt2.IsVisible = false;
            txt3.IsEnabled = false;
            txt3.IsVisible = false;
            txt4.IsEnabled = false;
            txt4.IsVisible = false;
            txt5.IsEnabled = false;
            txt5.IsVisible = false;
            txt6.IsEnabled = false;
            txt6.IsVisible = false;
            lbl1.IsVisible = false;
            lbl1.IsEnabled = false;
            lbl2.IsVisible = false;
            lbl2.IsEnabled = false;
            lbl3.IsVisible = false;
            lbl3.IsEnabled = false;
            lbl4.IsVisible = false;
            lbl4.IsEnabled = false;
            lbl5.IsVisible = false;
            lbl5.IsEnabled = false;
            lbl6.IsVisible = false;
            lbl6.IsEnabled = false;
        }

        private void txt6_Unfocused(object sender, FocusEventArgs e)
        {
            Entry selec = (sender as Entry);
            if (selec.Text == "")
            {
                selec.Text = "0";
            }
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sel = picker.SelectedItem.ToString();
            if (sel == "Grado 3")
            {
                txt0.IsVisible = true;
                txt0.IsEnabled = true;
                txt1.IsEnabled = true;
                txt1.IsVisible = true;
                txt2.IsEnabled = true;
                txt2.IsVisible = true;
                txt3.IsEnabled = true;
                txt3.IsVisible = true;
                txt4.IsEnabled = false;
                txt4.IsVisible = false;
                txt5.IsEnabled = false;
                txt5.IsVisible = false;
                txt6.IsEnabled = false;
                txt6.IsVisible = false;
                lbl1.IsVisible = true;
                lbl1.IsEnabled = true;
                lbl2.IsVisible = true;
                lbl2.IsEnabled = true;
                lbl3.IsVisible = true;
                lbl3.IsEnabled = true;
                lbl4.IsVisible = false;
                lbl4.IsEnabled = false;
                lbl5.IsVisible = false;
                lbl5.IsEnabled = false;
                lbl6.IsVisible = false;
                lbl6.IsEnabled = false;
                grado = 3;
            }
            if (sel == "Grado 4")
            {
                txt0.IsVisible = true;
                txt0.IsEnabled = true;
                txt1.IsEnabled = true;
                txt1.IsVisible = true;
                txt2.IsEnabled = true;
                txt2.IsVisible = true;
                txt3.IsEnabled = true;
                txt3.IsVisible = true;
                txt4.IsEnabled = true;
                txt4.IsVisible = true;
                txt5.IsEnabled = false;
                txt5.IsVisible = false;
                txt6.IsEnabled = false;
                txt6.IsVisible = false;
                lbl1.IsVisible = true;
                lbl1.IsEnabled = true;
                lbl2.IsVisible = true;
                lbl2.IsEnabled = true;
                lbl3.IsVisible = true;
                lbl3.IsEnabled = true;
                lbl4.IsVisible = true;
                lbl4.IsEnabled = true;
                lbl5.IsVisible = false;
                lbl5.IsEnabled = false;
                lbl6.IsVisible = false;
                lbl6.IsEnabled = false;
                grado = 4;
            }
            if (sel == "Grado 5")
            {
                txt0.IsVisible = true;
                txt0.IsEnabled = true;
                txt1.IsEnabled = true;
                txt1.IsVisible = true;
                txt2.IsEnabled = true;
                txt2.IsVisible = true;
                txt3.IsEnabled = true;
                txt3.IsVisible = true;
                txt4.IsEnabled = true;
                txt4.IsVisible = true;
                txt5.IsEnabled = true;
                txt5.IsVisible = true;
                txt6.IsEnabled = false;
                txt6.IsVisible = false;
                lbl1.IsVisible = true;
                lbl1.IsEnabled = true;
                lbl2.IsVisible = true;
                lbl2.IsEnabled = true;
                lbl3.IsVisible = true;
                lbl3.IsEnabled = true;
                lbl4.IsVisible = true;
                lbl4.IsEnabled = true;
                lbl5.IsVisible = true;
                lbl5.IsEnabled = true;
                lbl6.IsVisible = false;
                lbl6.IsEnabled = false;
                grado = 5;
            }
            if (sel == "Grado 6")
            {
                txt0.IsVisible = true;
                txt0.IsEnabled = true;
                txt1.IsEnabled = true;
                txt1.IsVisible = true;
                txt2.IsEnabled = true;
                txt2.IsVisible = true;
                txt3.IsEnabled = true;
                txt3.IsVisible = true;
                txt4.IsEnabled = true;
                txt4.IsVisible = true;
                txt5.IsEnabled = true;
                txt5.IsVisible = true;
                txt6.IsEnabled = true;
                txt6.IsVisible = true;
                lbl1.IsVisible = true;
                lbl1.IsEnabled = true;
                lbl2.IsVisible = true;
                lbl2.IsEnabled = true;
                lbl3.IsVisible = true;
                lbl3.IsEnabled = true;
                lbl4.IsVisible = true;
                lbl4.IsEnabled = true;
                lbl5.IsVisible = true;
                lbl5.IsEnabled = true;
                lbl6.IsVisible = true;
                lbl6.IsEnabled = true;
                grado = 6;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.x1.Text))
            {
                await DisplayAlert("Error", "x1 no puede quedar vacio", "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(this.x2.Text))
            {
                await DisplayAlert("Error", "x2 no puede quedar vacio", "Aceptar");
                return;
            }
            List<Double> coefi = new List<double>();
            if (grado == 3)
            {
                coefi.Add(Convert.ToDouble(txt3.Text));
                coefi.Add(Convert.ToDouble(txt2.Text));
                coefi.Add(Convert.ToDouble(txt1.Text));
                coefi.Add(Convert.ToDouble(txt0.Text));
            }
            if (grado == 4)
            {
                coefi.Add(Convert.ToDouble(txt4.Text));
                coefi.Add(Convert.ToDouble(txt3.Text));
                coefi.Add(Convert.ToDouble(txt2.Text));
                coefi.Add(Convert.ToDouble(txt1.Text));
                coefi.Add(Convert.ToDouble(txt0.Text));
            }
            if (grado == 5)
            {
                coefi.Add(Convert.ToDouble(txt5.Text));
                coefi.Add(Convert.ToDouble(txt4.Text));
                coefi.Add(Convert.ToDouble(txt3.Text));
                coefi.Add(Convert.ToDouble(txt2.Text));
                coefi.Add(Convert.ToDouble(txt1.Text));
                coefi.Add(Convert.ToDouble(txt0.Text));
            }
            if (grado == 6)
            {
                coefi.Add(Convert.ToDouble(txt6.Text));
                coefi.Add(Convert.ToDouble(txt5.Text));
                coefi.Add(Convert.ToDouble(txt4.Text));
                coefi.Add(Convert.ToDouble(txt3.Text));
                coefi.Add(Convert.ToDouble(txt2.Text));
                coefi.Add(Convert.ToDouble(txt1.Text));
                coefi.Add(Convert.ToDouble(txt0.Text));
            }
            MullerViewModel context = new MullerViewModel();
            double r, s;
            r = Convert.ToDouble(this.x1.Text);
            s = Convert.ToDouble(this.x2.Text);
            context.calcular(coefi, r, s);
        }
    }
}