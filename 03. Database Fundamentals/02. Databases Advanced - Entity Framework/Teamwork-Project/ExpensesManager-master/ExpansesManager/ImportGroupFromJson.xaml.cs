using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Data;
using Data.Errors;
using Models.DTOs;
using Models.Models;
using Newtonsoft.Json;

namespace ExpansesManager
{
	/// <summary>
	/// Interaction logic for ImportGroupFromJson.xaml
	/// </summary>
	public partial class ImportGroupFromJson : Window
	{
		private string pathOfFile;

		public ImportGroupFromJson()
		{
			InitializeComponent();
		}

		private void button_Import(object sender, RoutedEventArgs e)
		{

			if (!File.Exists(pathOfFile))
			{
				throw new FileNotFoundException(string.Format(Checks.ErrorMessages.FileNotFound, pathOfFile));
			}

			var context = new ExpansesManagerContext();
			var json = File.ReadAllText(pathOfFile);
			var groups = JsonConvert.DeserializeObject<IEnumerable<GroupDto>>(json);

			
		}


		private void button_Open(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



			// Set filter for file extension and default file extension 
			dlg.DefaultExt = ".json";
			dlg.Filter = "JPEG Files (*.json)|*.json";


			// Display OpenFileDialog by calling ShowDialog method 
			Nullable<bool> result = dlg.ShowDialog();


			// Get the selected file name and display in a TextBox 
			if (result == true)
			{
				// Open document 
				string filename = dlg.SafeFileName;
				//var 
				pathOfFile = dlg.FileName;
				MessageLabel.Content = ($"Selected file {filename}");
			}

		}




		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
		
			this.Close();
			
		}
	}
}
