using NUnit.Framework;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MobileApp.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		private IApp app;
		private Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void FirstScreenAppeared()
		{
			var results = app.WaitForElement(c => c.Marked("Browse"));

			app.Screenshot("First screen appeared.");

			Assert.IsTrue(results.Any());
		}
	}
}
