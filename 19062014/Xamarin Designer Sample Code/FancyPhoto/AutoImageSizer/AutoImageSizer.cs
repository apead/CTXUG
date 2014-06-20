//Copyright 2014 Xamarin
using System;
using MonoTouch.UIKit;
using System.ComponentModel;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.CoreImage;
using System.Linq;

namespace Xamarin.Controls
{
	public enum FilterType
	{
		Sepia,
		Blur
	}
	[Register ("AutoImageSizer")]
	public class AutoImageSizer : UIImageView, IComponent
	{
		public override UIImage Image {
			get {
				return Adjusted;
			}
			set {
				OrigionalImage = value;
				proccessImage ();
			}
		}
		public UIImage OrigionalImage { get; set; }

		public UIImage Adjusted { 
			get{ return base.Image; }
			private set { base.Image = value; }
		}

		public AutoImageSizer (IntPtr p) : base(p)
		{
			Initialize ();
		}

		public AutoImageSizer ()
		{
			Initialize ();
		}
		public void Initialize()
		{

//			if (Site != null && Site.DesignMode)
			Image = UIImage.FromBundle ("james");

			ContentMode = UIViewContentMode.ScaleAspectFit;
		}

		public ISite Site { get; set; }

		public event EventHandler Disposed;

		bool autoCrop;
		[Export("AutoCrop"), Browsable(true)]
		public bool AutoCrop {
			get {
				return autoCrop;
			}
			set {
				autoCrop = value;
				proccessImage ();
			}
		}

		bool firstFaceOnly;
		[Export("FirstFaceOnly"), Browsable(true)]
		public bool FirstFaceOnly {
			get {
				return firstFaceOnly;
			}
			set {
				firstFaceOnly = value;
				proccessImage ();
			}
		}

		bool sepiaFilter;
		[Export("SepiaFilter"), Browsable(true)]
		public bool SepiaFilter {
			get {
				return sepiaFilter;
			}
			set {
				sepiaFilter = value;
				proccessImage ();
			}
		}

		bool blurFilter;
		[Export("BlurFilter"), Browsable(true)]
		public bool BlurFilter {
			get {
				return blurFilter;
			}
			set {
				blurFilter = value;
				proccessImage ();
			}
		}



		void proccessImage()
		{
			if (OrigionalImage == null)
				return;
			var ciImage = new CIImage(OrigionalImage);
			CIFilter lastFilter = null;
			if (AutoCrop) {
				var autoRect = GetMaxRect (ciImage);

				if (!autoRect.IsEmpty) {
					var crop = new CICrop {
						Image = ciImage,
						Rectangle = new CIVector (autoRect.X, autoRect.Y, autoRect.Width + 20, autoRect.Height + 20),
					};
					lastFilter = crop;
				}
			}

			if (SepiaFilter) {
				var sepiaFilter = new CISepiaTone () {
					Image = lastFilter == null ? ciImage : lastFilter.OutputImage,
					Intensity = 0.8f
				};
				lastFilter = sepiaFilter;
			}


			if (BlurFilter) {
				var blurFilter = new CIGaussianBlur () {
					Image = lastFilter == null ? ciImage : lastFilter.OutputImage,
					Radius = 40f,
				};
				lastFilter = blurFilter;
			}


			if (lastFilter == null) {
				Adjusted = OrigionalImage;
				return;
			}
			Adjusted = UIImage.FromImage (lastFilter.OutputImage);// UIImage.FromImage (ciImage);
		}



		RectangleF GetMaxRect(CIImage ciImage)
		{
			var rects = GetFaces (ciImage);
			if (rects.Length == 0)
				return RectangleF.Empty;
			if (rects.Length == 1 || FirstFaceOnly)
				return rects [0];

			var x = rects.Max(r => r.Left);
			var y = rects.Max (r => r.Top);
			var bottom = rects.Max (r => r.Bottom);
			var right = rects.Max (r => r.Right);

			return new RectangleF (x, y, right - x, right - y);
		}

		RectangleF[] GetFaces(CIImage ciImage)
		{
			var faceDetector = CIDetector.CreateFaceDetector (CIContext.FromOptions(null), FaceDetectorAccuracy.Low); 


			var features = faceDetector.FeaturesInImage(ciImage, CIImageOrientation.TopLeft);
			return features.OfType<CIFaceFeature> ().Select (x => x.Bounds).ToArray ();
		}

	}
}

