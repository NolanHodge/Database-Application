using System;
using System.Data;
using Gtk;
using Mono.Data.Sqlite;
using System.IO;
using System.Windows;

namespace DatabaseApplication
{
	public partial class MainWindow: Gtk.Window
	{	
		SqliteConnection conn = new SqliteConnection ("Data Source=pharmahodge.db;Version=3;");
		SqliteCommand command = null;
		private int remove;
		string[] rowSelectedArgs = new string[10];

		// Create columns once to be added to tree view on button clicks
		TreeViewColumn tv_healthcard = new TreeViewColumn ();
		TreeViewColumn tv_name = new TreeViewColumn ();
		TreeViewColumn tv_address = new TreeViewColumn ();
		TreeViewColumn tv_email = new TreeViewColumn ();
		TreeViewColumn tv_phone = new TreeViewColumn ();
		TreeViewColumn tv_dateofbirth = new TreeViewColumn ();
		TreeViewColumn tv_sin = new TreeViewColumn ();
		TreeViewColumn tv_salary = new TreeViewColumn ();
		TreeViewColumn tv_supersin = new TreeViewColumn ();
		TreeViewColumn tv_dosage = new TreeViewColumn ();
		TreeViewColumn tv_classification = new TreeViewColumn ();
		TreeViewColumn tv_type = new TreeViewColumn ();
		TreeViewColumn tv_pid = new TreeViewColumn ();
		TreeViewColumn tv_expires = new TreeViewColumn ();
		TreeViewColumn tv_prescribed = new TreeViewColumn ();
		TreeViewColumn tv_instructions = new TreeViewColumn ();

		CellRendererText healthcardCell = new Gtk.CellRendererText ();
		CellRendererText nameCell = new Gtk.CellRendererText ();
		CellRendererText addressCell = new Gtk.CellRendererText ();
		CellRendererText emailCell = new Gtk.CellRendererText ();
		CellRendererText phoneCell = new Gtk.CellRendererText ();
		CellRendererText dobCell = new Gtk.CellRendererText ();
		CellRendererText sinCell = new Gtk.CellRendererText ();
		CellRendererText salaryCell = new Gtk.CellRendererText ();
		CellRendererText supersinCell = new Gtk.CellRendererText ();
		CellRendererText dosageCell = new Gtk.CellRendererText ();
		CellRendererText classificationCell = new Gtk.CellRendererText ();
		CellRendererText typeCell = new Gtk.CellRendererText ();
		CellRendererText pidCell = new Gtk.CellRendererText ();
		CellRendererText expiresCell = new Gtk.CellRendererText ();
		CellRendererText prescribedCell = new Gtk.CellRendererText ();
		CellRendererText instructionsCell = new Gtk.CellRendererText ();
		
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{

			tv_healthcard.Title = "Healthcard";
			tv_healthcard.PackStart  (healthcardCell, true);

			tv_name.Title = "Name";
			tv_name.PackStart        (nameCell, true);

			tv_address.Title = "Address";
			tv_address.PackStart     (addressCell, true);

			tv_email.Title = "Email";
			tv_email.PackStart       (emailCell, true);

			tv_phone.Title = "Phone";
			tv_phone.PackStart       (phoneCell, true);

			tv_dateofbirth.Title = "Date of birth";
			tv_dateofbirth.PackStart (dobCell, true);

			tv_sin.Title = "SIN";
			tv_sin.PackStart       (sinCell, true);

			tv_salary.Title = "Salary";
			tv_salary.PackStart       (salaryCell, true);

			tv_supersin.Title = "Supervisor";
			tv_supersin.PackStart       (supersinCell, true);

			tv_dosage.Title = "Dosage";
			tv_dosage.PackStart       (dosageCell, true);

			tv_classification.Title = "Classification";
			tv_classification.PackStart       (classificationCell, true);

			tv_type.Title = "Type";
			tv_type.PackStart       (typeCell, true);

			tv_pid.Title = "PID";
			tv_pid.PackStart       (pidCell, true);

			tv_expires.Title = "Expires On:";
			tv_expires.PackStart       (expiresCell, true);

			tv_prescribed.Title = "Prescribed On:";
			tv_prescribed.PackStart       (prescribedCell, true);

			tv_instructions.Title = "Instructions";
			tv_instructions.PackStart       (instructionsCell, true);

			try { conn.Open (); Console.WriteLine("Succesfully connected to database");} 
			catch (SqliteException se) {Console.WriteLine (se.ToString ());}
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			conn.Close ();
			Application.Quit ();
			a.RetVal = true;
		}

