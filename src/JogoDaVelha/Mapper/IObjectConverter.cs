namespace JogoDaVelha.Mapper
{
    public interface IObjectConverter
    {
        T Map<T>(object source);
    }
}
