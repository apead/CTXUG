using System;
using Xamarin.Forms;
using System.Linq;

namespace SimpleTabs
{
	public class HomePage : TabbedPage
	{
		public HomePage ()
		{
			this.Title = "Home";
			this.Children.Add (new ProfilePage ());
			this.Children.Add (new SettingsPage ());
		}
	}

	public class ProfilePage : ContentPage
	{
		public ProfilePage()
		{
			this.Title = "Profile";
			this.Icon = "profile.png";

			Content = new Label{ Text = "This is the profile page" };
		}
	}

	public class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			this.Title = "Settings";
			this.Icon = "settings.png";
			var list = new ListView ();
			list.ItemsSource = new []{ "Xamarin.Forms", "Is", "Really", "Awesome" };

			list.ItemSelected += (sender, args) => {
				DisplayAlert("Selected", list.SelectedItem.ToString(), "OK", null);
			};

			Content = list;
		}
	}
}

