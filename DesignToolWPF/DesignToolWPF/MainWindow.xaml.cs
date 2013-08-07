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
    public enum MODE {NewItem, CopyItem};
    public partial class MainWindow : Window
    {
        private DataStructure datas;
        private MODE modeType;
        private Boolean FLAG = true;
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
            if (this.modeType == MODE.NewItem && this.FLAG)
            {
                this.FLAG = false;
                ResearchQuestionGenerateVariables();
            }
            this.canvas2.Visibility = System.Windows.Visibility.Visible;
            Log.getLogInstance().writeLog(this.datas.independentVariables[0].levels[2].value);
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
           this.modeType = MODE.NewItem;

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
           this.datas.arrangement.minNum = 8;
           this.datas.arrangement.actualNum = 12;
           this.datas.arrangement.trial = 3;
           this.datas.arrangement.block = 2;
           this.datas.arrangement.timePerTrial = 30;
           this.datas.arrangement.feePerParticipant = 10;

           BindingProcess();
        }
        public void BindingProcess()
        {
            this.TestBox.DataContext = datas;
            this.ResearchQuestion.DataContext = datas;
            this.RQ_experimentTitle.DataContext = datas;
            this.RQ_experimentConductor.DataContext = datas;
            this.RQ_experimentDescription.DataContext = datas;

            this.mainSolution.DataContext = datas.researchQuestion.hypothesis;
            this.compareSolutions.DataContext = datas.researchQuestion.hypothesis;
            this.tasks.DataContext = datas.researchQuestion.hypothesis;
            this.context.DataContext = datas.researchQuestion.hypothesis;
            this.measures.DataContext = datas.researchQuestion.hypothesis;

            this.IDV1_name.DataContext = datas.independentVariables;
            this.IDV1_1.DataContext = datas.independentVariables;
            this.IDV1_2.DataContext = datas.independentVariables;
            this.IDV1_3.DataContext = datas.independentVariables;
            this.IDV1_4.DataContext = datas.independentVariables;
            this.IDV2_name.DataContext = datas.independentVariables;
            this.IDV2_1.DataContext = datas.independentVariables;
            this.IDV2_2.DataContext = datas.independentVariables;
            this.IDV2_3.DataContext = datas.independentVariables;
            this.IDV2_4.DataContext = datas.independentVariables;
            this.IDV3_name.DataContext = datas.independentVariables;
            this.IDV3_1.DataContext = datas.independentVariables;
            this.IDV3_2.DataContext = datas.independentVariables;
            this.IDV3_3.DataContext = datas.independentVariables;
            this.IDV3_4.DataContext = datas.independentVariables;

            this.IDV1_subdesign.DataContext = datas.independentVariables;
            this.IDV2_subdesign.DataContext = datas.independentVariables;
            this.IDV3_subdesign.DataContext = datas.independentVariables;

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

        public void ResearchQuestionGenerateVariables()
        { 
            //ResearchQuestion Generate Independent Variables
            this.datas.independentVariables[0].levels[0].value = this.datas.researchQuestion.hypothesis.mainSolution;
            string [] words = this.datas.researchQuestion.hypothesis.compareSolutions[0].name.Split('/');
            for (int i = 0; i < words.Length; i++)
            {
                this.datas.independentVariables[0].levels[i + 1].value = words[i];
                Log.getLogInstance().writeLog(words.Length.ToString());
                Log.getLogInstance().writeLog(this.datas.independentVariables[0].levels[2].value);
            }
            words = null;
            words = this.datas.researchQuestion.hypothesis.tasks[0].name.Split('/');
            for (int i = 0; i < words.Length; i++)
            {
                this.datas.independentVariables[2].levels[i].value = words[i];
            }
            words = null;
            words = this.datas.researchQuestion.hypothesis.measures[0].name.Split('/');
            for (int i = 0; i < words.Length; i++)
            {
                this.datas.dependentVariables[i].name = words[i];
            }
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
