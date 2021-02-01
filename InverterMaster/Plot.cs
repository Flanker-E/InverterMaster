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
using LiveCharts;
using LiveCharts.Configurations;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace InverterMaster
{
    public class MeasureModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private double _axisMax;
        private double _axisMin;
        private double _trend;

        public ChartValues<MeasureModel> ChartValues { get; set; }
        public ChartValues<MeasureModel> TempValues { get; set; }

        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }
        private DateTime lasttime;
        private MeasureModel nowtime= new MeasureModel
        {
            DateTime = DateTime.Now,
            Value = (double)0
        };

        public double AxisMax//属于另一个线程，所以修改需要触发invoke
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public bool IsPlotting { get; set; }
        public bool IsReading { get; set; }

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            var r = new Random();
            _trend += r.Next(-8, 8);
            var now = DateTime.Now;
            nowtime = new MeasureModel
            {
                DateTime = now,
                Value = _trend
            };
            TempValues.Add(nowtime);
            if (IsReading != true)
            {
                Thread dataHandler = new Thread(()=>Read(TempValues,lasttime));
                dataHandler.Start();
            }
            //else
            //{
                
            //}
        }

        private void Read(ChartValues<MeasureModel> temp, DateTime lasttime)
        {
            IsReading = true;
            //var now = DateTime.Now;
            if (lasttime == null)
                lasttime = DateTime.Now;

            this.Dispatcher.Invoke(new Action(() =>
            {

                ChartValues.AddRange(temp);
                //testtext.Content = string.Format("Interval {0}", (temp.Last().DateTime - lasttime).ToString());
                //testtext.Content = string.Format("test {0}", ().ToString());

                //lets only use the last 150 values
                if (ChartValues.Count > 450) ChartValues.RemoveAt(0);
                //ActualValues.Add(new Signal("Actual", -1.0));
                ActualValues[0].SignalValue = temp.Last().Value;
                //ActualValues[0] = ;

                //dataRecvStatusBarItem.Visibility = Visibility.Collapsed;
                TempValues = new ChartValues<MeasureModel>();
            }));
            lasttime = DateTime.Now;
            SetAxisLimits(DateTime.Now);
            IsReading = false;
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(8).Ticks; // and 8 seconds behind
        }

        private void InjectStopOnClick(object sender, RoutedEventArgs e)
        {
            IsPlotting = !IsPlotting;
            if (IsPlotting) //Task.Factory.StartNew(Read);
                StartTestTimer();
            else
                StopTestTimer();
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}