using System;
using Mono.Data.Sqlite;
using Gtk;

namespace DatabaseApplication
{
	public partial class ViewClientWindow : Gtk.Window
	{
		string[] rowSelectedArgs = new string[10];
		char[] splitDateTime = {'-'};

		public ViewClientWindow () : 
				base(Gtk.WindowType.Toplevel)
		{

		}

		public void fillStringArray(string[] array)
		{
			int i = 0;
			foreach (string s in array) 
			{
				rowSelectedArgs [i] = s;
				i++;
			}
		}

		public void buildThis()
		{
			this.Build ();

			hc_entry.Text = rowSelectedArgs [0];
			name_entry.Text = rowSelectedArgs [1];
			address_entry.Text = rowSelectedArgs [2];
			email_entry.Text = rowSelectedArgs [3];
			phone_entry.Text = rowSelectedArgs [4];

			string[] dateSplit = rowSelectedArgs [5].Split (splitDateTime);
			string year = dateSplit [0];
			string month = dateSplit [1];
			string day = dateSplit [2];

			dob_cal.Year = Convert.ToInt32(year);
			dob_cal.Month = Convert.ToInt32(month);
			dob_cal.Day = Convert.ToInt32(day);

		}

		protected void UpdateClient (object sender, EventArgs e)
		{
			bool check = true;

			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();

			long healthcard = 0;

			if (!hc_entry.Text.Equals (""))
				healthcard = Convert.ToInt64 (hc_entry.Text);

			string[] allEntries = new string[6];

			string name = name_entry.Text;
			allEntries [0] = name;
			string address = address_entry.Text;
			allEntries [1] = address;
			string email = email_entry.Text;
			allEntries [2] = email;
			string phone = phone_entry.Text;
			allEntries [3] = phone;
			string dateofbirth = dob_cal.GetDate ().ToShortDateString ();
			allEntries [4] = dateofbirth;

			allEntries [5] = hc_entry.Text;
			int i = 1;
			foreach (string s in allEntries) 
			{
				if (s.Equals ("") || s.Equals (" ")) 
				{

					MessageDialog dialog = new MessageDialog (null,
					                                          DialogFlags.Modal,
					                                          MessageType.Error, 
					                                          ButtonsType.Ok,
					                                          "ERROR with " + getEntryError(i) + " field: Cannot have empty fields! ");
					dialog.Run ();
					dialog.Destroy ();
					check = false;
					break;
				}

				i++;
			}

			if (check)
			{
				comm = new SqliteCommand ("UPDATE clients SET " +
					"name = '" + name + "', " +
					"address = '" + address + "', " +
					"email = '" + email + "', " +
					"phone = '" + phone + "', " +
					"dateofbirth = '" + dateofbirth + "'  where healthcard = " + healthcard + ";", conn); 

				comm.ExecuteNonQuery();

				this.Destroy();
			}
			else
			{
				conn.Close();
			}
		}

		public string getEntryError(int i)
		{
			switch (i) 
			{
				case 1:
					return "Name";
				case 2:
					return "Address";
				case 3:
					return "Email";
				case 4:
					return "Phone";
				case 5:
					return "Date of birth";
				default:
					return "Unknown Entry Column";
			}
		}

		protected void DeleteClient (object sender, EventArgs e)
		{
			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();

			long healthcard = 0;

			if (!hc_entry.Text.Equals (""))
				healthcard = Convert.ToInt64 (hc_entry.Text);

			comm = new SqliteCommand ("DELETE FROM clients "
			                         + " where healthcard = " + healthcard + ";", conn); 

			comm.ExecuteNonQuery();

			this.Destroy();
		}
	}
}

