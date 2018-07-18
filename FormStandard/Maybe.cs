using System;
namespace FormStandard
{
    public class Maybe<T> where T : class
    {
        public static Maybe<T> Success(T obj) => new Maybe<T>(obj);
        public static Maybe<T> Fail => new Maybe<T>();

        public bool IsSuccess { get; protected set; }
        public T Value { get; protected set; }

        private Maybe()
        {
            IsSuccess = false;
        }
        private Maybe(T obj)
        {
            if (obj == default(T)) throw new ArgumentNullException();
            Value = obj;
            IsSuccess = true;
        }
    }
}
