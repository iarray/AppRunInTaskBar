using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using 程序嵌于任务栏;

namespace AeroWindow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskbarApp tapp;

        public MainWindow()
        {
            InitializeComponent();
            tapp = new TaskbarApp(this);
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Style _style = null;
            if (Microsoft.Windows.Shell.SystemParameters2.Current.IsGlassEnabled == true)
            {
                _style = (Style)Resources["GadgetStyle"];
            }
            this.Style = _style;
            //将任务栏设为父窗体后，Aero效果无效，不明觉厉
            tapp.EmbedTaskbar();
        }


    }
}
