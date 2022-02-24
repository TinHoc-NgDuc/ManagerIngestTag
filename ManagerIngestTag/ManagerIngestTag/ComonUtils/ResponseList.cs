using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerIngestTag.ComonUtils
{
    public class ResponseList<T>:Response
    {
        public List<T> Data { get; set; }
        [JsonConstructor]
        public ResponseList(List<T> data)
        {
            Data = data;
        }
        public ResponseList(List<T> data, string message)
        { 
            Data = data;
            base.Message = message;
        }
        public ResponseList(List<T> data, string message, Code code)
        {
            base.Code = code;
            Data = data;
            base.Message = message;
        }
    }
}
