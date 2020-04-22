using Dekret_CSharpLab1.ViewModel;
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

namespace Dekret_CSharpLab1
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new BirthDateViewModel();
            InitializeComponent();
        }
    }
}
