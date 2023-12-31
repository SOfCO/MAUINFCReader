

using Plugin.NFC;
using System.Text;

namespace NFC_Reader
{
    public partial class MainPage : ContentPage
    {
       // private readonly IAndroidServices _nfcService;
        public MainPage()
        {
            InitializeComponent();
            CrossNFC.Current.OnMessageReceived += OnMessageReceived;
            //CrossNFC.Current.StartListening();
           
        }
        

        private void OnStartNfcClicked(object sender, EventArgs e)
        {

            if (!CrossNFC.Current.IsAvailable)
            {
                DisplayAlert("Error", "NFC is not available", "OK");
                return;
            }

            if (!CrossNFC.Current.IsEnabled)
            {
                DisplayAlert("Error", "NFC is not enabled", "OK");
                return;
            }

            CrossNFC.Current.StartListening();
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
                var message = new StringBuilder("NFC Tag Read:");
                foreach (var record in tagInfo.Records)
                {
                    // Check if the record is NDEF formatted
                    if (record.TypeFormat == Plugin.NFC.NFCNdefTypeFormat.WellKnown )                 
                    {
                       
                        var text = Encoding.UTF8.GetString(record.Payload);
                       


                        message.AppendLine($"\n{text}");
                    }
                }

                NfcDataLabel.Text = message.ToString();
            });
        }



        //-----------------------------------------------------------------------------
        //private static Tag _currentTag;

        //public static void SetCurrentTag(Tag tag)
        //{
        //    _currentTag = tag;
        //}

        //public static async Task<string> ReadPasswordAsync()
        //{
        //    try
        //    {
        //        if (_currentTag == null)
        //            throw new Exception("No NFC tag available");

        //        Ndef ndef = Ndef.Get(_currentTag);
        //        await ndef.ConnectAsync();

        //        var ndefMessage = ndef.NdefMessage;
        //        if (ndefMessage != null)
        //        {
        //            var record = ndefMessage.GetRecords()[0];
        //            var payload = Encoding.UTF8.GetString(record.GetPayload());
        //            return payload; // Assuming the payload is the password
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        return null;
        //    }
        //}

        //public static async Task WritePasswordAsync(string password)
        //{
        //    try
        //    {
        //        if (_currentTag == null)
        //            throw new Exception("No NFC tag available");

        //        Ndef ndef = Ndef.Get(_currentTag);
        //        await ndef.ConnectAsync();

        //        var payload = Encoding.UTF8.GetBytes(password);
        //        var mimeRecord = new NdefRecord(NdefRecord.TnfWellKnown, Encoding.UTF8.GetBytes("text/plain"), new byte[0], payload);
        //        var ndefMessage = new NdefMessage(new NdefRecord[] { mimeRecord });

        //        ndef.WriteNdefMessage(ndefMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //    }
        //}
    }
}

    



//private async void OnSetPasswordClicked(object sender, EventArgs e)
//{
//    try
//    {
//        // Detect and communicate with the NFC tag
//        var nfc = NfcAdapter.GetDefaultAdapter(Xamarin.Essentials.Platform.CurrentActivity);
//        if (nfc != null)
//        {
//            var nfcPendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, GetType()).AddFlags(ActivityFlags.SingleTop), 0);
//            nfc.EnableForegroundDispatch(this, nfcPendingIntent, new IntentFilter[] { new IntentFilter(NfcAdapter.ActionNdefDiscovered) }, null);
//        }
//        var nfcIntent = Xamarin.Essentials.Platform.CurrentActivity.Intent;

//        // Handle NFC tag discovery
//        if (nfcIntent.Action == NfcAdapter.ActionNdefDiscovered)
//        {
//            NdefMessage[] messages = GetNdefMessages(nfcIntent);
//            foreach (NdefMessage message in messages)
//            {
//                // Authenticate with the NFC tag (if required)
//                bool authenticated = AuthenticateWithNfcTag(message);

//                if (authenticated)
//                {
//                    // Write the password to the NFC tag
//                    string newPassword = "YourPassword"; // Replace with the desired password
//                    byte[] passwordData = Encoding.UTF8.GetBytes(newPassword);
//                    NdefRecord passwordRecord = new NdefRecord(NdefRecord.TnfWellKnown, NdefRecord.RtdText, new byte[0], passwordData);
//                    NdefMessage newMessage = new NdefMessage(new NdefRecord[] { passwordRecord });

//                    WriteNdefMessage(nfcIntent, newMessage);

//                    // Set access control settings (if applicable)
//                    SetAccessControlSettings(nfcIntent, newPassword);

