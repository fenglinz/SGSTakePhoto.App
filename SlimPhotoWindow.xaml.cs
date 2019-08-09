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
using System.Windows.Shapes;

namespace SGSTakePhoto.App
{
    /// <summary>
    /// SlimPhotoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SlimPhotoWindow : UserControl
    {
        public SlimPhotoWindow()
        {
            InitializeComponent();
        }

        private void TxtOrderNum_Click(object sender, RoutedEventArgs e)
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
                        case "txtOrderNum":

                            break;
                        case "txtSampleId":

                            break;
                    }
                }
            }
        }

        private void BtnTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            Order order = dgSlimOrder.SelectedItem as Order;
            if (order == null)
            {

            }

            if (!CommonHelper.UserControls.ContainsKey("SlimOrder"))
            {
                SlimOrderModule slimOrderOrder = new SlimOrderModule(order);
                CommonHelper.MainWindow.brMain.Child = slimOrderOrder;
                CommonHelper.UserControls.Add("SlimOrder", slimOrderOrder);
            }
            else
            {
                CommonHelper.MainWindow.brMain.Child = CommonHelper.UserControls["SlimOrder"];
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            Order order = dgSlimOrder.SelectedItem as Order;
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
