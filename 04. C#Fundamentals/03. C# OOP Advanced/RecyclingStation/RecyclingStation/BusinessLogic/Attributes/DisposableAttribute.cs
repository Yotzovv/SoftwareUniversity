using System;

namespace RecyclingStation.BusinessLogic.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class DisposableAttribute : Attribute
    {
    }
}
