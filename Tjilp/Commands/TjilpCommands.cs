using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tjilp.Commands
{
	internal class TjilpCommands
	{
		public static readonly RoutedUICommand SaveAndClose = new RoutedUICommand
			(
				"_Save and close",
				"SaveAndClose",
				typeof(TjilpCommands),
				new InputGestureCollection()
				{
					new KeyGesture(Key.S, ModifierKeys.Control),
				}
			);

		public static readonly RoutedUICommand Close = new RoutedUICommand
			(
				"_Close",
				"Close",
				typeof(TjilpCommands),
				new InputGestureCollection()
				{
					new KeyGesture(Key.Escape),
				}
			);

	}
}
