using System;
using Xamarin.Forms;

namespace SimpleTabs
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage(new LoginPage ());
		}
	}
}

