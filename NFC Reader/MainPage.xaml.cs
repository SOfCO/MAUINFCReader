


using Android.App;
using Android.Content;
using Android.Nfc;
using Google.Android.Material.TimePicker;
using Java.Lang;
using Plugin.NFC;
using System.Text;

namespace NFC_Reader
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            // Subscribing to the NFC message received event
            InitializeComponent();
            CrossNFC.Current.OnMessageReceived += OnMessageReceived;
            


        }

        




      
        private void OnMessageReceived(ITagInfo tagInfo)
        {
            
            if (tagInfo == null)
            {
                DisplayAlert("Error", "No tag found", "OK");

                return;
            }
            

            // Process the NFC tag data on the UI thread
            Device.BeginInvokeOnMainThread(() =>
            {
                
                var message = new System.Text.StringBuilder("");
                // Check if the read tag contains any information
                if (tagInfo.Records != null)
                { 
                    foreach (var record in tagInfo.Records)
                {
                        // Check if the record is NDEF formatted
                        if (record.TypeFormat == Plugin.NFC.NFCNdefTypeFormat.WellKnown )                 
                    {
                            // Retrieving the message from the NFC record
                            var text = record.Message;
                            // Append the text to the message
                            message.AppendLine($"\n{text}");
                            // Update the UI label to display the NFC data
                            NfcDataLabel.Text = message.ToString();
                        }
                        else
                        {
                            // Display a message for unknown record types
                            NfcDataLabel.Text = "Unknown type";
                        }
                }
                }
                else
                {
                    // Display a message if the tag is empty
                    NfcDataLabel.Text = "Tag is Empty";
                }



                
            });}

       
    }
}

    








