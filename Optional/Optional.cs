using System;

namespace Optional
{
    public struct Optional : IOptional
    {
        private Object _Value;

        private Boolean _IsSet;

        //public Optional()
        //{
        //    _IsSet = false;
        //}

        public Optional(Object value)
        {
            _Value = value;
            _IsSet = true;
        }

        public Boolean IsSet
        {
            get
            {
                return _IsSet;
            }
        }

        public Object Value 
        {
            get
            {
                if (_IsSet == false)
                {
                    throw new NotSetException();
                }

                return _Value;
            }

            set
            {
                _IsSet = true;
                _Value = value;
            }
        }
    }

    public struct Optional<T> : IOptional<T>, IOptional 
    {
        private T _Value;

        private Boolean _IsSet;

        //public Optional()
        //{
        //    _IsSet = false;
        //}

        public Optional(T value)
        {
            _Value = value;
            _IsSet = true;
        }

        public Boolean IsSet
        {
            get
            {
                return _IsSet;
            }
        }

        object IOptional.Value
        {
            get { return _Value; }
            set { _Value = (T)value; }
        }

        public new T Value 
        {
            get
            {
                if (_IsSet == false)
                {
                    throw new NotSetException();
                }

                return _Value;
            }

            set
            {
                _IsSet = true;
                _Value = value;
            }
        }
    }
}