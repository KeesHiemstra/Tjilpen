using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tjilp.Extentions;
using Tjilp.Models;

namespace Tjilp.ModelViews
{
	internal class MainViewModel
	{
		private readonly MainWindow View;
		private string TjilpJsonFile = @"%OneDrive%\Data\Tjilpen.json";

		public TjilpFile Tjilps { get; set; } = new TjilpFile();

		public MainViewModel(MainWindow view)
		{
			View = view;
		}

		public void LoadTjilps()
		{
			Tjilps.Tjilps.Clear();
			string jsonPath = TjilpJsonFile.TranslatePath(); 
			using (StreamReader stream = File.OpenText(jsonPath))
			{
				string json = stream.ReadToEnd();
				Tjilps = JsonConvert.DeserializeObject<TjilpFile>(jsonPath);
			}
		}

		public void SaveTjilps()
		{
			string jsonPath = TjilpJsonFile.TranslatePath();
			string json = JsonConvert.SerializeObject(Tjilps, Formatting.Indented);
			using (StreamWriter stream = new StreamWriter(jsonPath))
			{
				stream.Write(json);
			}

		}

	}
}
