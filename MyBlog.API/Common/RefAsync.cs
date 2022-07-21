namespace MyBlog.API.Common
{
    /// <summary>
    /// async 异步方法不让用ref 只能自己写一个了
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RefAsync<T>
    {
        public T Value { get; set; }

        public RefAsync()
        {
        }

        public RefAsync(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            T value = Value;
            return (value == null) ? "" : value.ToString();
        }

        public static implicit operator T(RefAsync<T> r)
        {
            return r.Value;
        }

        public static implicit operator RefAsync<T>(T value)
        {
            return new RefAsync<T>(value);
        }
    }
}
