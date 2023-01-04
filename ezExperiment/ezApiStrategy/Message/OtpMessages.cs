using System;
namespace ezApiStrategy.Message
{
    public class SmsOtpMessage
    {
        public int OtpMessageId { get; set; }
        public string CellNo { get; set; }
        public string? Token { get; set; }
        public string? OtpToMatch { get; set; }
    }
}

