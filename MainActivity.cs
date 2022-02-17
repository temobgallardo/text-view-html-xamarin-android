using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace TextViewHtmlTest
{
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
  public class MainActivity : AppCompatActivity
  {
    private TextView _textView;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.activity_main);

      var html = "<p><a href = \"https://dfsm-webportal-ge4.ausvdc02.pcf.dell.com/users\" target = \"_blank\">https://dfsm-webportal-ge4.ausvdc02.pcf.dell.com</a></p>";
      _textView = FindViewById<TextView>(Resource.Id.myTextView);
      //_textView.Text = StripHtml(html);
      var text = StripHtml(html);
      //_textView.SetText(text.ToCharArray(), 0, text.Length);

      var a = StripHtml("<a href=\"http://www.google.com\">google</a> ");
      //_textView.SetText(GetHtml(a), TextView.BufferType.Spannable);
      _textView.MovementMethod = LinkMovementMethod.Instance;

      var tv2 = FindViewById<TextView>(Resource.Id.myTextView2);
      tv2.SetText(Html.FromHtml("<a href=\"http://www.stackoverflow.com\">Stackoverflow LinkMovement</a>", FromHtmlOptions.ModeCompact), TextView.BufferType.Spannable);
      tv2.MovementMethod = LinkMovementMethod.Instance;

      var tv3 = FindViewById<TextView>(Resource.Id.myTextView3);
      tv3.SetText(GetHtml("<a href=\"http://www.dell.com\">Dell LinkMovement</a>"), TextView.BufferType.Spannable);
      tv3.MovementMethod = LinkMovementMethod.Instance;

      var tv4 = FindViewById<TextView>(Resource.Id.myTextView4);
      tv4.SetText(GetHtml("<a href=\"http://www.dell.com\">No LinkMovement</a>"), TextView.BufferType.Spannable);
      //tv4.MovementMethod = LinkMovementMethod.Instance;

      SpannedString sp = new SpannedString("http://www.dell.com");
      var tv5 = FindViewById<TextView>(Resource.Id.myTextView5);
      tv5.SetText(sp, TextView.BufferType.Spannable);
      tv5.MovementMethod = LinkMovementMethod.Instance;

      var html2 = "<p>Hyperlink** on portal <a href=\"https://www.dell.com\" target=\"_blank\">dell portal</a> </p><p>idem <a href=\"https://www.theguardian.com\" target=\"_blank\">The Guardian</a></p><p>Not hyperlink on portal https://www.dell.com</p><p>idem https://www.reddit.com</p>";
      var tv6 = FindViewById<TextView>(Resource.Id.myTextView6);
      tv6.SetText(GetHtml(html2), TextView.BufferType.Spannable);
      tv6.MovementMethod = LinkMovementMethod.Instance;


    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    public string StripHtml(string html)
    {
      if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
      {
        return Html.FromHtml(html, FromHtmlOptions.ModeCompact).ToString();
      }
      else
      {
        return Html.FromHtml(html, FromHtmlOptions.ModeLegacy).ToString();
      }
    }

    public ISpanned GetHtml(string html)
    {
      if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
      {
        return Html.FromHtml(html, FromHtmlOptions.ModeCompact);
      }
      else
      {
        return Html.FromHtml(html, FromHtmlOptions.ModeLegacy);
      }
    }
  }
}