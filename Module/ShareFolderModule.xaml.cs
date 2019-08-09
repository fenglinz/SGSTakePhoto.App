using SGSTakePhoto.Infrastructure;
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

namespace SGSTakePhoto.App
{
    /// <summary>
    /// OtsOrderModule.xaml 的交互逻辑
    /// </summary>
    public partial class ShareFolderModule : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public ShareFolderModule(Order order)
        {
            InitializeComponent();

            this.Order = order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            CommonHelper.MainWindow.brMain.Child = CommonHelper.MainWindow.shareFolderModule;
        }
    }
}
