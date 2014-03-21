namespace SocialMediaiOS
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Net.Http;
    using System.Threading.Tasks;

    using MonoTouch.CoreGraphics;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;



    public class ImageCell : UICollectionViewCell
    {
        UIImageView imageView;

        [Export("initWithFrame:")]
        ImageCell(RectangleF frame)
            : base(frame)
        {
            this.imageView = new UIImageView(new RectangleF(0, 0, 200, 100));
            this.imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            this.ContentView.AddSubview(this.imageView);
            this.ContentView.Transform = CGAffineTransform.MakeScale(0.9f, 0.9f);
            this.BackgroundView = new UIView { BackgroundColor = UIColor.White };
            this.SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Black };
        }



         async internal void UpdateImage(string path)
         {                
            using (var image = await LoadImage(path))
            {
                imageView.Image = this.ResizeImage(image,200f,100f);

            }
         }

         public UIImage ResizeImage(UIImage sourceImage, float width, float height)
         {
             UIGraphics.BeginImageContext(new SizeF(width, height));
             sourceImage.Draw(new RectangleF(0, 0, width, height));
             var resultImage = UIGraphics.GetImageFromCurrentImageContext();
             UIGraphics.EndImageContext();
             return resultImage;
         }

         public async Task<UIImage> LoadImage(string imageUrl)
         {
             var httpClient = new HttpClient();

             Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(imageUrl);

             // await! control returns to the caller and the task continues to run on another thread
             var contents = await contentsTask;

             // load from bytes
             return UIImage.LoadFromData(NSData.FromArray(contents));
         }   


    }
}

