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
			//Open a stream to APPEND to the file
			StreamWriter writer = new StreamWriter(_filePath, true);

			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (openFileDialog.ShowDialog() == true)
			{
				txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
			}
				
		}
	}
}
