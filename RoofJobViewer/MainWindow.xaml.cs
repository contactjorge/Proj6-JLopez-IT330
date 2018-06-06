using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.Win32;

namespace RoofJobViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		//Let filepath notate the file to save or open
		const string _filePath = "RoofJobs.xml";

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (openFileDialog.ShowDialog() == true)
			{
				string fileName = File.ReadAllText(openFileDialog.FileName);
			}
			
		}

		private void btnDisplay_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (openFileDialog.ShowDialog() == true)
			{
				string fileName = File.ReadAllText(openFileDialog.FileName);
			}

			List<RoofJob> roofjobs = new List<RoofJob>();
			MemoryStream stream = null;
			try
				{
					//give the data we have in meory to the XMLTextReader
					XmlTextReader r = new XmlTextReader(stream);


					RoofJob newRoofJob = null;
					string lastElementName = "";
					while (r.Read())
					{
						switch (r.NodeType)
						{
							case XmlNodeType.Element:
								if (r.Name == "CustomerName")
								{
									newRoofJob = new RoofJob();
								}
								else if (r.Name == "CustomerAddress" || r.Name == "CustomerCity" ||
										 r.Name == "CustomerState" || r.Name == "CustomerState" ||
										 r.Name == "RepairEstimate" || r.Name == "WorkDescription"
										 )
								{
									lastElementName = r.Name;
								}
								break;

							case XmlNodeType.Text:
								switch (lastElementName)
								{
									case ("CustomerAddress"): newRoofJob.CustomerAddress = r.Value; break;
									case ("CustomerCity"): newRoofJob.CustomerCity = r.Value; break;
									case ("CustomerState"): newRoofJob.CustomerState = r.Value; break;
									case ("CustomerZip"): newRoofJob.CustomerCity = r.Value; break;
									case ("RepairEstimate"): newRoofJob.CustomerCity = r.Value; break;
									case ("WorkDescription"): newRoofJob.WorkDescription = r.Value; break;
								}
								break;

							case XmlNodeType.EndElement:
								if (r.Name == "CustomerName")
								{
									roofjobs.Add(newRoofJob);
								}
								break;
						}
					}

					//this.CreateAccounts(customers);
					//Store the objects in a cache. We will cover session next week.
					//Session["customerList"] = customers;

					foreach (RoofJob rj in roofjobs)
					{
						TableRow row = new TableRow();
						row.Cells.Add(new TableCell { Text = rj.FirstName });
						row.Cells.Add(new TableCell { Text = rj.LastName });
						row.Cells.Add(new TableCell { Text = rj.Gender });
						row.Cells.Add(new TableCell { Text = rj.Age.ToString() });
						row.Cells.Add(new TableCell { Text = rj.UserName });
						tblUsers.Rows.Add(row);
					}
					//Set upload panel invisible
					//pnlUpload.Visible = false;
					//Set download panel to visible
					//pnlConfirm.Visible = true;

				}
				catch (Exception)
				{
					lblError.Content = "An error occured. Please try again.";
				}
				finally
				{ stream.Close(); }

			}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	
	}
}
