using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Common
{
    public class ApiResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string Error { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = null!;

        public void SetSuccess(T data, string message = "")
        {
            Success = true;
            Data = data;
            Message = message;
            Error = string.Empty;
        }

        public void SetError(string errorMessage, string message = "")
        {
            Success = false;
            Error = errorMessage;
            Message = message;
            Data = null!;
        }
    }
}
