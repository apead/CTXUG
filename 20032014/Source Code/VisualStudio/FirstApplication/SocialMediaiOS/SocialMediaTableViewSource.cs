using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SocialMediaiOS
{
    public class SocialMediaTableViewSource : UITableViewSource
    {
        private IList<SightingsMediaPost> _posts;
        private string cellIdentifier = "SocialMediaTableCell";

        public SocialMediaTableViewSource(IList<SightingsMediaPost> posts)
        {
            _posts = posts;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _posts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier);

            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            var item = _posts[indexPath.Row];
            cell.TextLabel.Text = item.StatusUpdate;
            return cell;
        }
    }
}