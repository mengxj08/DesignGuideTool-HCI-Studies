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
    public enum vTypes {Indepedent, Dependent };
    public enum SubjectDesign {Bewtween, Within};
    public partial class MainWindow : Window
    {
        public int num = 1;
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
        }
    }
    
    public class Member
    {
        public string FactorsName {get; set;}
        public vTypes FactorsType { get; set; }
        public SubjectDesign FactorsDesign { get; set; }
        public string Levels { get; set; }
    } 
}
