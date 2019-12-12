using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
