



namespace NFC_Reader.Droid.Services
{
    //    public class AndroidNfcService : IAndroidServices
    //    {
    //        private static Tag _currentTag;

    //        public AndroidNfcService()
    //        {
    //        }

    //        public  void SetCurrentTag(Tag tag)
    //        {
    //            _currentTag = tag;
    //        }

    //        public  async Task<string> ReadPasswordAsync()
    //        {
    //            try
    //            {
    //                if (_currentTag == null)
    //                    throw new Exception("No NFC tag available");

    //                Ndef ndef = Ndef.Get(_currentTag);
    //                await ndef.ConnectAsync();

    //                var ndefMessage = ndef.NdefMessage;
    //                if (ndefMessage != null)
    //                {
    //                    var record = ndefMessage.GetRecords()[0];
    //                    var payload = Encoding.UTF8.GetString(record.GetPayload());
    //                    return payload; // Assuming the payload is the password
    //                }

    //                return null;
    //            }
    //            catch (Exception ex)
    //            {
    //                // Handle exceptions
    //                return null;
    //            }
    //        }

    //        public  async Task WritePasswordAsync(string password)
    //        {
    //            try
    //            {
    //                if (_currentTag == null)
    //                    throw new Exception("No NFC tag available");

    //                Ndef ndef = Ndef.Get(_currentTag);
    //                await ndef.ConnectAsync();

    //                var payload = Encoding.UTF8.GetBytes(password);
    //                var mimeRecord = new NdefRecord(NdefRecord.TnfWellKnown, Encoding.UTF8.GetBytes("text/plain"), new byte[0], payload);
    //                var ndefMessage = new NdefMessage(new NdefRecord[] { mimeRecord });

    //                ndef.WriteNdefMessage(ndefMessage);
    //            }
    //            catch (Exception ex)
    //            {
    //                // Handle exceptions
    //            }
    //        }
    //    }
    //}
}
