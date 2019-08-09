using SGSTakePhoto.Infrastructure;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFMediaKit.DirectShow.Controls;

namespace SGSTakePhoto.App
{
    /// <summary>
    /// ScanWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScanWindow : Window
    {
        public bool IsClosed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ScanWindow()
        {
            InitializeComponent();
            cmbCam.ItemsSource = MultimediaUtil.VideoInputNames;
            if (MultimediaUtil.VideoInputNames.Length > 0)
            {
                cmbCam.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No camera found", "Notice", MessageBoxButton.OK, MessageBoxImage.Error);
                IsClosed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoCapture_NewVideoSample(object sender, WPFMediaKit.DirectShow.MediaPlayers.VideoSampleArgs e)
        {

        }

        /// <summary>
        /// 切换摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbCam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VideoCapture.VideoCaptureSource = (string)cmbCam.SelectedItem;
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            //抓取控件做成图片
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)VideoCapture.ActualWidth, (int)VideoCapture.ActualHeight, 96, 96, PixelFormats.Default);
            bmp.Render(VideoCapture);
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                byte[] captureData = ms.ToArray();

                BarCodeScan scan = new BarCodeScan();
                Response<string> result = scan.GetBarCode(captureData, (int)VideoCapture.ActualWidth, (int)VideoCapture.ActualHeight);
                if (!result.Success)
                {
                    MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    BarCode = result.Data;
                }
            }

            VideoCapture.Pause();

            if (string.IsNullOrEmpty(BarCode))
            {
                MessageBox.Show("No valid barcode was obtained,Please Retry", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 重新拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRePlay_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture.Play();
        }
    }
}
