﻿namespace CollectionJsonFormatter.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CollectionJsonIgnore : CollectionJsonAttribute
    {
    }
}