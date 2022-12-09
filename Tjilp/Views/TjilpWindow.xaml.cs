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
		private readonly bool newRecord = false;

		internal MainViewModel VM { get; set; }
		internal TjilpRecord Tjilp { get; set; }

		internal TjilpWindow(MainViewModel vm, TjilpRecord tjilp)
		{
			VM = vm;
			Tjilp = tjilp;
			if (Tjilp == null)
			{
				newRecord = true;
				Tjilp = new TjilpRecord();
			}

			InitializeComponent();

			DataContext = Tjilp;
			MessageTextBox.Focus();
		}

		#region Menu TjilpCommands

		#region SaveAndClose command

		private void SaveAndCloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void SaveAndCloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			if (newRecord)
			{
				VM.Tjilps.Tjilps.Add(Tjilp.Update());
			}
			else
			{
				Tjilp.Update();
			}
			Close();
		}

		#endregion

		#region Close command

		private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void CloseCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			Close();
		}

		#endregion

		#endregion

		private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Tjilp.IsUpdated = true;
		}
	}
}
