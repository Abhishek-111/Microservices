using static CartApi.Utility.StaticDetails;

namespace CartApi.Models.Dto
{
    public class RequestDto
    {
        public  ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        // for updating
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
