﻿namespace SnippetsApplication.Models
{
    [Serializable]
    public class JsonResponseViewModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}