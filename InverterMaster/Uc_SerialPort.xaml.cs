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
using System.IO.Ports;
using System.Threading;

namespace InverterMaster
{

    /// <summary>
    /// Interaction logic for Uc_SerialPort.xaml
    /// </summary>
    public partial class Uc_SerialPort : UserControl
    {
        public bool SerialPort_Alert = false;
        public bool SerialPort_Run = false;
        SerialPort serialPort = new SerialPort();
        public Uc_SerialPort()
        {
            InitializeComponent();
        }

        private void FindPorts()
        {
            ConboBox_Port.ItemsSource = SerialPort.GetPortNames();
            if (ConboBox_Port.Items.Count > 0)
            {
                ConboBox_Port.SelectedIndex = 0;
                ConboBox_Port.IsEnabled = true;
                SerialPort_Run = true;
                //Information(string.Format("查找到可以使用的端口{0}个。", ConboBox_Port.Items.Count.ToString()));
            }
            else
            {
                ConboBox_Port.IsEnabled = false;
                SerialPort_Run = false;
                SerialPort_Alert = true;
                //Alert("Oops，没有查找到可用端口；您可以点击“查找”按钮手动查找。");
            }
        }
        /// <summary>
        /// 警告信息提示（一直提示）
        /// </summary>
        /// <param name="message">提示信息</param>
        //private void Alert(string message)
        //{
        //    // #FF68217A
        //    MainWindow.statusBar.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x21, 0x2A));
        //    //statusInfoTextBlock.Text = message;
        //}

        /// <summary>
        /// 普通状态信息提示
        /// </summary>
        /// <param name="message">提示信息</param>
        //private void Information(string message)
        //{
        //    if (serialPort.IsOpen)
        //    {
        //        // #FFCA5100
        //        statusBar.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCA, 0x51, 0x00));
        //    }
        //    else
        //    {
        //        // #FF007ACC
        //        statusBar.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC));
        //    }
        //    statusInfoTextBlock.Text = message;
        //}
    }
}
