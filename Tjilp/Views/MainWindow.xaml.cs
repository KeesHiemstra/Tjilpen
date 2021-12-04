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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Tjilp.ModelViews;

namespace Tjilp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		internal MainViewModel VM { get; set; }

		public MainWindow()
		{
			VM = new MainViewModel(this);

			InitializeComponent();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			VM.SaveTjilps();
		}
	}
}
