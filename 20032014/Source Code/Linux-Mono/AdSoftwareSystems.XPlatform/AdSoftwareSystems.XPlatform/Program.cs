using System;
using Gtk;
using System.Net.Http;
using GtkApplication.Dto;


namespace AdSoftwareSystems.XPlatform
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();

		}
	}


}
