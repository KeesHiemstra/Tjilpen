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

using Tjilp.Models;
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

			DataContext = VM;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			ShowTjilps();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			VM.SaveTjilps();
		}

		#region Menu MainCommands

		#region Exit command

		private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		#endregion


		#region NewTjilp

		private void NewTjilpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void NewTjilpCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			VM.OpenTjilp(null);
		}

		#endregion

		#region OpenTest

		private void OpenCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void OpenCommandBindig_Excecute(object sender, ExecutedRoutedEventArgs e)
		{
			VM.OpenTest();
		}

		#endregion

		#endregion

		internal void ShowTjilps()
		{
			foreach (TjilpRecord item in VM.Tjilps.Tjilps)
			{
				TjilpStackPanel.Children.Insert(0, TjilpView(item));
			}
		}

		internal Border TjilpView(TjilpRecord tjilp)
		{
			StackPanel stackPanel = new StackPanel();
			TextBlock timeText = new TextBlock()
			{
				Text = tjilp.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"),
				FontSize = 10,
				HorizontalAlignment = HorizontalAlignment.Right,
				Margin = new Thickness(0, 0, 0, 2),
				Foreground = new SolidColorBrush(Colors.Blue),
			};
			stackPanel.Children.Add(timeText);

			TextBlock message = new TextBlock()
			{
				Text = tjilp.Message,
				TextWrapping = TextWrapping.Wrap,
			};

			stackPanel.Children.Add(message);

			Border border = new Border()
			{
				BorderBrush = Brushes.DarkSlateBlue,
				BorderThickness = new Thickness(0.5),
				Child = stackPanel,
				CornerRadius = new CornerRadius(15),
				Margin = new Thickness(0, 0, 0, 5),
				Padding = new Thickness(5),
			};

			return border;
		}

	}
}
