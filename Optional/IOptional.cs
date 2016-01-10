using System;

namespace Optional
{
    public interface IOptional
    {
        Boolean IsSet { get; }

        Object Value { get; set; }
    }

    public interface IOptional<T>
    {
        new Boolean IsSet { get; }

        new T Value { get; set; }
    }
}