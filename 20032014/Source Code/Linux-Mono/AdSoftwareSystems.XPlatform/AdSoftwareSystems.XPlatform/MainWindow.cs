using System;
using Gtk;
using System.Net.Http;
using Newtonsoft.Json;
using AdSoftwareSystems.XPlatform;

namespace GtkApplication.Dto
{

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	
			nodeview1.AppendColumn ("UserId", new Gtk.CellRendererText (), "text", 0);
			nodeview1.AppendColumn ("Status Update", new Gtk.CellRendererText (), "text", 1);

		button5.Clicked += (object sender, EventArgs e) => {
			PopulateListView ();
		};

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	public async void PopulateListView()
	{
		var client = new HttpClient();

		var resultAsync =
			client.GetStringAsync(
				"http://azurexamarindem.cloudapp.net/webapidemo/api/SocialMedia/GetAllSocialMedia");

		var result = await resultAsync;

		var buffer = textview1.Buffer;
		buffer.Text = result;

		var posts = JsonConvert.DeserializeObject<SightingsMediaPost[]>(result);

		CreateNodeStore (posts);
	}

		public void CreateNodeStore(SightingsMediaPost[] posts)
		{
			var store = new Gtk.NodeStore (typeof(SightingsTreeNode));
			foreach (var post in posts) {
				store.AddNode(new SightingsTreeNode(post.UserId,post.StatusUpdate));
			}
		
			nodeview1.NodeStore = store;
		}
	}
}