// <copyright file="ISlot.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using MiddlewareLayerFramework.Repository;
using System;

namespace MiddlewareLayerFramework.Entities
{
    /// <summary>
    /// Interface requires implementation of Slot POSTing
    /// </summary>
    public interface ISlot
    {
        Tuple<Slot, ResponseData> PostSlotTaking();
        Tuple<Slot, ResponseData> PostSlotTakingExpectError();
    }
}