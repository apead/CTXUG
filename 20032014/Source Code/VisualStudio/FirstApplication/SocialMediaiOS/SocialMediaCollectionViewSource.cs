using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SocialMediaiOS
{
    public class SocialMediaCollectionViewSource : UICollectionViewSource
    {
        private IList<SightingsMediaPost> _posts;
        public static NSString cellIdentifier = new NSString("SocialMediaCollectionCell");

        public SocialMediaCollectionViewSource(IList<SightingsMediaPost> posts)
        {
            _posts = posts;
        }

        public override int GetItemsCount(UICollectionView collectionView, int section)
        {
           return  _posts.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var imageCell = (ImageCell)collectionView.DequeueReusableCell(cellIdentifier, indexPath);

            imageCell.UpdateImage(_posts[indexPath.Row].Image);

            return imageCell;

        }
    }
}