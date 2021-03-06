
// This file has been generated by the GUI designer. Do not modify.
namespace DatabaseApplication
{
	public partial class AddPharmWindow
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox7;
		private global::Gtk.Entry sin_entry;
		private global::Gtk.Entry name_entry;
		private global::Gtk.Entry add_entry;
		private global::Gtk.HBox hbox8;
		private global::Gtk.Label label8;
		private global::Gtk.Label name;
		private global::Gtk.Label add;
		private global::Gtk.HBox hbox9;
		private global::Gtk.Entry email_entry;
		private global::Gtk.Entry phone_entry;
		private global::Gtk.Entry sal_entry;
		private global::Gtk.Entry super_entry;
		private global::Gtk.Calendar dob_cal;
		private global::Gtk.HBox hbox10;
		private global::Gtk.Label email;
		private global::Gtk.Label phone;
		private global::Gtk.Label sal;
		private global::Gtk.Label super;
		private global::Gtk.Label label15;
		private global::Gtk.Button button2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DatabaseApplication.AddPharmWindow
			this.Name = "DatabaseApplication.AddPharmWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Add Pharmacist");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child DatabaseApplication.AddPharmWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.sin_entry = new global::Gtk.Entry ();
			this.sin_entry.CanFocus = true;
			this.sin_entry.Name = "sin_entry";
			this.sin_entry.IsEditable = true;
			this.sin_entry.InvisibleChar = '●';
			this.hbox7.Add (this.sin_entry);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.sin_entry]));
			w1.Position = 0;
			// Container child hbox7.Gtk.Box+BoxChild
			this.name_entry = new global::Gtk.Entry ();
			this.name_entry.CanFocus = true;
			this.name_entry.Name = "name_entry";
			this.name_entry.IsEditable = true;
			this.name_entry.InvisibleChar = '●';
			this.hbox7.Add (this.name_entry);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.name_entry]));
			w2.Position = 1;
			// Container child hbox7.Gtk.Box+BoxChild
			this.add_entry = new global::Gtk.Entry ();
			this.add_entry.CanFocus = true;
			this.add_entry.Name = "add_entry";
			this.add_entry.IsEditable = true;
			this.add_entry.InvisibleChar = '●';
			this.hbox7.Add (this.add_entry);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.add_entry]));
			w3.Position = 2;
			this.vbox2.Add (this.hbox7);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox7]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Social Insurance Number");
			this.hbox8.Add (this.label8);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label8]));
			w5.Position = 0;
			w5.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.name = new global::Gtk.Label ();
			this.name.Name = "name";
			this.name.LabelProp = global::Mono.Unix.Catalog.GetString ("Name");
			this.hbox8.Add (this.name);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.name]));
			w6.Position = 1;
			w6.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.add = new global::Gtk.Label ();
			this.add.Name = "add";
			this.add.LabelProp = global::Mono.Unix.Catalog.GetString ("Address");
			this.hbox8.Add (this.add);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.add]));
			w7.Position = 2;
			w7.Fill = false;
			this.vbox2.Add (this.hbox8);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox8]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.email_entry = new global::Gtk.Entry ();
			this.email_entry.CanFocus = true;
			this.email_entry.Name = "email_entry";
			this.email_entry.IsEditable = true;
			this.email_entry.InvisibleChar = '●';
			this.hbox9.Add (this.email_entry);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.email_entry]));
			w9.Position = 0;
			// Container child hbox9.Gtk.Box+BoxChild
			this.phone_entry = new global::Gtk.Entry ();
			this.phone_entry.CanFocus = true;
			this.phone_entry.Name = "phone_entry";
			this.phone_entry.IsEditable = true;
			this.phone_entry.InvisibleChar = '●';
			this.hbox9.Add (this.phone_entry);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.phone_entry]));
			w10.Position = 1;
			// Container child hbox9.Gtk.Box+BoxChild
			this.sal_entry = new global::Gtk.Entry ();
			this.sal_entry.CanFocus = true;
			this.sal_entry.Name = "sal_entry";
			this.sal_entry.IsEditable = true;
			this.sal_entry.InvisibleChar = '●';
			this.hbox9.Add (this.sal_entry);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.sal_entry]));
			w11.Position = 2;
			// Container child hbox9.Gtk.Box+BoxChild
			this.super_entry = new global::Gtk.Entry ();
			this.super_entry.CanFocus = true;
			this.super_entry.Name = "super_entry";
			this.super_entry.IsEditable = true;
			this.super_entry.InvisibleChar = '●';
			this.hbox9.Add (this.super_entry);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.super_entry]));
			w12.Position = 3;
			// Container child hbox9.Gtk.Box+BoxChild
			this.dob_cal = new global::Gtk.Calendar ();
			this.dob_cal.CanFocus = true;
			this.dob_cal.Name = "dob_cal";
			this.dob_cal.DisplayOptions = ((global::Gtk.CalendarDisplayOptions)(35));
			this.hbox9.Add (this.dob_cal);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.dob_cal]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			this.vbox2.Add (this.hbox9);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox9]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox ();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.email = new global::Gtk.Label ();
			this.email.Name = "email";
			this.email.LabelProp = global::Mono.Unix.Catalog.GetString ("Email");
			this.hbox10.Add (this.email);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.email]));
			w15.Position = 0;
			w15.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.phone = new global::Gtk.Label ();
			this.phone.Name = "phone";
			this.phone.LabelProp = global::Mono.Unix.Catalog.GetString ("Phone");
			this.hbox10.Add (this.phone);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.phone]));
			w16.Position = 1;
			w16.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.sal = new global::Gtk.Label ();
			this.sal.Name = "sal";
			this.sal.LabelProp = global::Mono.Unix.Catalog.GetString ("Salary");
			this.hbox10.Add (this.sal);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.sal]));
			w17.Position = 2;
			w17.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.super = new global::Gtk.Label ();
			this.super.Name = "super";
			this.super.LabelProp = global::Mono.Unix.Catalog.GetString ("Supervisor (SIN)");
			this.hbox10.Add (this.super);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.super]));
			w18.Position = 3;
			w18.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.label15 = new global::Gtk.Label ();
			this.label15.Name = "label15";
			this.label15.LabelProp = global::Mono.Unix.Catalog.GetString ("Date of birth");
			this.hbox10.Add (this.label15);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.label15]));
			w19.PackType = ((global::Gtk.PackType)(1));
			w19.Position = 4;
			w19.Fill = false;
			this.vbox2.Add (this.hbox10);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox10]));
			w20.Position = 3;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.button2 = new global::Gtk.Button ();
			this.button2.CanFocus = true;
			this.button2.Name = "button2";
			this.button2.UseUnderline = true;
			this.button2.Label = global::Mono.Unix.Catalog.GetString ("Create Pharmacist");
			this.vbox2.Add (this.button2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.button2]));
			w21.PackType = ((global::Gtk.PackType)(1));
			w21.Position = 4;
			w21.Expand = false;
			w21.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 869;
			this.DefaultHeight = 301;
			this.Show ();
			this.button2.Clicked += new global::System.EventHandler (this.CreatePharm);
		}
	}
}