		protected void ViewRow (object o, RowActivatedArgs args)
		{
			try
			{
				var model = ListView.Model;
				TreeIter iter;
				model.GetIter (out iter, args.Path);

				int i = 0;
				var value = model.GetValue (iter, 0);

				while (value != null) 
				{
				  rowSelectedArgs [i] = value.ToString ();
				  i++;
				  value = model.GetValue (iter, i);
				}

				selectViewWindow();
			}
			catch (Exception ex) 
			{
				Console.WriteLine (ex.ToString());
			}
		}

		public void selectViewWindow()
		{
			if (SearchBar.Text.StartsWith ("C")) {
				ViewClientWindow vcw = new ViewClientWindow ();
				vcw.fillStringArray (rowSelectedArgs);
				vcw.buildThis ();
			} 

			else if(SearchBar.Text.StartsWith ("Ph"))
			{
				ViewPharmacistWindow vpw = new ViewPharmacistWindow ();
				vpw.fillStringArray (rowSelectedArgs);
				vpw.buildThis ();
			}
			else if(SearchBar.Text.StartsWith ("M"))
			{
				ViewMedicineWindow vmw = new ViewMedicineWindow ();
				vmw.fillStringArray (rowSelectedArgs);
				vmw.buildThis ();
			}
			else if(SearchBar.Text.StartsWith ("Pr"))
			{
				ViewPrescriptionWindow vpw = new ViewPrescriptionWindow ();
				vpw.fillStringArray (rowSelectedArgs);
				vpw.buildThis ();
			}
			else
			{
				
				MessageDialog dialog = new MessageDialog (null,
				                                          DialogFlags.Modal,
				                                          MessageType.Error, 
				                                          ButtonsType.Ok,
				                                          "Cannot view this information");
				dialog.Run ();
				dialog.Destroy ();
			}


		}
		
		protected void ClientClick (object sender, EventArgs e)
		{

			SearchBar.Text = "Client: ";

			searchClients ("*");
		}

		protected void PharmClick (object sender, EventArgs e)
		{
			SearchBar.Text = "Pharmacist: ";

			searchPharmacists ("*");
		}

		protected void MedClick (object sender, EventArgs e)
		{
			SearchBar.Text = "Medicine: ";

			searchMedicine ("*");
		}

		protected void PrescripClick (object sender, EventArgs e)
		{
			SearchBar.Text = "Prescription: ";

			searchPrescriptions ("*");
		}

