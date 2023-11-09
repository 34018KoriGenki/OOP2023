using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double metricValue,imperialvalue,gramValue,poundValue;

        public MainWindowViewModel() {
            this.CurrentMetricUnit = MetricUnit.Units.First();
            this.CurrentImperialUnit = ImperialUnit.Units.First();
            this.CurrentGramUnit = GramUnit.Units.First();
            this.CurrentPoundUnit = PoundUnit.Units.First();
            this.MetricToImperialUnit = new DelegateCommand(
                () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
                this.CurrentMetricUnit, this.MetricValue));
            this.ImperialUnitToMetric = new DelegateCommand(
                () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(
                    this.CurrentImperialUnit, this.ImperialValue));
            this.GramToPoundUnit = new DelegateCommand(
                () => this.PoundValue = this.CurrentPoundUnit.FromGramUnit(
                this.CurrentGramUnit, this.GramValue));
            this.PoundUnitToGram = new DelegateCommand(
                () => this.GramValue = this.CurrentGramUnit.FromPoundUnit(
                    this.CurrentPoundUnit, this.PoundValue));
        }

        //▲ボタンで呼ばれるコマンド
        public ICommand ImperialUnitToMetric { get; private set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand MetricToImperialUnit { get; private set; }

        //▲ボタンで呼ばれるコマンド
        public ICommand PoundUnitToGram { get; private set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand GramToPoundUnit { get; private set; }

        //上のComboBoxで選択されている値
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のComboBoxで選択されている値
        public ImperialUnit CurrentImperialUnit { get; set; }

        //上のComboBoxで選択されている値
        public GramUnit CurrentGramUnit { get; set; }
        //下のComboBoxで選択されている値
        public PoundUnit CurrentPoundUnit { get; set; }

        public double MetricValue {
            get => this.metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }
        public double ImperialValue {
            get => this.imperialvalue;
            set {
                this.imperialvalue = value;
                this.OnPropertyChanged();
            }
        }

        public double GramValue {
            get => this.gramValue;
            set {
                this.gramValue = value;
                this.OnPropertyChanged();
            }
        }
        public double PoundValue {
            get => this.poundValue;
            set {
                this.poundValue = value;
                this.OnPropertyChanged();
            }
        }
    }
}
