using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using Tjilp.Models;
using Tjilp.ModelViews;

namespace Tjilp.Views
{
	/// <summary>
	/// Interaction logic for TjilpWindow.xaml
	/// </summary>
	public partial class TjilpWindow : Window
	{
		private bool newRecord = false;

		internal MainViewModel VM { get; set; }
		internal TjilpRecord TjilpRecord { get; set; }

		internal TjilpWindow(MainViewModel vm, TjilpRecord tjilpRecord)
		{
			VM = vm;
			TjilpRecord = tjilpRecord;
			if (TjilpRecord == null)
			{
				newRecord = true;
				TjilpRecord = new TjilpRecord();
			}

			InitializeComponent();

			DataContext = this;
		}

		private void SaveAndCloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = !string.IsNullOrEmpty(TjilpRecord.Message);
		}

		private void SaveAndCloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			if (newRecord)
			{
				VM.Tjilps.Tjilps.Add(TjilpRecord);
			}
			Close();
		}

		private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void CloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			Close();
		}

	}
}
