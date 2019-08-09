using SGSTakePhoto.Infrastructure;
using System;
using ZXing;
using ZXing.Common;

namespace SGSTakePhoto.App
{
    /// <summary>
    /// 
    /// </summary>
    public class BarCodeScan
    {
        /// <summary>
        /// 获取条形码的值
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Response<string> GetBarCode(Byte[] buffer, int width, int height)
        {
            try
            {
                LuminanceSource source = new RGBLuminanceSource(buffer, width, height);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));

                MultiFormatReader reader = new MultiFormatReader();
                Result result = reader.decode(bitmap);

                return new Response<string> { Data = result.Text };
            }
            catch (Exception ex)
            {
                return new Response<string> { ErrorMessage = ex.Message };
            }
        }
    }
}
