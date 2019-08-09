using SGSTakePhoto.Infrastructure;
using System.Windows;
using System.Windows.Controls;

namespace SGSTakePhoto.App
{
    /// <summary>
    /// OtsPhotoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OtsPhotoWindow : UserControl
    {
        public OtsPhotoWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击扫描按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            ScanWindow scan = new ScanWindow { };
            //如果是激活状态则返回
            if (scan.IsClosed)
            {
                scan.Close();
            }
            else
            {
                if (scan.ShowDialog() == false)
                {
                    switch ((sender as TextBox).Name)
                    {
                        case "txtCaseNum":

                            break;
                        case "txtJobNum":

                            break;
                        case "txtSampleId":

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            Order order = dgOtsOrder.SelectedItem as Order;
            if (order == null)
            {

            }

            if (!CommonHelper.UserControls.ContainsKey("OtsOrder"))
            {
                OtsOrderModule otsOrder = new OtsOrderModule(order);
                CommonHelper.MainWindow.brMain.Child = otsOrder;
                CommonHelper.UserControls.Add("OtsOrder", otsOrder);
            }
            else
            {
                CommonHelper.MainWindow.brMain.Child = CommonHelper.UserControls["OtsOrder"];
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            Order order = dgOtsOrder.SelectedItem as Order;
            if (order == null)
            {

            }

            if (!CommonHelper.UserControls.ContainsKey("Upload"))
            {
                UploadModule uploadModule = new UploadModule(order);
                CommonHelper.MainWindow.brMain.Child = uploadModule;
                CommonHelper.UserControls.Add("Upload", uploadModule);
            }
            else
            {
                CommonHelper.MainWindow.brMain.Child = CommonHelper.UserControls["Upload"];
            }
        }
    }
}