		public void searchClients(string query)
		{
			remove = removeAllColumns;

			ListView.AppendColumn (tv_healthcard);
			ListView.AppendColumn (tv_name);
			ListView.AppendColumn (tv_address);
			ListView.AppendColumn (tv_email);
			ListView.AppendColumn (tv_phone);
			ListView.AppendColumn (tv_dateofbirth);

			try
			{
				clearAllAttributes();

				if (query.Equals("*"))
				{
				    command = new SqliteCommand ("SELECT * from clients;", conn);
				}
				else
				{
					command = new SqliteCommand("SELECT * from clients where name like '%" + query + "%';", conn);
				}

				SqliteDataReader reader = command.ExecuteReader ();

				tv_healthcard.AddAttribute  (healthcardCell, "text", 0);
				tv_name.AddAttribute        (nameCell,       "text", 1);
				tv_address.AddAttribute     (addressCell,    "text", 2);
				tv_email.AddAttribute       (emailCell,      "text", 3);
				tv_phone.AddAttribute       (phoneCell,      "text", 4);
				tv_dateofbirth.AddAttribute (dobCell,        "text", 5);



				ListStore client = new Gtk.ListStore (typeof (string), typeof (string), 
				                                      typeof (string), typeof (string), 
				                                      typeof (string), typeof (string), typeof(string));

				while (reader.Read())
				{
					client.AppendValues (reader[0], reader[1],  reader[2],  reader[3],  reader[4], 
					                     Convert.ToDateTime(reader[5]).ToShortDateString());
				}

				ListView.Model = client;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void searchPharmacists(string query)
		{
			remove = removeAllColumns;

			ListView.AppendColumn (tv_sin);
			ListView.AppendColumn (tv_name);
			ListView.AppendColumn (tv_address);
			ListView.AppendColumn (tv_email);
			ListView.AppendColumn (tv_phone);
			ListView.AppendColumn (tv_dateofbirth);
			ListView.AppendColumn (tv_salary);
			ListView.AppendColumn (tv_supersin);

			try
			{
				if (query.Equals("*"))
				{
					command = new SqliteCommand ("SELECT * from pharmacists;", conn);
				}
				else
				{
					command = new SqliteCommand("SELECT * from pharmacists where name like '%" + query + "%';", conn);
				}
				SqliteDataReader reader = command.ExecuteReader ();
		
				clearAllAttributes();

				tv_sin.AddAttribute         (sinCell,           "text", 0);
				tv_name.AddAttribute        (nameCell,          "text", 1);
				tv_address.AddAttribute     (addressCell,       "text", 2);
				tv_email.AddAttribute       (emailCell,         "text", 3);
				tv_phone.AddAttribute       (phoneCell,         "text", 4);
				tv_dateofbirth.AddAttribute (dobCell,           "text", 5);
				tv_salary.AddAttribute      (salaryCell,        "text", 6);
				tv_supersin.AddAttribute    (supersinCell,      "text", 7);



				ListStore pharmacist = new Gtk.ListStore (typeof (string), typeof (string), 
				                                          typeof (string), typeof (string), 
				                                          typeof (string), typeof (string), 
				                                          typeof(string),  typeof(string));

				while (reader.Read())
				{
					pharmacist.AppendValues (reader[0], reader[1],  reader[2],  reader[3],  reader[4],
					                         Convert.ToDateTime(reader[7]).ToShortDateString(), reader[5], reader[6]);
				}

				ListView.Model = pharmacist;

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void searchMedicine(string query)
		{
			remove = removeAllColumns;

			ListView.AppendColumn (tv_name);
			ListView.AppendColumn (tv_dosage);
			ListView.AppendColumn (tv_classification);
			ListView.AppendColumn (tv_type);

			try
			{
				if (query.Equals("*"))
				{
					command = new SqliteCommand ("SELECT * from medicine;", conn);
				}
				else
				{
					command = new SqliteCommand("SELECT * from medicine where name like '%" + query + "%';", conn);
				}
				SqliteDataReader reader = command.ExecuteReader ();

				clearAllAttributes();

				tv_name.AddAttribute              (nameCell,             "text", 0);
				tv_dosage.AddAttribute            (dosageCell,           "text", 1);
				tv_classification.AddAttribute    (classificationCell,   "text", 2);
				tv_type.AddAttribute              (typeCell ,            "text", 3);



				ListStore medicine = new Gtk.ListStore (typeof (string), typeof (string), 
				                                          typeof (string), typeof (string));


				while (reader.Read())
				{
					medicine.AppendValues (reader[0], reader[1],  reader[2],  reader[3]);
				}

				ListView.Model = medicine;

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void searchPrescriptions(string query)
		{
			remove = removeAllColumns;

			ListView.AppendColumn (tv_pid);
			ListView.AppendColumn (tv_expires);
			ListView.AppendColumn (tv_prescribed);
			ListView.AppendColumn (tv_instructions);
			ListView.AppendColumn (tv_sin);
			ListView.AppendColumn (tv_name);
			ListView.AppendColumn (tv_dosage);
			ListView.AppendColumn (tv_healthcard);

			try
			{
				if (query.Equals("*"))
				{
					command = new SqliteCommand ("SELECT * from prescriptions;", conn);
				}
				else
				{
					command = new SqliteCommand("SELECT * from prescriptions where name like '%" + query + "%';", conn);
				}

				SqliteDataReader reader = command.ExecuteReader ();

				clearAllAttributes();

				tv_pid.AddAttribute            (pidCell,           "text", 0);
				tv_expires.AddAttribute        (expiresCell,       "text", 1);
				tv_prescribed.AddAttribute     (prescribedCell,    "text", 2);
				tv_instructions.AddAttribute   (instructionsCell,  "text", 3);
				tv_sin.AddAttribute            (sinCell,           "text", 4);
				tv_name.AddAttribute           (nameCell,          "text", 5);
				tv_dosage.AddAttribute         (dosageCell,        "text", 6);
				tv_healthcard.AddAttribute     (healthcardCell,    "text", 7);

				ListStore prescription = new Gtk.ListStore (typeof (string), typeof (string), 
				                                          typeof (string), typeof (string), 
				                                          typeof (string), typeof (string), 
				                                          typeof(string),  typeof(string));

				while (reader.Read())
				{
					prescription.AppendValues (reader[0], Convert.ToDateTime(reader[1]).ToShortDateString(),
					                           Convert.ToDateTime(reader[2]).ToShortDateString(), reader[3], 
					                           reader[4], reader[5], reader[6], reader[7]);
				}

				ListView.Model = prescription;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private int removeAllColumns
		{
	        get
			{
			   foreach (TreeViewColumn tvc in ListView.Columns)
			   {
			    	ListView.RemoveColumn (tvc);
			   }

			   return 1;
			}
		}

		protected void newClient (object sender, EventArgs e)
		{
		
			AddClientWindow acw = new AddClientWindow ();
		}

		protected void newPharm (object sender, EventArgs e)
		{
			AddPharmWindow apw = new AddPharmWindow ();
		}

		protected void newMed (object sender, EventArgs e)
		{
			AddMedicineWindow amw = new AddMedicineWindow ();
		}

		protected void newPres (object sender, EventArgs e)
		{
			AddPrescriptionWindow apw = new AddPrescriptionWindow ();
		}

		protected void SearchTree (object sender, EventArgs e)
		{
			// Get the query string and deficer which table to search

			// Return empty string, no search
			if (SearchBar.Text.Equals (""))
				return;

			if (!SearchBar.Text.EndsWith (" "))
				SearchBar.Text += " ";

			// Neccessary variables for search terms
			char[] splitBy = {' '};
			string query = SearchBar.Text;
			string[] queryBy = SearchBar.Text.Split (splitBy);
			string name = "*";

			// Get the first name to search for
			if (queryBy.Length < 5)
			{
				if (!queryBy[1].Equals(""))
				  name = queryBy[1];
				else
					return;
			}

			// Guarentees we have a firstname+lastname search
			if (queryBy.Length == 4)
			{
				if (!queryBy[2].Equals(""))
					name += " " + queryBy[2];
				else
					return;
			}

			if (query.StartsWith ("Ph")) {
				searchPharmacists (name);
			}
			if (query.StartsWith ("C")) {
				searchClients (name);
			}
			if (query.StartsWith ("M")) {
				searchMedicine (name);
			}
			if (query.StartsWith ("Pr")) {
				Console.WriteLine("Pres");
				searchPrescriptions (name);
			}

		}

		protected void clearAllAttributes()
		{
			tv_healthcard.ClearAttributes (healthcardCell);
			tv_sin.ClearAttributes(sinCell);
			tv_name.ClearAttributes(nameCell);
			tv_address.ClearAttributes(addressCell);
			tv_email.ClearAttributes(emailCell);
			tv_phone.ClearAttributes(phoneCell);
			tv_dateofbirth.ClearAttributes(dobCell);
			tv_salary.ClearAttributes(salaryCell);
			tv_supersin.ClearAttributes(supersinCell);
			tv_dosage.ClearAttributes (dosageCell);
			tv_classification.ClearAttributes (classificationCell);
			tv_type.ClearAttributes (typeCell);
			tv_expires.ClearAttributes (expiresCell);
			tv_prescribed.ClearAttributes (prescribedCell);
			tv_pid.ClearAttributes (pidCell);
			tv_instructions.ClearAttributes (instructionsCell);
		}

		public TreeView getList()
		{
			return this.ListView;
		}

		public string getSearchBar
		{
			get
			{
				return SearchBar.Text;
			}
		}

		public void buildThis()
		{
			Build ();
		}

		protected void OnOpen (object sender, EventArgs e)
		{
		}

		protected void OnClose (object sender, EventArgs e)
		{
		}
		protected void OnExit (object sender, EventArgs e)
		{
		}


	}
}