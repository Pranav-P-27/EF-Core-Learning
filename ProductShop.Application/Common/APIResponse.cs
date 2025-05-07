using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.Common
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode {  get; set; }
        public bool IsSuccess { get; set; }=false;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = ""; 

        public List<APIError> Errors { get; set; }

        public List<APIWarning> Warnings { get; set; }

        public void AddError(string errorMessage)
        {
            APIError aPIError= new APIError(errorMessage);
            Errors.Add(aPIError);
        }

        public void AddWarning(string errorMessage)
        {
            APIWarning aPIWarning = new APIWarning(errorMessage);
            Warnings.Add(aPIWarning);
        }
    }
}
