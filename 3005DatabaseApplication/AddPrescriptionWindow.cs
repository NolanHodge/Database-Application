using System;
using Gtk;
using Mono.Data.Sqlite;

namespace DatabaseApplication
{
	public partial class AddPrescriptionWindow : Gtk.Window
	{
		SqliteCommand comm = null;

		public AddPrescriptionWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void CreatePrescription (object sender, EventArgs e)
		{
			bool check = true;

			try {
				SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
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
					comm = new SqliteCommand ("INSERT INTO prescriptions (pid, expires, prescribed, instructions, pharm, name, dosage, client) " + 

					                          "values (" +  
					                          pid + ", '" +
					                          expires + "', '" +
					                          prescribed + "', '" +
					                          notes + "', " +
					                          sin + ", '" +
					                          name + "', '" +
					                          dosage + "', " +
					                          healthcard + " " +
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


