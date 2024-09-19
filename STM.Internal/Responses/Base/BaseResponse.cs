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

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
}
