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
		// Create XmlTextWriter object.
		private XmlTextWriter _xmlWriter = new XmlTextWriter("RoofJob.xml", null);
		
		// Create StreamReader object.
		//private StreamReader _xmlReader = new StreamReader("RoofJob.txt");
		
		// Declare instance variables for inputs.
		private string _cName, _cAddress, _cCity, _cState, _cZip, _cEstimate, _cWorkDesc;

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			//Gather Data From Form
			_cName = txtCustName.ToString();
			_cAddress = txtCustAddress.ToString();
			_cCity = txtCustCity.ToString();
			_cState = txtCustZip.ToString();
			_cZip = txtCustZip.ToString();
			_cEstimate = txtRepairEstimate.ToString();
			_cWorkDesc = txtWorkDescription.ToString();

			//Set the format for XML File
			_xmlWriter.Formatting = Formatting.Indented;
			_xmlWriter.IndentChar = ' ';

			// Write start element for root.
			_xmlWriter.WriteStartElement("RoofJobs");

			// Write Person element.
			_xmlWriter.WriteStartElement("RoofJob");
			_xmlWriter.WriteElementString("Customer Name", _cName);
			_xmlWriter.WriteElementString("Customer Address", _cAddress);
			_xmlWriter.WriteElementString("Customer City", _cCity);
			_xmlWriter.WriteElementString("Customer State", _cState);
			_xmlWriter.WriteElementString("Customer Zip", _cZip);
			_xmlWriter.WriteElementString("Repair Estimate", _cEstimate);
			_xmlWriter.WriteElementString("Work Description", _cWorkDesc);
			_xmlWriter.WriteEndElement();

			// Write end element for root.
			_xmlWriter.WriteEndElement();

			// Close writer.
			_xmlWriter.Close();
		}
	}
}