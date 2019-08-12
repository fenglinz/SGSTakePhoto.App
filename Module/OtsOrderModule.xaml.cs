using SGSTakePhoto.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class OtsOrderModule : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public OtsOrderModule(Order order)
        {
            InitializeComponent();

            this.Order = order;
            if (order != null)
            {
                gdOtsOrder.DataContext = order;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            CommonHelper.MainWindow.brMain.Child = CommonHelper.MainWindow.otsModule;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImageType_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender as Button;
            switch (btn.Content)
            {
                case "Original":
                    break;
                case "Before":
                    break;
                case "Testing":
                    break;
                case "During":
                    break;
                case "After":
                    break;
                case "Feature":
                    break;
                default:

                    break;
            }

            if (!CommonHelper.UserControls.ContainsKey("Camera"))
            {
                CameraModule cameraModule = new CameraModule(Order);
                CommonHelper.MainWindow.brMain.Child = cameraModule;
                CommonHelper.UserControls.Add("Camera", cameraModule);
            }
            else
            {
                CommonHelper.MainWindow.brMain.Child = CommonHelper.UserControls["Camera"];
            }
        }

        /// 关闭窗口事件
        /// </summary>
        ///<param name="sender">
        ///<param name="cancelEventArgs">
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            MessageBox.Show("OnClosing 子窗口要被关闭了");
            // 析构
        }
    }
}
