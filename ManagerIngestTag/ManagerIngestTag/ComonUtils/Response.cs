using System.Text.Json.Serialization;

namespace ManagerIngestTag.ComonUtils
{
    public class Response
    {
        public Code Code
        {
            get;
            set;
        } = Code.Success;


        public string Message
        {
            get;
            set;
        } = "Thành công";


        public long TotalTime
        {
            get;
            set;
        }

        public int? DataCount
        {
            get;
            set;
        }

        public int? Status
        {
            get;
            set;
        }

        public int? TotalCount
        {
            get;
            set;
        }

        [JsonConstructor]
        public Response(Code code, string message)
        {
            Code = code;
            Message = message;
        }

        public Response(string message)
        {
            Message = message;
        }

        public Response()
        {
        }
    }
}
