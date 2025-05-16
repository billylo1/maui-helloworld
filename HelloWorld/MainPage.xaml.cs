using System.Globalization;
using Microsoft.Maui.Controls.Embedding;

namespace HelloWorld;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		WelcomeLabel.Text = CultureInfo.CurrentUICulture.DisplayName;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		#if ANDROID
			var mainActivity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity as MainActivity;
			mainActivity.showWidget();
		#endif

	}

}
