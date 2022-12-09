using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Tjilp.Extentions;
using Tjilp.Models;
using Tjilp.Views;

namespace Tjilp.ModelViews
{
	internal partial class MainViewModel
	{
		private readonly MainWindow View;
		private string TjilpJsonFile = @"%OneDrive%\Data\Tjilpen.json";

		public TjilpFile Tjilps { get; set; }

		public MainViewModel(MainWindow view)
		{
			View = view;
			Tjilps = new TjilpFile();
			View.DataContext = this;

			LoadTjilps();
		}

		public void LoadTjilps()
		{
			Tjilps.Tjilps.Clear();
			string jsonPath = TjilpJsonFile.TranslatePath(); 
			if (File.Exists(jsonPath))
			{
				using (StreamReader stream = File.OpenText(jsonPath))
				{
					string json = stream.ReadToEnd();
					Tjilps = JsonConvert.DeserializeObject<TjilpFile>(json);
				}
				Tjilps.UpdateLastId();
			}
		}

		public void SaveTjilps()
		{
			//Save the LastID in the record
			Tjilps.UpdateLastId();
			string jsonPath = TjilpJsonFile.TranslatePath();
			string json = JsonConvert.SerializeObject(Tjilps, Formatting.Indented);
			using (StreamWriter stream = new StreamWriter(jsonPath))
			{
				stream.Write(json);
			}
		}

		internal void OpenTjilp(TjilpRecord tjilp)
		{
			TjilpWindow window = new TjilpWindow(this, tjilp);
			window.Show();
		}

		internal void OpenTest()
		{
			TjilpRecord tjilp = Tjilps.Tjilps[0];
			TjilpWindow window = new TjilpWindow(this, tjilp);
			window.Show();
		}

	}
}
