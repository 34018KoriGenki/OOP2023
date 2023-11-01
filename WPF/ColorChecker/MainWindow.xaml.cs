using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor nowColor = new MyColor();
        
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            SolidColorBrush solidColor = (SolidColorBrush)colorArea.Background;
            
            nowColor.Color = solidColor.Color;
            rSlider.Value = nowColor.Color.R;
            gSlider.Value = nowColor.Color.G;
            bSlider.Value = nowColor.Color.B;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            rSlider.Value = (byte)rSlider.Value;
            gSlider.Value = (byte)gSlider.Value;
            bSlider.Value = (byte)bSlider.Value;
            ColorChange();
        }

        private void ColorChange() {
            byte R = (byte)rSlider.Value;
            byte G = (byte)gSlider.Value;
            byte B = (byte)bSlider.Value;
            colorArea.Background = new SolidColorBrush(Color.FromRgb(R, G, B));
        }

        private void Stock_Click(object sender, RoutedEventArgs e) {
            MyColor myc = new MyColor() {
                Color = new Color {
                    A = 0xFF,
                    R = (byte)rSlider.Value,
                    G = (byte)gSlider.Value,
                    B = (byte)bSlider.Value,
                },
            };
            nowColor = myc;

            nowColor = ((MyColor[])DataContext).FirstOrDefault(mc => mc.Color == nowColor.Color) ?? nowColor;
            var temp = 0;
            foreach (MyColor item in StockColor.Items) {
                if (item.Color == nowColor.Color) {
                    temp++;
                }
            }
            if (temp == 0) {
                StockColor.Items.Add(nowColor);
            }

        }

        private void StockColor_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            SynchronousSlider((MyColor)StockColor.SelectedItem);
            ColorChange();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            SynchronousSlider((MyColor)((ComboBox)sender).SelectedItem);
            ColorChange();
        }

        private void SynchronousSlider(MyColor c) {
            nowColor = c;

            ColorValueSet(c);
        }

        private void ColorValueSet(MyColor c) {
            rSlider.Value = c.Color.R;
            gSlider.Value = c.Color.G;
            bSlider.Value = c.Color.B;
        }
    }

    /// <summary>
    /// 色と色名を保持するクラス
    /// </summary>
    class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return Name ?? $"R:{Color.R} G:{Color.G} B:{Color.B}";
        }
    }
}
