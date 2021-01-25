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
using System.Windows.Threading;
using System.IO.Ports;

namespace InverterMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// SerialPort对象
        /// </summary>
        private SerialPort _serialPort = new SerialPort();
        private DispatcherTimer _checkTimer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            // 其他模块初始化
            //InitClockTimer();
            //InitAutoSendDataTimer();

            //InitSerialPort();
            _serialPort.DataReceived += SerialPort_DataReceived;
            InitCheckTimer();


            // 查找可以使用的端口号
            //FindPorts();
            ConboBox_Port.ItemsSource = SerialPort.GetPortNames();
            if (ConboBox_Port.Items.Count > 0)
            {
                ConboBox_Port.SelectedIndex = 0;
                ConboBox_Port.IsEnabled = true;
                Information(string.Format("查找到可以使用的端口{0}个。", ConboBox_Port.Items.Count.ToString()));
            }
            else
            {
                ConboBox_Port.IsEnabled = false;
                Alert("Oops，没有查找到可用端口；您可以点击“查找”按钮手动查找。");
            }

        }

        /// <summary>
        /// 更新时间信息
        /// </summary>
        private void UpdateTimeDate()
        {
            string timeDateString = "";
            DateTime now = DateTime.Now;
            timeDateString = string.Format("{0}年{1}月{2}日 {3}:{4}:{5}",
                now.Year,
                now.Month.ToString("00"),
                now.Day.ToString("00"),
                now.Hour.ToString("00"),
                now.Minute.ToString("00"),
                now.Second.ToString("00"));

            timeDateTextBlock.Text = timeDateString;
        }

        /// <summary>
        /// 警告信息提示（一直提示）
        /// </summary>
        /// <param name="message">提示信息</param>
        private void Alert(string message)
        {
            // #FF68217A
            statusBar.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x21, 0x2A));
            statusInfoTextBlock.Text = message;
        }

        /// <summary>
        /// 普通状态信息提示
        /// </summary>
        /// <param name="message">提示信息</param>
        private void Information(string message)
        {
            if (_serialPort.IsOpen)
            {
                // #FFCA5100
                statusBar.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCA, 0x51, 0x00));
            }
            else
            {
                // #FF007ACC
                statusBar.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC));
            }
            statusInfoTextBlock.Text = message;
        }

        private bool OpenPort()
        {
            bool flag = false;
            _serialPort.PortName = ConboBox_Port.Text;
            _serialPort.BaudRate = 115200;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.Encoding = Encoding.UTF8;

            try
            {
                _serialPort.Open();
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                Information(string.Format("成功打开端口{0}, 波特率{1}。", _serialPort.PortName, _serialPort.BaudRate.ToString()));
                flag = true;
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }

            return flag;
        }

        private bool ClosePort()
        {
            bool flag = false;

            try
            {
                //StopAutoSendDataTimer();
                //progressBar.Visibility = Visibility.Collapsed;
                _serialPort.Close();
                Information(string.Format("成功关闭端口{0}。", _serialPort.PortName));
                flag = true;
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }

            return flag;
        }

        private const int TIMEOUT = 50;
        private void InitCheckTimer()
        {
            // 如果缓冲区中有数据，并且定时时间达到前依然没有得到处理，将会自动触发处理函数。
            _checkTimer.Interval = new TimeSpan(0, 0, 0, 0, TIMEOUT);
            _checkTimer.IsEnabled = false;
            _checkTimer.Tick += CheckTimer_Tick;
        }

        private void StartCheckTimer()
        {
            _checkTimer.IsEnabled = true;
            _checkTimer.Start();
        }

        private void StopCheckTimer()
        {
            _checkTimer.IsEnabled = false;
            _checkTimer.Stop();
        }

        /// <summary>
        /// 更新：采用一个缓冲区，当有数据到达时，把字节读取出来暂存到缓冲区中，缓冲区到达定值
        /// 时，在显示区显示数据即可。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}
