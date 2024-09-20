namespace STM.API.Responses.Base
{
    using System.Runtime.Serialization;
    using STM.Common.Constants;

    [DataContract]
    public class BaseResponse<T>
    {
        public BaseResponse(string successDef = GlobalConstants.Success)
        {
            this.Type = successDef;
        }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "Message")]
        public string? Message { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }
    }
}
