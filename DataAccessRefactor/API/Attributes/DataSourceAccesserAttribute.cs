using System;
using DataAccessRefactor.API.Enums;

namespace DataAccessRefactor.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataSourceAccesserAttribute : Attribute
    {
        public AccesserType AccesserType { get; private set; }

        public DataSourceAccesserAttribute(AccesserType accesserType)
        {
            AccesserType = accesserType;
        }
    }
}