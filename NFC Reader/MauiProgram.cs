using Microsoft.Extensions.Logging;
using NFC_Reader.Droid.Services;
//using nfc_test.Models;

namespace NFC_Reader
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
           // DependencyService.Register<IAndroidServices, AndroidNfcService>();
            return builder.Build();
        }
    }
}
