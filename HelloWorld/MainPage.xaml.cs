using System.Globalization;

#if ANDROID
using HelloWorld.Platforms.Android;
#endif

namespace HelloWorld;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		WelcomeLabel.Text = CultureInfo.CurrentUICulture.DisplayName;
		var mainActivity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity as MainActivity;
		mainActivity.showWidget();

	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterBtn.Text = $"Clicked {count} time";

#if ANDROID

		HelloWorld.Platforms.Android.FloatingService.showMessage($"Clicked {count} time");
#endif


	}

}
