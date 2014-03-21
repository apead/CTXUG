namespace SocialMediaAndroid
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Android.App;
    using Android.Graphics;
    using Android.Views;
    using Android.Widget;

    using Object = Java.Lang.Object;

    public class SocialMediaListItem : Object
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string SubTitle { get; set; }
    }

    public class SocialListViewAdapter : BaseAdapter
    {
        private readonly List<SocialMediaListItem> _listItems;
        private Activity _activity;
        private ImageDownloader _imageDownloader = new AndroidImageDownloader();
        private Dictionary<string, Bitmap> _images = new Dictionary<string, Bitmap>();
        private List<string> _imageDownloadsInProgress = new List<string>();

        private int _layout;

        public SocialListViewAdapter(Activity activity, List<SocialMediaListItem> listItems, int layout)
        {
            this._listItems = listItems;
            this._activity = activity;
            this._layout = layout;
        }

        public override Object GetItem(int position)
        {
            return this._listItems[position];
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this._listItems[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = this._activity.LayoutInflater.Inflate(this._layout, null);
            
            view.FindViewById<TextView>(Resource.Id.SocialMediaLayoutHeadingTextView).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.SocialMediaLayoutBodyTextView).Text = item.SubTitle;
            var imageView = view.FindViewById<ImageView>(Resource.Id.SocialMediaLayoutImageView);

            if (item.Id == null || item.Image == null)
            {
                return view;
            }
            if (this._images.ContainsKey(item.Id))
            {
                imageView.SetImageBitmap(this._images[item.Id]);
            }
            else
            {
                this.StartImageDownload(parent as ListView, position, item);
            }
            return view;
        }

        public override int Count
        {
            get
            {
                return this._listItems.Count;
            }
        }

 void StartImageDownload (ListView listView, int position, SocialMediaListItem item)
        {
            if (this._imageDownloadsInProgress.Contains (item.Id))
                return;

            var uri = new Uri(item.Image, UriKind.Absolute);

            //if (_imageDownloader.HasLocallyCachedCopy(uri))
            //{

            //    var image = _imageDownloader.GetImage(uri);
            //    FinishImageDownload(listView, position, item, (Bitmap)image);

            //} else 
            {
                this._imageDownloadsInProgress.Add (item.Id);

                this._imageDownloader.GetImageAsync (uri).ContinueWith (t => {
                    if (!t.IsFaulted) {
                        this.FinishImageDownload (listView, position, item, (Bitmap)t.Result);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext ());
            }
        }

        void FinishImageDownload (ListView listView, int position, SocialMediaListItem item, Bitmap image)
        {
            this._images [item.Id] = image;
            this._imageDownloadsInProgress.Remove (item.Id);

            var socialMediaItem = (position < this._listItems.Count) ?
                            this._listItems[position] :
                            null;

                var firstPostion = listView.FirstVisiblePosition - listView.HeaderViewsCount;
                var childIndex = position - firstPostion;

                if (0 <= childIndex && childIndex < listView.ChildCount) {
                    var view = listView.GetChildAt (childIndex);
                    var imageView = view.FindViewById<ImageView>(Resource.Id.SocialMediaLayoutImageView);
                    imageView.SetImageBitmap(image);
            }
        }
    }
}