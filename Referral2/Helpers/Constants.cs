using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Helpers
{
    public class Constants
    {
        protected static string Address = "c8ee61fd";
        protected static string Server_Address = "192.168.110.47";
        protected static string Server_Port = "8080";
        public static string Server_Link => $"ws://{Server_Address}:{Server_Port}";

        public static string DIRECTED_CLIENT_TAG = "direct_to";
        public static string DISCONNECTED_CLIENT_TAG = "disconnected";
        public static string ENDPOINT_TAG = "endpoint";
        public static string FROM_CLIENT_TAG = "from";
        public static string INFORMATION_TAG = "information";
        public static string PAYLOAD_TAG = "payload";
        public static string RECEIVER_TAG = "receiver";
        public static string REQUEST_CLIENT_TAG = "clients";
        public static string SENDER_TAG = "sender";
        public static string SESSION_TAG = "and";
        public static string NOTIFICATION_TAG = "notification";


        public static string MESSAGE_TAG_GC_IT = "message_it";
        public static string MESSAGE_TAG_GC_DOC = "message_doc";
        public static string MESSAGE_TAG_GC_MCC = "message_mcc";
        public static string MESSAGE_TAG_PM = "message_pm";
    }
}
