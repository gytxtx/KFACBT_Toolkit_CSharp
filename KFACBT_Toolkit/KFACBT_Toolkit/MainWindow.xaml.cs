using iNKORE.UI.WPF.Modern.Controls;
using System.Text;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KFACBT_Toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public static class GlobalVariables
    {
        public static string Application_Name = "KFACBT's Toolkit";
    }
    public partial class MainWindow : Window
    {

        // NavigationPages.Home home = new NavigationPages.Home(); //运行程序之前初始化页面

        public MainWindow()
        {
            InitializeComponent();

            // 设置窗口标题
            Title = GlobalVariables.Application_Name;

            // 默认加载页面
            MainFrame.Navigate(typeof(NavigationPages.Home));

            new ToastContentBuilder()
                .AddText("欢迎使用" + " " + GlobalVariables.Application_Name + "。")
                .AddText("窗口的初始化已完成。")
                .AddVisualChild(new AdaptiveProgressBar()
                {
                    Title = "测试“进度条”组件",
                    Value = 0.6,
                    ValueStringOverride = "1/1",
                    Status = "正在载入应用程序…"
                })
                .Show();
                
        }


        private void MainNavigation_ItemInvoked(iNKORE.UI.WPF.Modern.Controls.NavigationView sender, iNKORE.UI.WPF.Modern.Controls.NavigationViewItemInvokedEventArgs args)
        {
            Title = GlobalVariables.Application_Name + " - " + args.InvokedItem;
            if (args.InvokedItem.ToString() == "首页")
            {
                MainFrame.Navigate(typeof(NavigationPages.Home));
            }
            else if (args.InvokedItem.ToString() == "功能")
            {
                MainFrame.Navigate(typeof(NavigationPages.Menu));
            }
            else if (args.InvokedItem.ToString() == "设置")
            {
                MainFrame.Navigate(typeof(NavigationPages.Settings));
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "运行时出错！";
                contentDialog.Content = "错误：指定页面不存在";
                contentDialog.ShowAsync();
            }
        }
    }
}