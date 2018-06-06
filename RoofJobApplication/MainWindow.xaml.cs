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
using System.Drawing;
using Microsoft.Win32;

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
		//Let filepath notate the file to save or open
		const string _filePath = "RoofJobs.xml";

		// Create XmlTextWriter object.
		private XmlTextWriter _xmlWriter = new XmlTextWriter(_filePath, null);
		
		// Declare instance variables for inputs.
		private string _cName, _cAddress, _cCity, _cState, _cZip, _cEstimate, _cWorkDesc;
		
		//Close the writer button
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Close writer.
			_xmlWriter.Close();
		}

		private void xmlWriter()
		{
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
		}
		
		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			//Gather Data From Form
			_cName = txtCustName.Text;
			_cAddress = txtCustAddress.Text;
			_cCity = txtCustCity.Text;
			_cState = txtCustZip.Text;
			_cZip = txtCustZip.Text;
			_cEstimate = txtRepairEstimate.Text;
			_cWorkDesc = txtWorkDescription.Text;
			//Set the format for XML File
			_xmlWriter.Formatting = Formatting.Indented;
			_xmlWriter.IndentChar = ' ';

			// Write start element for root.
			_xmlWriter.WriteStartElement(_filePath);

			//xmlWriter(_cName, _cAddress, _cCity, _cState, _cZip, _cEstimate, _cWorkDesc);
			xmlWriter();

		}


	}
}