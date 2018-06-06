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

namespace RoofJobApplication
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

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			// Create XmlTextWriter object.
			XmlTextWriter w = new XmlTextWriter("RoofJob.xml", null);

			// Create StreamReader object.
			StreamReader r = new StreamReader("RoofJob.txt");

			// Declare variables for inputs.
			string cName, cAddress, cCity, cState, cZip, cEstimate, cJobDesc;
			string[] fields;
			cName = txtCustName.ToString();
			cAddress = txtCustAddress.ToString();
			cCity = txtCustCity.ToString();
			cState = txtCustZip.ToString();
			cZip = txtCustZip.ToString();
			cEstimate = txtRepairEstimate.ToString();
			cJobDesc = txtWorkDescription.ToString();
			//
			w.Formatting = Formatting.Indented;
			w.IndentChar = ' ';

			// Write start element for root.
			w.WriteStartElement("RoofJobs");

			while (r.Peek() != -1)
			{
				// Read line from input file.
				line = r.ReadLine();
				fields = line.Split(',');
				name = fields[0];
				gender = fields[1];
				age = fields[2];

				// Write Person element.
				w.WriteStartElement("RoofJob");
				w.WriteElementString("Customer Name", txtCustName);
				w.WriteElementString("Customer Address", txtCustAddress);
				w.WriteElementString("Customer City", name);
				w.WriteElementString("Customer State", name);
				w.WriteElementString("Customer Zip", gender);
				w.WriteElementString("Age", age);
				w.WriteEndElement();
			}

			// Write end element for root.
			w.WriteEndElement();

			// Close writer.
			w.Close();
		}
	}
}
