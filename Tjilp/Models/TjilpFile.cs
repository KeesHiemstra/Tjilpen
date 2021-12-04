using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjilp.Models
{
	internal class TjilpFile
	{
		public ObservableCollection<TjilpRecord> Tjilps { get; set; } = 
			new ObservableCollection<TjilpRecord>();
		public string[] Subjects { get; set; }
	}
}
