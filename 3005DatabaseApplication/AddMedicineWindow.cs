using System;
using Gtk;
using Mono.Data.Sqlite;

namespace DatabaseApplication
{
	public partial class AddMedicineWindow : Gtk.Window
	{
		SqliteCommand comm = null;

		public AddMedicineWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void CreateMedicine (object sender, EventArgs e)
		{
			try {
				bool check = true;
				SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
				conn.Open();

				string[] allEntries = new string[4];

				string name = name_entry.Text;
				allEntries [0] = name;
				string class_e = class_entry.Text;
				allEntries [1] = class_e;
				string dosage = dosage_entry.Text;
				allEntries [2] = dosage;
				string type = type_entry.Text;
				allEntries [3] = type;



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
					comm = new SqliteCommand ("INSERT INTO medicine (name, dosage, classification, type) " + 

					                          "values ( '" +  
					                          name + "', '" +
					                          dosage + "', '" +
					                          class_e + "', '" +
					                          type + "' " +
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
			}		}
		}
	}


