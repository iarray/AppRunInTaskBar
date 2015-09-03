using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace 程序嵌于任务栏
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            this.Loaded += MainWindow_Loaded;
        }

        
        private TaskbarApp tapp;
        private ContentWindow cw = new ContentWindow();

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tapp = new TaskbarApp(this);
            tapp.EmbedTaskbar();
            Storyboard sb1 = (Storyboard)this.Resources["stb1"];
            sb1.Begin();
            cw.Show();
            cw.Visibility = Visibility.Hidden;
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (cw.Visibility == Visibility.Hidden)
            {
                cw.Left = this.Left-5;
                cw.Top = this.Top-cw.Height;
                cw.ShowWithStory();
                cw.Visibility = Visibility.Visible;
            }
            else
            {
                cw.Visibility = Visibility.Hidden;
            }
        }

        private void menuClose_Click_1(object sender, RoutedEventArgs e)
        {
            tapp.Dispose();
            cw.Close();
            this.Close();
        }
    }
}
