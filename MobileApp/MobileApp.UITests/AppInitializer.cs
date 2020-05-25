using System;
using System.IO;
using System.Runtime.InteropServices;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace MobileApp.UITests
{
	public class AppInitializer
	{
		static string WorkingDirectory =>
			Path.GetDirectoryName(typeof(AppInitializer).Assembly.Location);

		public static IApp StartApp(Platform platform) =>
			platform switch
			{
				Platform.Android => Configure(ConfigureApp.Android).StartApp(),
				Platform.iOS => Configure(ConfigureApp.iOS).StartApp(),
				_ => throw new ArgumentOutOfRangeException(nameof(platform)),
			};

		public static AndroidAppConfigurator Configure(AndroidAppConfigurator config) =>
			TestEnvironment.IsTestCloud
				? config
				: RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
					? config.ApkFile(Path.Combine(WorkingDirectory, "com.companyname.MobileApp.apk"))
					: config;

		public static iOSAppConfigurator Configure(iOSAppConfigurator config) =>
			TestEnvironment.IsTestCloud
				? config
				: config;
	}
}
