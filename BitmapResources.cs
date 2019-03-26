using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Bonus630.vsta.FacaCaixaAuto
{
    
        public static class BitmapResources
        {
          
            public static  BitmapSource ConvertToBitmapSource(this System.Drawing.Bitmap resource)
            {
                var image = resource;
                var bitmap = new System.Drawing.Bitmap(image);
                var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                                      IntPtr.Zero,
                                                                                      Int32Rect.Empty,
                                                                                      BitmapSizeOptions.FromEmptyOptions()
                      );

                bitmap.Dispose();
                return bitmapSource;
            }

            
            
           
        }
    

}
