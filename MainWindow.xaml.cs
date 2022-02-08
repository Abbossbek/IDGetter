using DeviceId;
using DeviceId.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace IDGetter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbID.Text = GetIdHash();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(tbID.Text);
        }
        string GetIdHash()
        {
            return Hash(new DeviceIdBuilder().AddProcessorId().AddMotherboardSerialNumber().AddComponent(new DeviceIdComponent("Telegram", "Telegram")).ToString());
        }
        static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
