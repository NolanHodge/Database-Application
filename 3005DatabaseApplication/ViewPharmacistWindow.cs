using System;
using Gtk;
using Mono.Data.Sqlite;

namespace DatabaseApplication
{
	public partial class ViewPharmacistWindow : Gtk.Window
	{
		string[] rowSelectedArgs = new string[10];
		char[] splitDateTime = {'-'};

		public ViewPharmacistWindow () : 
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

			sin_entry.Text = rowSelectedArgs [0];
			name_entry.Text = rowSelectedArgs [1];
			add_entry.Text = rowSelectedArgs [2];
			email_entry.Text = rowSelectedArgs [3];
			phone_entry.Text = rowSelectedArgs [4];

			sal_entry.Text = rowSelectedArgs [6];
			super_entry.Text = rowSelectedArgs [7];

			string[] dateSplit = rowSelectedArgs [5].Split (splitDateTime);
			string year = dateSplit [0];
			string month = dateSplit [1];
			string day = dateSplit [2];

			dob_cal.Year = Convert.ToInt32(year);
			dob_cal.Month = Convert.ToInt32(month);
			dob_cal.Day = Convert.ToInt32(day);
		}

		protected void UpdatePharmacist (object sender, EventArgs e)
		{
			bool check = true;

			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();
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
			string dateofbirth = dob_cal.GetDate ().ToShortDateString ();
			allEntries [4] = dateofbirth;

			allEntries [5] = sin_entry.Text;
			allEntries [6] = super_entry.Text;
			allEntries [7] = sal_entry.Text;

			int i = 0;
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
				comm = new SqliteCommand ("UPDATE pharmacists SET " +
				                          "name = '" + name + "', " +
				                          "address = '" + address + "', " +
				                          "email = '" + email + "', " +
				                          "phone = '" + phone + "', " +
				                          "salary = " + salary + ", " +
				                          "dateofbirth = '" + dateofbirth + "'  where sin = " + sin + ";", conn); 

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
				case 0:
				return "Name";
				case 1:
				return "Address";
				case 2:
				return "Email";
				case 3:
				return "Phone";
				case 4:
				return "Date of birth";
				case 7:
				return "Salary";
				default:
				return "Unknown Entry Column";
			}
		}

		protected void DeletePharmacist (object sender, EventArgs e)
		{
			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();

			long sin = 0;

			if (!sin_entry.Text.Equals (""))
				sin = Convert.ToInt64 (sin_entry.Text);

			comm = new SqliteCommand ("DELETE from pharmacists  " +
			                          "  WHERE sin = " + sin + ";", conn); 

			comm.ExecuteNonQuery();

			this.Destroy();
		}
	}
}

