namespace MetroWebWcfService
{
    interface IAdapter<T>
    {
        T ToObject();
    }
}