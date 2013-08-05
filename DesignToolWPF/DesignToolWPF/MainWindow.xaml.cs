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
using System.Collections.ObjectModel;  

namespace DesignToolWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*
    public enum vTypes {Indepedent, Dependent };
    public enum SubjectDesign {Bewtween, Within};
    */
    public partial class MainWindow : Window
    {
        private DataStructure datas;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void setInvisible()
        {
            this.canvas0.Visibility = System.Windows.Visibility.Hidden;
            this.canvas1.Visibility = System.Windows.Visibility.Hidden;
            this.canvas2.Visibility = System.Windows.Visibility.Hidden;
            this.canvas3.Visibility = System.Windows.Visibility.Hidden;
            this.canvas4.Visibility = System.Windows.Visibility.Hidden;
            this.canvas5.Visibility = System.Windows.Visibility.Hidden;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            setInvisible();
            this.canvas1.Visibility = System.Windows.Visibility.Visible;
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            setInvisible();
            this.canvas2.Visibility = System.Windows.Visibility.Visible;
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            setInvisible();
            this.canvas3.Visibility = System.Windows.Visibility.Visible;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            setInvisible();
            this.canvas4.Visibility = System.Windows.Visibility.Visible;
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            setInvisible();
            this.canvas5.Visibility = System.Windows.Visibility.Visible;
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            ObservableCollection<Member> memberData = new ObservableCollection<Member>();
            //dataGrid.DataContext = memberData;
            //dataGrid.
            memberData.Add(new Member()
            {
                FactorsName = "Technology",
                FactorsType = vTypes.Indepedent,
                FactorsDesign = SubjectDesign.Within,
                Levels = "ipod and earpod"
            });
             * */
           this.datas = new DataStructure();
           this.datas.researchQuestion.experimentTitle = "Ipod and Earpod";
           this.datas.researchQuestion.experimentConductor = "Sam";
           this.datas.researchQuestion.experimentDescription = "This is an experiment to compare differnt technologies.";

           this.datas.researchQuestion.hypothesis.mainSolution = "earPod";
           this.datas.researchQuestion.hypothesis.context = "Noisy environment";
           this.datas.researchQuestion.hypothesis.compareSolutions.Add(new ResearchQuestion.Hypothesis.CompareSolution(0,"ipod"));
           this.datas.researchQuestion.hypothesis.tasks.Add(new ResearchQuestion.Hypothesis.Task(0,"Single Tasks"));
           this.datas.researchQuestion.hypothesis.measures.Add(new ResearchQuestion.Hypothesis.Measure(0,"Time cost"));

           //Indpedent variables
           this.datas.independentVariables.Add(new IndependentVariable());
           this.datas.independentVariables.Add(new IndependentVariable());
           this.datas.independentVariables.Add(new IndependentVariable());

           this.datas.independentVariables[0].subjectDesign = SUBJECTDESIGN.Between;
           this.datas.independentVariables[1].subjectDesign = SUBJECTDESIGN.Between;
           this.datas.independentVariables[2].subjectDesign = SUBJECTDESIGN.Between;

           this.datas.independentVariables[0].counterBalance = COUNTERBALANCE.LatinSquare;
           this.datas.independentVariables[1].counterBalance = COUNTERBALANCE.LatinSquare;
           this.datas.independentVariables[2].counterBalance = COUNTERBALANCE.LatinSquare;

           this.datas.independentVariables[0].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[0].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[0].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[0].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[1].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[1].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[1].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[1].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[2].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[2].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[2].levels.Add(new IndependentVariable.Level());
           this.datas.independentVariables[2].levels.Add(new IndependentVariable.Level());

           this.datas.independentVariables[0].levels[0].value = this.datas.researchQuestion.hypothesis.mainSolution;
           this.datas.independentVariables[0].levels[1].value = this.datas.researchQuestion.hypothesis.compareSolutions[0].name;

           this.datas.independentVariables[1].levels[0].value = this.datas.researchQuestion.hypothesis.context;
           this.datas.independentVariables[1].levels[1].value = "Quiet environment";

           this.datas.independentVariables[2].levels[0].value = this.datas.researchQuestion.hypothesis.tasks[0].name;
           this.datas.independentVariables[2].levels[1].value = "Multi Tasks";

            //Dependent
           this.datas.dependentVariables.Add(new DependentVariable());
           this.datas.dependentVariables.Add(new DependentVariable());
           this.datas.dependentVariables.Add(new DependentVariable());
           this.datas.dependentVariables[0].name = this.datas.researchQuestion.hypothesis.measures[0].name;

           //arrangement
           this.datas.arrangement.minNum = 4;
           this.datas.arrangement.actualNum = 12;
           this.datas.arrangement.trial = 3;
           this.datas.arrangement.block = 2;
           this.datas.arrangement.timePerTrial = 30;
           this.datas.arrangement.feePerParticipant = 10;
           this.datas.arrangement.totalPayment = 5;

           BindingProcess();
        }
        public void BindingProcess()
        {
            this.textbox0.DataContext = datas;
            this.textbox1.DataContext = datas;
            this.textbox2.DataContext = datas;
            this.textbox3.DataContext = datas;
            this.textbox4.DataContext = datas;

            this.textbox5.DataContext = datas.researchQuestion.hypothesis;
            this.textbox6.DataContext = datas.researchQuestion.hypothesis;
            this.textbox7.DataContext = datas.researchQuestion.hypothesis;
            this.textbox8.DataContext = datas.researchQuestion.hypothesis;
            this.textbox9.DataContext = datas.researchQuestion.hypothesis;

            this.textbox10.DataContext = datas.independentVariables;
            this.textbox11.DataContext = datas.independentVariables;
            this.textbox12.DataContext = datas.independentVariables;
            this.textbox13.DataContext = datas.independentVariables;
            this.textbox14.DataContext = datas.independentVariables;
            this.textbox15.DataContext = datas.independentVariables;
            this.textbox16.DataContext = datas.independentVariables;
            this.textbox17.DataContext = datas.independentVariables;
            this.textbox18.DataContext = datas.independentVariables;
            this.textbox19.DataContext = datas.independentVariables;
            this.textbox20.DataContext = datas.independentVariables;
            this.textbox21.DataContext = datas.independentVariables;
            this.textbox22.DataContext = datas.independentVariables;
            this.textbox23.DataContext = datas.independentVariables;
            this.textbox24.DataContext = datas.independentVariables;

            this.combobox1.DataContext = datas.independentVariables;
            this.combobox2.DataContext = datas.independentVariables;
            this.combobox3.DataContext = datas.independentVariables;

            this.DV1.DataContext = datas.dependentVariables;
            this.DV2.DataContext = datas.dependentVariables;
            this.DV3.DataContext = datas.dependentVariables;

            this.IDV1.DataContext = datas.independentVariables;
            this.IDV1_L1.DataContext = datas.independentVariables;
            this.IDV1_L2.DataContext = datas.independentVariables;
            this.IDV1_L3.DataContext = datas.independentVariables;
            this.IDV1_L4.DataContext = datas.independentVariables;
            this.IDV2.DataContext = datas.independentVariables;
            this.IDV2_L1.DataContext = datas.independentVariables;
            this.IDV2_L2.DataContext = datas.independentVariables;
            this.IDV2_L3.DataContext = datas.independentVariables;
            this.IDV2_L4.DataContext = datas.independentVariables;
            this.IDV3.DataContext = datas.independentVariables;
            this.IDV3_L1.DataContext = datas.independentVariables;
            this.IDV3_L2.DataContext = datas.independentVariables;
            this.IDV3_L3.DataContext = datas.independentVariables;
            this.IDV3_L4.DataContext = datas.independentVariables;
            this.counterBalance1.DataContext = datas.independentVariables;
            this.counterBalance2.DataContext = datas.independentVariables;
            this.counetrBalance3.DataContext = datas.independentVariables;

            this.trial.DataContext = datas.arrangement;
            this.block.DataContext = datas.arrangement;
            this.timePerTrial.DataContext = datas.arrangement;
            this.minNum.DataContext = datas.arrangement;
            this.actualNum.DataContext = datas.arrangement;
            this.feePerParticipant.DataContext = datas.arrangement;
            this.totalpayment.DataContext = datas.arrangement;
            this.totaltimecost.DataContext = datas.arrangement;
        }
    }
    /*
    public class Member
    {
        public string FactorsName {get; set;}
        public vTypes FactorsType { get; set; }
        public SubjectDesign FactorsDesign { get; set; }
        public string Levels { get; set; }
    } 
     */
}
