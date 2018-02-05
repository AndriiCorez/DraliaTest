// <copyright file="IWeekAvailability.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using MiddlewareLayerFramework.Repository;
using System;

namespace MiddlewareLayerFramework.Entities
{
    /// <summary>
    /// Interface requires implementation of Week Availability GETing
    /// </summary>
    internal interface IWeekAvailability
    {
        Tuple<WeekAvailability, ResponseData> GetWeekAvailability(string dateParameter);
    }
}