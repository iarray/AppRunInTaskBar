using System.Windows;
using System.Windows.Media.Animation;

namespace 程序嵌于任务栏
{
    /// <summary>
    /// ContentWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ContentWindow : Window
    {
        public ContentWindow()
        {
            InitializeComponent();
        }

        public void ShowWithStory()
        {
            Storyboard sb1 = (Storyboard)this.Resources["cwstb"];
            sb1.Begin();
        }
    }
}
