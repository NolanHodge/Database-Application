using System;
using Mono.Data.Sqlite;
using Gtk;

namespace DatabaseApplication
{
	public partial class ViewPrescriptionWindow : Gtk.Window
	{
		string[] rowSelectedArgs = new string[10];
		char[] splitDateTime = {'-'};

		public void fillStringArray(string[] array)
		{
			int i = 0;
			foreach (string s in array) 
			{
				rowSelectedArgs [i] = s;
				i++;
			}
		}

		public ViewPrescriptionWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
		}

		public void buildThis()
		{
			this.Build ();

			pid_entry.Text = rowSelectedArgs [0];
			notes_entry.Text = rowSelectedArgs[3];
			pharm_entry.Text = rowSelectedArgs [4];
			name_entry.Text = rowSelectedArgs [5];
			dosage_entry.Text = rowSelectedArgs [6];
			client_entry.Text = rowSelectedArgs [7];


			string[] dateSplit_expires = rowSelectedArgs [1].Split (splitDateTime);
			string year_e = dateSplit_expires [0];
			string month_e = dateSplit_expires [1];
			string day_e = dateSplit_expires [2];

			string[] dateSplit_prescribed = rowSelectedArgs [2].Split (splitDateTime);
			string year_p = dateSplit_prescribed [0];
			string month_p = dateSplit_prescribed [1];
			string day_p = dateSplit_prescribed [2];

			expires_cal.Year = Convert.ToInt32(year_e);
			expires_cal.Month = Convert.ToInt32(month_e);
			expires_cal.Day = Convert.ToInt32(day_e);

			prescribed_cal.Year = Convert.ToInt32(year_p);
			prescribed_cal.Month = Convert.ToInt32(month_p);
			prescribed_cal.Day = Convert.ToInt32(day_p);
		}

		protected void UpdatePrescription (object sender, EventArgs e)
		{
			bool check = true;

			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();

			long pid = 0;
			long sin = 0;
			long healthcard = 0;

			if (!pharm_entry.Text.Equals (""))
				sin = Convert.ToInt64 (pharm_entry.Text);

			if (!client_entry.Text.Equals (""))
				healthcard = Convert.ToInt64 (client_entry.Text);

			if (!pid_entry.Text.Equals (""))
				pid = Convert.ToInt64 (pid_entry.Text);

			string[] allEntries = new string[5];

			string name = name_entry.Text;
			allEntries [0] = name;
			string dosage = dosage_entry.Text;
			allEntries[1] = dosage;
			string notes = notes_entry.Text;
			allEntries[2] = notes;
			string prescribed = prescribed_cal.GetDate().ToShortDateString();
			allEntries[3] = prescribed;
			string expires = expires_cal.GetDate().ToShortDateString();
			allEntries[4] = expires;

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
				comm = new SqliteCommand ("UPDATE prescriptions SET " +
				                          "name = '" + name + "', " +
				                          "dosage = '" + dosage + "', " +
				                          "instructions = '" + notes + "', " +
				                          "prescribed = '" + prescribed + "', " +
				                          "expires = '" + expires + "'  where pid = " + pid + ";", conn); 

				comm.ExecuteNonQuery();

				this.Destroy();
			}
			else
			{
				conn.Close();
			}

		}

		protected void DeletePrescription (object sender, EventArgs e)
		{
			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();

			long pid = 0;

			if (!pid_entry.Text.Equals (""))
				pid = Convert.ToInt64 (pid_entry.Text);

			comm = new SqliteCommand ("DELETE FROM prescriptions "
			                          + " where pid = " + pid + ";", conn); 

			comm.ExecuteNonQuery();

			this.Destroy();

		}

		public string getEntryError(int i)
		{
			switch (i) 
			{
				case 1:
				return "PID";
				case 2:
				return "Instructions";
			    case 3:
				return "Name";
			    case 4:
				return "dosage";
				default:
				return "Unknown Entry Column";
			}
		}
	}
}

