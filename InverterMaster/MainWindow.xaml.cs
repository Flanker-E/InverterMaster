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
using LiveCharts;
using LiveCharts.Configurations;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace InverterMaster
{

    //public class ActualValueList : ObservableCollection<Signal>
    //{
    //    public ActualValueList() : base()
    //    {
    //        Add(new Signal("Enabled", -1.0));

    //    }
    //}

    public class Signal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string signalName;
        private double signalValue;

        public Signal(string name, double value)
        {
            this.signalName = name;
            this.signalValue = value;
        }

        public string Signalname
        {
            get { return signalName; }
            set { signalName = value; }
        }

        public double SignalValue
        {
            get { return signalValue; }
            set 
            { 
                signalValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SignalValue"));
                }
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Signal> ActualValues = new ObservableCollection<Signal>();
        public ObservableCollection<Signal> SetPoints = new ObservableCollection<Signal>();

        /// <summary>
        /// SerialPort对象
        /// </summary>
        private SerialPort _serialPort = new SerialPort();
        private DispatcherTimer _checkTimer = new DispatcherTimer();
        private DispatcherTimer _testTimer = new DispatcherTimer();
        private ResourceDictionary _compactResources = new ResourceDictionary { Source = new Uri("/ModernWpf;component/DensityStyles/Compact.xaml", UriKind.Relative) };


        public MainWindow()
        {
            
            InitializeComponent();
            
            // 其他模块初始化
            #region DataGrid


            //SetPoints.Add(new Signal("Enable", -1.0));
            //SetPoints.Add(new Signal("ErrorReset", -1.0));
            //SetPoints.Add(new Signal("TargetTorque", 0.0));
            //SetPoints.Add(new Signal("TorqueLimitP", 0.0));
            //SetPoints.Add(new Signal("TorqueLimitN", 0.0));
            //SetPointsGrid.ItemsSource = SetPoints;

            ActualValues.Add(new Signal("Enabled", -1.0));
            ActualValues.Add(new Signal("DCVoltage", -1.0));
            ActualValues.Add(new Signal("ActualTorque", -1.0));
            ActualValues.Add(new Signal("ActualVelocity", -1.0));
            ActualValues.Add(new Signal("Error", -1.0));
            ActualValues.Add(new Signal("Diagnostic", -1.0));
            ActualValues.Add(new Signal("TempMotor", -1.0));
            ActualValues.Add(new Signal("TempInverter", -1.0));
            ActualValues.Add(new Signal("TempIGBT", -1.0));
            ActualValuesGrid.ItemsSource = ActualValues;
            ActualValuesGrid.Resources.MergedDictionaries.Add(_compactResources);//Sizing=Compact


            #endregion

            #region Serial_Port
            //InitClockTimer();
            //InitAutoSendDataTimer();
            //Plots.IsEnabled = true;
            //Variables.IsEnabled = true;
            //Tuning.IsEnabled = true;
            //InitSerialPort();
            _serialPort.DataReceived += SerialPort_DataReceived;/* 注册 */
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
            #endregion

            #region Plot
            var mapper = Mappers.Xy<MeasureModel>()
               .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
               .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the values property will store our values array
            ChartValues = new ChartValues<MeasureModel>();
            TempValues = new ChartValues<MeasureModel>();
            //ActualValues = new ObservableCollection<Signal>();


            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            //The next code simulates data changes every 300 ms

            IsPlotting = false;

            DataContext = this;
            //nowtime.DateTime = DateTime.Now;
            #endregion

        }
        

        #region window_status
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
        #endregion

        #region Port
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
            _checkTimer.Tick += CheckTimer_Tick;/* 注册 */

            _testTimer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            _testTimer.IsEnabled = false;
            _testTimer.Tick += TestTimer_Tick;/* 注册 */
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

        private void StartTestTimer()
        {
            _testTimer.IsEnabled = true;
            _testTimer.Start();
        }

        private void StopTestTimer()
        {
            _testTimer.IsEnabled = false;
            _testTimer.Stop();
        }

        /// <summary>
        /// 更新：采用一个缓冲区，当有数据到达时，把字节读取出来暂存到缓冲区中，缓冲区到达定值
        /// 时，在显示区显示数据即可。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion

    }
}
