using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace TestApp1.Skia.Tizen
{
	class Program
	{
		static void Main(string[] args)
		{
			var host = new TizenHost(() => new TestApp1.App(), args);
			host.Run();
		}
	}
}
