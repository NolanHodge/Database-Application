using System;
using Gtk;
using Mono.Data.Sqlite;

namespace DatabaseApplication
{
	public partial class ViewMedicineWindow : Gtk.Window
	{
		string[] rowSelectedArgs = new string[10];

		public ViewMedicineWindow () : 
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

			name_entry.Text = rowSelectedArgs [0];
			dosage_entry.Text = rowSelectedArgs [1];
			class_entry.Text = rowSelectedArgs [2];
			type_entry.Text = rowSelectedArgs [3];
		}

		public string getEntryError(int i)
		{
			switch (i) 
			{
				case 1:
				return "Name";
				case 2:
				return "Class";
				case 3:
				return "Dosage";
				case 4:
				return "Type";
				default:
				return "Unknown Entry Column";
			}
		}

		protected void UpdateMedication (object sender, EventArgs e)
		{
			bool check = true;
			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();

			string[] allEntries = new string[4];

			string name = name_entry.Text;
			allEntries [0] = name;
			string dosage = dosage_entry.Text;
			allEntries [1] = dosage;
			string class_e = class_entry.Text;
			allEntries [2] = class_e;
			string type = type_entry.Text;
			allEntries [3] = type;

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

				comm = new SqliteCommand ("UPDATE medicine SET " +
				                          "classification = '" + class_e + "', " +
				                          "type = '" + type + "' " +
				                          " where name = '" + name +"' and dosage = '" + dosage + "' ;", conn); 

				comm.ExecuteNonQuery();

				this.Destroy();
			}
			else
			{
				conn.Close();
			}
		}

		protected void DeleteMedication (object sender, EventArgs e)
		{
			SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
			SqliteCommand comm;
			conn.Open();


			string name = name_entry.Text;
			string dosage = dosage_entry.Text;

			comm = new SqliteCommand ("DELETE from medicine  " +
			                          "  WHERE name = '" + name + "' and dosage = '" + dosage+ "' ;", conn); 

			comm.ExecuteNonQuery();

			this.Destroy();		}
	}
}

