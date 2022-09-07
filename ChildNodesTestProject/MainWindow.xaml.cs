using DevExpress.Export;
using DevExpress.Mvvm;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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

namespace ChildNodesSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<GeneralClass> G { get; set; } = new ObservableCollection<GeneralClass>();
        
        public MainWindow()
        {
            NodeClass ND = new NodeClass();
            G.Add(new GeneralClass());
            G.Add(new GeneralClass());
            G.Add(new GeneralClass());
            this.DataContext = this;
            InitializeComponent();
            //TRVIEW.ExpandAllNodes();    // If comment this line, the TreeViewControl nodes cannot be expanded
        }

    }
}
