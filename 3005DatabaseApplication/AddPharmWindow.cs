using System;
using Gtk;
using Mono.Data.Sqlite;

namespace DatabaseApplication
{
	public partial class AddPharmWindow : Gtk.Window
	{
		SqliteCommand comm = null;

		public AddPharmWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void CreatePharm (object sender, EventArgs e)
		{
			try {

				bool check = true;
				SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
				conn.Open ();

				long sin = 0;
				long supersin = 0;
				long salary = 0;

				if (!sin_entry.Text.Equals (""))
					sin = Convert.ToInt64 (sin_entry.Text);

				if (!super_entry.Text.Equals (""))
					supersin = Convert.ToInt64 (super_entry.Text);

				if (!sal_entry.Text.Equals (""))
					salary = Convert.ToInt64 (sal_entry.Text);

				string[] allEntries = new string[8];

				string name = name_entry.Text;
				allEntries [0] = name;
				string address = add_entry.Text;
				allEntries [1] = address;
				string email = email_entry.Text;
				allEntries [2] = email;
				string phone = phone_entry.Text;
				allEntries [3] = phone;
				allEntries [4] = sal_entry.Text;
				allEntries [5] = super_entry.Text;
				allEntries [6] = sin_entry.Text;
				string dateofbirth = dob_cal.GetDate().ToShortDateString();
				allEntries [7] = dateofbirth;


				foreach (string s in allEntries) 
				{
					if (s.Equals ("") || s.Equals (" ")) 
					{

						MessageDialog dialog = new MessageDialog (null,
						                                          DialogFlags.Modal,
						                                          MessageType.Error, 
						                                          ButtonsType.Ok,
						                                          "Cannot have empty fields! ");
						dialog.Run ();
						dialog.Destroy ();

						check = false;
					
						break;
					}
				}

				if (check)
				{
					comm = new SqliteCommand ("INSERT INTO pharmacists (sin, name, address, email, phone, salary, supersin, dateofbirth) " + 

					                          "values (" +  
					                          sin + ", '" +
					                          name + "', '" +
					                          address + "', '" +
					                          email + "', '" +
					                          phone + "', " +
					                          salary + ", " +
					                          supersin + ", '" +
					                          dateofbirth + "'" +
					                          ");", conn);
			    	comm.ExecuteNonQuery();

					this.Destroy();
				}
				else
				{
					conn.Close();
				}
			} 
			catch (Exception ex) 
			{
				MessageDialog dialog = new MessageDialog (null,
				                                          DialogFlags.Modal,
				                                          MessageType.Error, 
				                                          ButtonsType.Ok,
				                                          ex.ToString().Substring(0, 100));
				dialog.Run ();
				dialog.Destroy ();

				Console.WriteLine (ex.ToString());
			}	
		}
	}
}

