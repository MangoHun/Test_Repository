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
using System.Diagnostics;


namespace SocketTest2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        TCPIPServer server = new TCPIPServer();

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Test Program Start");
        }

        private void serverOnOfftBtn_Click(object sender, RoutedEventArgs e)
        {
            string IP = serverIPAddressTextBox.Text.Split(' ')[3];
            int PORT = int.Parse(serverPortNumberTextBox.Text.Split(' ')[3]);
            Console.WriteLine("Server Information : {0}, {1}", IP, PORT);
            //Trace.WriteLine("trace");

            Task runServerProgram = Task.Run(() => server.ServerStart(IP, PORT));
        }



    }
}
