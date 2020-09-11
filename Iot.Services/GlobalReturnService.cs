using System.Net;
using Iot.Dto;

namespace Iot.Services
{
    public static class GlobalReturnService
    {
        public static ReturnResponse<ResponseDetail> ResponseData(HttpStatusCode httpStatus, string message, bool status)
        {
            return new ReturnResponse<ResponseDetail>
            {
                Response = new ResponseDetail()
                {
                    Message = message.FirstCharToUpperParagraph(),
                    Status = status
                },
                Status = httpStatus
            };
        }
        public static ReturnResponse<ResponseDetail<T>> ResponseData<T>(HttpStatusCode httpStatus, string message, bool status, T response)
        {
            return new ReturnResponse<ResponseDetail<T>>
            {
                Response = new ResponseDetail<T>()
                {
                    Message = message.FirstCharToUpperParagraph(),
                    Status = status,
                    Data = response
                },
                Status = httpStatus
            };
        }
        public static string FirstCharToUpperParagraph(this string input) =>
            System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}
