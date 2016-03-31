using System;
using Mono.Data.Sqlite;
using Gtk;

namespace DatabaseApplication
{
	public partial class AddClientWindow : Gtk.Window
	{
		SqliteCommand comm = null;

		public AddClientWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void CreateClient (object sender, EventArgs e)
		{
			try {

				bool check = true;

				SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
				conn.Open();

				long healthcard = 0;

				if (!hc_entry.Text.Equals (""))
					healthcard = Convert.ToInt64 (hc_entry.Text);


				string[] allEntries = new string[6];

				string name = name_entry.Text;
				allEntries [0] = name;
				string address = add_entry.Text;
				allEntries [1] = address;
				string email = email_entry.Text;
				allEntries [2] = email;
				string phone = phone_entry.Text;
				allEntries [3] = phone;
				string dateofbirth = dob_calendar.GetDate ().ToShortDateString ();
				allEntries [4] = dateofbirth;

				allEntries [5] = hc_entry.Text;

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
					comm = new SqliteCommand ("INSERT INTO clients (healthcard, name, address, email, phone, dateofbirth) " + 

					                          "values (" +  
					                          healthcard + ", '" +
					                          name + "', '" +
					                          address + "', '" +
					                          email + "', '" +
					                          phone + "', '" +
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
				                                          ex.ToString().Substring(0, 50));
				dialog.Run ();
				dialog.Destroy ();

				Console.WriteLine (ex.ToString());
			}
		}
	}
}

