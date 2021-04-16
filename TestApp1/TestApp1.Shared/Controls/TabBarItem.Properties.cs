using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TestApp1.Controls
{
	partial class TabBarItem
	{
		public IconElement Icon
		{
			get { return (IconElement)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		public static readonly DependencyProperty IconProperty =
			DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(TabBarItem), new PropertyMetadata(null, (s, e) => ((TabBarItem)s).OnPropertyChanged(e)));
	}
}
