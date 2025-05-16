using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.View;
using Color = Android.Graphics.Color;
using View = Android.Views.View;


namespace HelloWorld.Platforms.Android
{
    [Service]
    public class FloatingService : Service, IOnTouchListener
    {
        WindowManagerLayoutParams layoutParams;
        IWindowManager windowManager;
        View floatView;

        static TextView textView;
        
        public static void showMessage(string message)
        {
            textView.Text = message;
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }


       public override bool OnUnbind(Intent? intent)
        {
            return base.OnUnbind(intent);
        }


       [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            showFloatingWindow();
            return StartCommandResult.NotSticky;
        }


        private void showFloatingWindow()
        {
            windowManager = GetSystemService(WindowService).JavaCast<IWindowManager>();
            LayoutInflater mLayoutInflater = LayoutInflater.From(ApplicationContext);
            floatView = mLayoutInflater.Inflate(Resource.Layout.floatview, null);
            floatView.SetBackgroundColor(Color.RoyalBlue);
            floatView.SetOnTouchListener(this);


            // set LayoutParam
            layoutParams = new WindowManagerLayoutParams();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                layoutParams.Type = WindowManagerTypes.ApplicationOverlay;
            }
            else
            {
                layoutParams.Type = WindowManagerTypes.Phone;
            }
            layoutParams.Flags = WindowManagerFlags.NotTouchModal;
            layoutParams.Flags = WindowManagerFlags.NotFocusable;


            layoutParams.Width = 800;
            layoutParams.Height = 600;
            layoutParams.X = 300;
            layoutParams.Y = 300;
            windowManager.AddView(floatView, layoutParams);
            textView = floatView.FindViewById<TextView>(Resource.Id.floatview_text);


       }
        private int x;
        private int y;
        public bool OnTouch(global::Android.Views.View? v, MotionEvent? e)
        {
            switch (e.Action)
            {


               case MotionEventActions.Down:
                    x = (int)e.RawX;
                    y = (int)e.RawY;
                    break;


               case MotionEventActions.Move:
                    int nowX = (int)e.RawX;
                    int nowY = (int)e.RawY;
                    int movedX = nowX - x;
                    int movedY = nowY - y;
                    x = nowX;
                    y = nowY;
                    layoutParams.X = layoutParams.X + movedX;
                    layoutParams.Y = layoutParams.Y + movedY;


                    windowManager.UpdateViewLayout(floatView, layoutParams);
                    break;


               default:
                    break;
            }
            return false;
        }

       public override IBinder? OnBind(Intent? intent)
        {
            throw new NotImplementedException();
        }

   }
}