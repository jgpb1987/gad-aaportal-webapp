namespace gad.security.algorithm.Misc
{
    public interface IDefaultInstance<T>
    {
        static abstract T DefaultInstance { get; }
    }
}
