using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorSlider {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }//end main
        #region Functions
        private void UpdateRectangle(byte red, byte green, byte blue, byte alpha) { 
            Color brushColor = Color.FromArgb(alpha, red, green, blue);
            SolidColorBrush brush = new SolidColorBrush(brushColor);
            rctColor.Fill = brush;

        }//end function
        private void UpdateLabels() {
            SolidColorBrush tempBrush = (SolidColorBrush)rctColor.Fill;
            
            Color brushColor = tempBrush.Color;

            byte alpha = brushColor.A;
            byte red = brushColor.R;
            byte green = brushColor.G;
            byte blue = brushColor.B;

            string binaryString = $"Alpha: {Convert.ToString(alpha, 2).PadLeft(8,'0')} Red: {Convert.ToString(red, 2).PadLeft(8, '0')} Green: {Convert.ToString(green, 2).PadLeft(8, '0')} Blue: {Convert.ToString(blue, 2).PadLeft(8, '0')}";

            if (lblBinary != null) {
                lblBinary.Content = binaryString;
            }//end if

            byte[] values = { blue, green, red, alpha };
            uint intValue = BitConverter.ToUInt32(values, 0);
            if (lblInt != null) {
                lblInt.Content = intValue;
            }//end if

            string hexString = $"#{Convert.ToString(intValue, 16).PadLeft(8,'0')}";
            if(lblHex != null) {
                lblHex.Content = hexString.ToUpper();
            }//end if
        }//end function
        #endregion

        #region Events
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte red = (byte)sldRed.Value;
            byte green = (byte)sldGreen.Value;
            byte blue = (byte)sldBlue.Value;
            byte alpha = (byte)sldAlpha.Value;

            if(txtRed != null) {
                txtRed.Text = red.ToString();
            }//end if
            if (txtGreen != null) {
                txtGreen.Text = green.ToString();
            }//end if
            if (txtBlue != null) {
                txtBlue.Text = blue.ToString();
            }//end if
            if (txtAlpha != null) {
                txtAlpha.Text = alpha.ToString();
            }//end if

            UpdateRectangle(red, green, blue, alpha);
            UpdateLabels();
        }//end event

        private void txtbox_TextChanged(object sender, TextChangedEventArgs e) {
            byte red;
            byte green;
            byte blue;
            byte alpha;

            if (txtRed != null) {
                byte.TryParse(txtRed.Text, out red);
                sldRed.Value = red; 
            }//end if

            if (txtGreen != null) {
                byte.TryParse(txtGreen.Text, out green);
                sldGreen.Value = green; 
            }//end if

            if (txtBlue != null) {
                byte.TryParse(txtBlue.Text, out blue);
                sldBlue.Value = blue; 
            }//end if

            if (txtAlpha != null) {
                byte.TryParse(txtAlpha.Text, out alpha);
                sldAlpha.Value = alpha; 
            }//end if
        }//end event
        #endregion
    }//end class
}//end namespace
