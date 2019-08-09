using SGSTakePhoto.Infrastructure;
using System.Windows.Controls;

namespace SGSTakePhoto.App
{
    /// <summary>
    /// UploadModule.xaml 的交互逻辑
    /// </summary>
    public partial class UploadModule : UserControl
    {
        private Order order;

        /// <summary>
        /// 
        /// </summary>
        public UploadModule(Order order)
        {
            InitializeComponent();
            this.order = order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpload_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
