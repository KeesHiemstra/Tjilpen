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
		public int LastId { get; set; }

		public TjilpFile()
		{

		}

		public void UpdateLastId()
		{
			int lastId = Tjilps.Max(x => x.Id);
			if (lastId > LastId)
			{
				LastId = lastId;
			}
			TjilpRecord.UpdateLastId(LastId);
		}
	}
}
