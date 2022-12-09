using System.Windows.Input;

namespace Tjilp.Commands
{
	internal class MainCommands
	{
		public static readonly RoutedUICommand Exit = new RoutedUICommand
			(
				"E_xit",
				"Exit",
				typeof(MainCommands),
				new InputGestureCollection()
				{
					new KeyGesture(Key.F4, ModifierKeys.Alt),
					new KeyGesture(Key.W, ModifierKeys.Control),
				}
			);

		public static readonly RoutedUICommand NewTjilp = new RoutedUICommand
			(
				"New _Tjilp",
				"NewTjilp",
				typeof(MainCommands),
				new InputGestureCollection()
				{
					new KeyGesture(Key.N, ModifierKeys.Control),
				}
			);

		public static readonly RoutedUICommand Open = new RoutedUICommand
			(
				"_Open",
				"Open",
				typeof(MainCommands),
				new InputGestureCollection()
				{
					new KeyGesture(Key.O, ModifierKeys.Control),
				}
			);

	}
}
