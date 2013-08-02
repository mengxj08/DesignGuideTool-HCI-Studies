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
           this.datas.researchQuestion.experimentConductor = "Yongfeng Huang";
           this.datas.researchQuestion.experimentDescription = "This is an experiment to compare differnt technologies.";

           this.datas.researchQuestion.hypothesis.mainSolution = "earPod";
           this.datas.researchQuestion.hypothesis.compareSolutions.Add(new ResearchQuestion.Hypothesis.CompareSolution(0,"ipod"));
           this.datas.researchQuestion.hypothesis.tasks.Add(new ResearchQuestion.Hypothesis.Task(0,"Single Tasks"));
           this.datas.researchQuestion.hypothesis.measures.Add(new ResearchQuestion.Hypothesis.Measure(0,"Time cost"));
           BindingProcess();
        }
        public void BindingProcess()
        {
            this.textbox0.DataContext = datas;
            this.textbox1.DataContext = datas;
            this.textbox2.DataContext = datas;
            this.textbox3.DataContext = datas;
            this.textbox4.DataContext = datas;
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
