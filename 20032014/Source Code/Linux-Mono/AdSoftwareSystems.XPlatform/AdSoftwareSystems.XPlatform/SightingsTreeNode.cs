using System;

namespace AdSoftwareSystems.XPlatform
{
		[Gtk.TreeNode (ListOnly=true)]
		public class SightingsTreeNode : Gtk.TreeNode {
			
			public SightingsTreeNode (string userId, string statusUpdate)
			{
				StatusUpdate = statusUpdate;
				UserId = userId;
			}

			[Gtk.TreeNodeValue (Column=0)]
			public string UserId;

			[Gtk.TreeNodeValue (Column=1)]
			public string StatusUpdate;
		}
}

