using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;

namespace TestApp1.Controls
{
    partial class TabBar
    {
        public event TypedEventHandler<TabBar, TabBarSelectionChangedEventArgs> SelectionChanged;
    }
}
