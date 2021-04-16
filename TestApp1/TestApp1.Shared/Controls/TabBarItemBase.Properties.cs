﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace TestApp1.Controls
{
	partial class TabBarItemBase
	{
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public static DependencyProperty CommandProperty { get; } =
			DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(TabBarItemBase), new PropertyMetadata(null));

		public object CommandParameter
		{
			get { return (object)GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public static DependencyProperty CommandParameterProperty { get; } =
			DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(TabBarItemBase), new PropertyMetadata(null));
	}
}
