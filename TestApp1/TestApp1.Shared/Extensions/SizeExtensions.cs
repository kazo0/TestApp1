using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;

namespace TestApp1.Extensions
{
    public static class SizeExtensions
    {
		internal static Size NumberOrDefault(this Size value, Size defaultValue)
		{
			return new Size(
				value.Width.NumberOrDefault(defaultValue.Width),
				value.Height.NumberOrDefault(defaultValue.Height)
			);
		}

		internal static double NumberOrDefault(this double value, double defaultValue)
		{
			return double.IsNaN(value)
				? defaultValue
				: value;
		}
	}
}
