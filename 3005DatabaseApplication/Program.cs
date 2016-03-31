using System;
using Gtk;

namespace DatabaseApplication
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.buildThis ();
			win.Show ();
			Application.Run ();
		}
	}
}
