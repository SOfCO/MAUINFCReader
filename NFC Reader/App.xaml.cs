using Plugin.NFC;

namespace NFC_Reader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    CrossNFC.Current.StartListening();

                });
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            base.OnStart();
        }
        protected override void OnResume()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    CrossNFC.Current.StartListening();

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            base.OnResume();

        }

    }
}
