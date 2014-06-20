using System;
using Xamarin.Forms;

namespace SimpleTabs
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			this.Title = "Login";
			var stack = new StackLayout {
				Spacing = 20, Padding = 50,
				VerticalOptions = LayoutOptions.Center
			};


			var username = new Entry { Placeholder = "Username" };
			var password = new Entry { Placeholder = "Password", IsPassword = true };
			var login = new Button {
				Text = "Login",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex ("77D065")
			};

			login.Clicked += (sender, EventArgs) => {
				Navigation.PushAsync(new HomePage());
			};

			stack.Children.Add (username);
			stack.Children.Add (password);
			stack.Children.Add (login);

			Content = stack;
		}
	}
}