//                    // Provide feedback to the user (e.g., password set successfully)
//                    await DisplayAlert("Success", "Password set on NFC tag.", "OK");
//                }
//                else
//                {
//                    // Authentication failed; handle accordingly
//                    await DisplayAlert("Authentication Failed", "Could not authenticate with NFC tag.", "OK");
//                }
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle any exceptions that may occur during NFC interaction
//        StatusLabel.Text = "Error: " + ex.Message;
//    }
//}

// Implement the NFC interaction methods here
//private bool AuthenticateWithNfcTag(NdefMessage message)
//{
//    // Implement NFC tag authentication logic here
//    // Return true if authentication is successful; otherwise, return false
//    return true; // Replace with your authentication logic
//}

//private NdefMessage[] GetNdefMessages(Intent intent)
//{
//    // Implement NFC message retrieval logic here
//    // Return an array of NdefMessages from the NFC tag
//    return null; // Replace with your logic to retrieve NdefMessages
//}

//private void WriteNdefMessage(Intent intent, NdefMessage message)
//{
//    // Implement NFC message writing logic here
//    // Write the NdefMessage to the NFC tag
//    // You will need to use appropriate Android NFC APIs for this
//}

//private void SetAccessControlSettings(Intent intent, string password)
// {
// Implement access control settings logic here
// Set access control settings on the NFC tag as needed
// You will need to use appropriate Android NFC APIs for this
// }
//private void OnSetPasswordClicked(object sender, EventArgs e)
//{
//    var password = PasswordEntry.Text;
//    if (string.IsNullOrEmpty(password))
//    {
//        DisplayAlert("Error", "Password is required.", "OK");
//        return;
//    }

//    passwordBytes = Encoding.UTF8.GetBytes(password);
//    CrossNFC.Current.StartListening();
//}

//private async void Current_OnTagDiscovered(ITagInfo tagInfo, bool format) 
//{
//    if (tagInfo != null)
//    {
//        SetPasswordOnTag(tagInfo, passwordBytes);
//        return;
//    }
//    else
//    {
//        DisplayAlert("Error", "NO info .", "OK");
//        return;
//    }


//}

//private async Task SetPasswordOnTag(ITagInfo tagInfo, byte[] passwordBytes)
//{
//    try
//    {



//        // Assuming the library has a method to set a password on the NFC tag
//        // This is a hypothetical example and the actual method will depend on the library you're using
//        bool result = await SendPasswordCommandsToTag(tagInfo, passwordBytes);

//        if (result)
//        {
//            DisplayAlert("Success", "Password set successfully on the NFC tag.", "OK");
//        }
//        else
//        {
//            DisplayAlert("Error", "Failed to set password on the NFC tag.", "OK");
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle any exceptions that might occur
//        DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
//    }
//}
//public void SetPasswordOnTag(ITagInfo tagInfo, string password)
//{
//    byte[] setPasswordCommand = BuildSetPasswordCommand(password);

//    try
//    {

//         CrossNFC.Current.SendCommand(setPasswordCommand);
//    }
//    catch (Exception ex)
//    {
//        // Handle exceptions
//    }
//}

//private byte[] BuildSetPasswordCommand(string password)
//{
//    // Convert the password to a byte array (assuming ASCII encoding)
//    byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

//    // Define the command bytes specific to your NFC tag type
//    // These bytes are usually provided in the tag's datasheet or documentation
//    // For example, the command might start with a specific byte sequence like {0xA2, 0xE2}
//    byte[] commandBytes = [0xA2, 0x2B];

//    // Combine the command bytes and the password bytes
//    byte[] setPasswordCommand = new byte[commandBytes.Length + passwordBytes.Length];
//    Array.Copy(commandBytes, 0, setPasswordCommand, 0, commandBytes.Length);
//    Array.Copy(passwordBytes, 0, setPasswordCommand, commandBytes.Length, passwordBytes.Length);

//    return setPasswordCommand;
//}

//public static void SetPassword(string password)
//{
//    // The actual password setting process depends on the NFC tag you are using.
//    // In this example, I assume that the password is set using a command similar to this:
//    // new byte[] { 0xFF, 0x00, 0x51, 0x00, 0x00 }.Concat(Encoding.ASCII.GetBytes(password)).ToArray()

//    var command = new byte[] { 0xFF, 0x00, 0x51, 0x00, 0x00 }.Concat(Encoding.ASCII.GetBytes(password)).ToArray();
//    var nfcTagReader = new NFCTagReaderSession();
//    var response = nfcTagReader.Transceive(command);

//    if (response != null )
//    {
//        Console.WriteLine("Password set successfully.");
//    }
//    else
//    {
//        Console.WriteLine("Error setting password.");
//    }
//}






