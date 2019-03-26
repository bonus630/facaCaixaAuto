using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Bonus630.vsta.FacaCaixaAuto
{
    /// <summary>
    /// Interaction logic for UserControl1.Xaml
    /// </summary>
    public partial class FacaCaixaAutoUI : UserControl
    {

        FacaManager manager;
        Dictionary<string, bool> listaComboBox;
        Regex exp;
        IFaca objFaca;
        CorelStyles.StyleController styleController;
        public FacaCaixaAutoUI(Corel.Interop.VGCore.Application app)
        {
            InitializeComponent();
            if (FacaBase.app == null)
                FacaBase.app = app;
            
            styleController = new CorelStyles.StyleController(this.Resources, app);
            manager = new FacaManager();
            listaComboBox = manager.ListaClass();
            comboBox1.ItemsSource = listaComboBox.Keys;
            exp = new Regex("^(?<num>[0-9]{0,}[,.]?[0-9]{0,})", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            comboBox1.SelectedIndex = -1;
            #if DEBUG
                comboBox1.SelectedIndex = 1;
                textBox_Altura.Text = "100";
                textBox_Largura.Text = "60";
                textBox_Comprimento.Text = "90";
            #endif

            comboBox1_SelectionChanged(null, null);
            img_bonus.Source = FacaCaixaAuto.Properties.Resources.bonus630.ConvertToBitmapSource();

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            styleController.LoadThemeFromPreference();
        }
        private void btn_ir_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_Altura.Text) && !String.IsNullOrEmpty(textBox_Largura.Text) && !String.IsNullOrEmpty(textBox_Comprimento.Text))
                objFaca.Draw();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                textBox_Altura.IsEnabled = false;
                textBox_Comprimento.IsEnabled = false;
                textBox_Largura.IsEnabled = false;
                btn_ir.IsEnabled = false;
            }
            else
            {
                textBox_Altura.IsEnabled = true;
                textBox_Comprimento.IsEnabled = true;
                if(!listaComboBox[comboBox1.SelectedItem.ToString()])
                    textBox_Largura.IsEnabled = true;
                else
                    textBox_Largura.IsEnabled = false;
                btn_ir.IsEnabled = true;
               objFaca = manager.inicialize(comboBox1.SelectedItem.ToString());
               setValues();
               calcVolume();
            }

        }

        private string checkField(string text)
        {
            Match m = exp.Match(text);
            return m.Result("$1");
        }

        private void textBox_Largura_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_Largura.Text = checkField(textBox_Largura.Text);
            textBox_Largura.CaretIndex = textBox_Largura.Text.Length;
            setValues();
            calcVolume();
        }

        private void textBox_Comprimento_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_Comprimento.Text = checkField(textBox_Comprimento.Text);
            textBox_Comprimento.CaretIndex = textBox_Comprimento.Text.Length;
            setValues();
            calcVolume();
        }

        private void textBox_Altura_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_Altura.Text = checkField(textBox_Altura.Text);
            textBox_Altura.CaretIndex = textBox_Altura.Text.Length;
            setValues();
            calcVolume();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bonus630.tk");
        }

        private void calcVolume()
        {
            if(objFaca!=null)
                lba_vol.Content = string.Format("{0} mm", objFaca.CalcVolume());
        }
        private void setValues()
        {
            if(objFaca!=null)
                objFaca.SetValues(textBox_Altura.Text, textBox_Largura.Text, textBox_Comprimento.Text);
        }

      

    }
}
