using System;

namespace DatabaseApplication
{
	public partial class ViewRowWindow : Gtk.Window
	{
		public ViewRowWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

