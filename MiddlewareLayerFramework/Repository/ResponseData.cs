// <copyright file="ResponseData.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using RestSharp;

namespace MiddlewareLayerFramework.Repository
{
    /// <summary>
    /// Class wraps IRest response in compact fromat for testing purposes 
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// Reflects if REST response is successful
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Returns REST response status code
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Returns REST content in JSON format
        /// </summary>
        public string Content { get; set; }

        public ResponseData(IRestResponse restResponse)
        {
            IsSuccessful = restResponse.IsSuccessful;
            Status = (int)restResponse.StatusCode;
            Content = restResponse.Content;
        }
    }
}
