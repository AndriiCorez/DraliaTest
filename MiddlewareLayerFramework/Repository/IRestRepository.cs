// <copyright file="IRestRepository.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using RestSharp;

namespace MiddlewareLayerFramework.Repository
{
    /// <summary>
    /// Interface requires implementation of set of methods to implement REST requests
    /// </summary>
    interface IRestRepository
    {
        IRestResponse Get(RestClient client, string endpoint);
        IRestResponse Post(RestClient client, string endpoint, string requestBody);

    }
}
