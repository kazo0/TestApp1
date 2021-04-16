using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace TestApp1.Controls
{
	public abstract partial class TabBarItemBase : ListViewItem
	{
		protected override void OnPointerReleased(Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
		{
			var command = Command;
			if (command != null)
			{
				var commandParameter = CommandParameter;
				if (command.CanExecute(commandParameter))
				{
					command.Execute(commandParameter);
				}
			}

			base.OnPointerReleased(e);
		}
	}
}