//private async void OnSetPasswordClicked(object sender, EventArgs e)
//{
//    try
//    {
//        // Detect and communicate with the NFC tag
//        var nfc = NfcAdapter.GetDefaultAdapter(Xamarin.Essentials.Platform.CurrentActivity);
//        if (nfc != null)
//        {
//            var nfcPendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, GetType()).AddFlags(ActivityFlags.SingleTop), 0);
//            nfc.EnableForegroundDispatch(this, nfcPendingIntent, new IntentFilter[] { new IntentFilter(NfcAdapter.ActionNdefDiscovered) }, null);
//        }
//        var nfcIntent = Xamarin.Essentials.Platform.CurrentActivity.Intent;

//        // Handle NFC tag discovery
//        if (nfcIntent.Action == NfcAdapter.ActionNdefDiscovered)
//        {
//            NdefMessage[] messages = GetNdefMessages(nfcIntent);
//            foreach (NdefMessage message in messages)
//            {
//                // Authenticate with the NFC tag (if required)
//                bool authenticated = AuthenticateWithNfcTag(message);

//                if (authenticated)
//                {
//                    // Write the password to the NFC tag
//                    string newPassword = "YourPassword"; // Replace with the desired password
//                    byte[] passwordData = Encoding.UTF8.GetBytes(newPassword);
//                    NdefRecord passwordRecord = new NdefRecord(NdefRecord.TnfWellKnown, NdefRecord.RtdText, new byte[0], passwordData);
//                    NdefMessage newMessage = new NdefMessage(new NdefRecord[] { passwordRecord });

//                    WriteNdefMessage(nfcIntent, newMessage);

//                    // Set access control settings (if applicable)
//                    SetAccessControlSettings(nfcIntent, newPassword);

//                    // Provide feedback to the user (e.g., password set successfully)
//                    await DisplayAlert("Success", "Password set on NFC tag.", "OK");
//                }
//                else
//                {
//                    // Authentication failed; handle accordingly
//                    await DisplayAlert("Authentication Failed", "Could not authenticate with NFC tag.", "OK");
//                }
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle any exceptions that may occur during NFC interaction
//        StatusLabel.Text = "Error: " + ex.Message;
//    }
//}

// Implement the NFC interaction methods here
//private bool AuthenticateWithNfcTag(NdefMessage message)
//{
//    // Implement NFC tag authentication logic here
//    // Return true if authentication is successful; otherwise, return false
//    return true; // Replace with your authentication logic
//}

//private NdefMessage[] GetNdefMessages(Intent intent)
//{
//    // Implement NFC message retrieval logic here
//    // Return an array of NdefMessages from the NFC tag
//    return null; // Replace with your logic to retrieve NdefMessages
//}

//private void WriteNdefMessage(Intent intent, NdefMessage message)
//{
//    // Implement NFC message writing logic here
//    // Write the NdefMessage to the NFC tag
//    // You will need to use appropriate Android NFC APIs for this
//}

//private void SetAccessControlSettings(Intent intent, string password)
// {
// Implement access control settings logic here
// Set access control settings on the NFC tag as needed
// You will need to use appropriate Android NFC APIs for this
// }
//private void OnSetPasswordClicked(object sender, EventArgs e)
//{
//    var password = PasswordEntry.Text;
//    if (string.IsNullOrEmpty(password))
//    {
//        DisplayAlert("Error", "Password is required.", "OK");
//        return;
//    }

//    passwordBytes = Encoding.UTF8.GetBytes(password);
//    CrossNFC.Current.StartListening();
//}

//private async void Current_OnTagDiscovered(ITagInfo tagInfo, bool format) 
//{
//    if (tagInfo != null)
//    {
//        SetPasswordOnTag(tagInfo, passwordBytes);
//        return;
//    }
//    else
//    {
//        DisplayAlert("Error", "NO info .", "OK");
//        return;
//    }


//}

//private async Task SetPasswordOnTag(ITagInfo tagInfo, byte[] passwordBytes)
//{
//    try
//    {



//        // Assuming the library has a method to set a password on the NFC tag
//        // This is a hypothetical example and the actual method will depend on the library you're using
//        bool result = await SendPasswordCommandsToTag(tagInfo, passwordBytes);

//        if (result)
//        {
//            DisplayAlert("Success", "Password set successfully on the NFC tag.", "OK");
//        }
//        else
//        {
//            DisplayAlert("Error", "Failed to set password on the NFC tag.", "OK");
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle any exceptions that might occur
//        DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
//    }
//}





