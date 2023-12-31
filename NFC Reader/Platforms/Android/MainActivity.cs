using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Nfc;
using Android.Nfc.Tech;
using Android.OS;
using Java.Lang;
using NFC_Reader;
using NFC_Reader.Droid.Services;
using Plugin.NFC;


namespace NFC_Reader {
   
       [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
       public class MainActivity : MauiAppCompatActivity
       {



           protected override void OnCreate(Bundle savedInstanceState)
           {


               // Plugin initialization
               CrossNFC.Init(this);
                base.OnCreate(savedInstanceState);
               Xamarin.Essentials.Platform.Init(this, savedInstanceState);
               // Other initialization code...
           }
           protected override void OnResume()
           {
               base.OnResume();

               // Plugin NFC: Restart NFC listening on resume (needed for Android 10+) 
               CrossNFC.OnResume();
           }
           protected override void OnNewIntent(Intent intent)
           {
               base.OnNewIntent(intent);

               // Plugin NFC: Tag Discovery Interception
               CrossNFC.OnNewIntent(intent);
           }

           public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
           {
               Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

               base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
           }
       }

  //  using Android.App;
  //  using Android.Content;
  //  using Android.Nfc;
  //  using Android.OS;
  //  using Microsoft.Maui;
  ////  using nfc_test.Models;

  //  [Activity(Label = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
  //  [IntentFilter(new[] { NfcAdapter.ActionNdefDiscovered }, Categories = new[] { Intent.CategoryDefault })]
  //  public class MainActivity : MauiAppCompatActivity
  //  {
  //      protected override void OnCreate(Bundle savedInstanceState)
  //      {
  //          base.OnCreate(savedInstanceState);
  //          // Initialize NFC service
  //          Xamarin.Essentials.Platform.Init(this, savedInstanceState);
  //          // Other initialization code...
  //      }

  //      protected override void OnNewIntent(Intent intent)
  //      {
  //          base.OnNewIntent(intent);

  //          if (NfcAdapter.ActionNdefDiscovered.Equals(intent.Action))
  //          {
  //              var tag = (Tag)intent.GetParcelableExtra(NfcAdapter.ExtraTag);
  //              // Use DependencyService to get your NFC service and set the tag
  //            //  var nfcService = DependencyService.Get<IAndroidServices>();
  //             // nfcService?.SetCurrentTag(tag);
  //          }
  //      }

  //      public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
  //      {
  //          Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
  //          base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
  //      }
  //  }

}
