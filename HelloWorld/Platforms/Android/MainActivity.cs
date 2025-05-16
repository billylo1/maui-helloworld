using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Android.Provider;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using HelloWorld.Platforms.Android;
using Android.Runtime;
using Java.Lang;
namespace HelloWorld;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
        Intent? intent;

    public void showWidget()
    {
        intent = new Intent(this, typeof(FloatingService));

        if (!Settings.CanDrawOverlays(this))
        {
            StartActivityForResult(new Intent(Settings.ActionManageOverlayPermission, Android.Net.Uri.Parse("package:" + PackageName)), 0);
        }
        else
        {
            StartService(intent);
        }

        }
        
        protected override void OnStop()
    {
        base.OnStop();
    }
        
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 0)
            {
                if (!Settings.CanDrawOverlays(this))
                {


               }
                else
                {
                    StartService(new Intent(this, typeof(FloatingService)));
                }
            }
        }
}
