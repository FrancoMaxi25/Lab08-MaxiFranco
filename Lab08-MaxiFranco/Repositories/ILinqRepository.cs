namespace Lab08_MaxiFranco.Repositories;

public interface ILinqRepository
{
    Task<object> Ejercicio1(string nombre);
    Task<object> Ejercicio2(decimal precio);
    Task<object> Ejercicio3(int orderId);
    Task<object> Ejercicio4(int orderId);
    Task<object> Ejercicio5();
    Task<object> Ejercicio6(DateTime fecha);
    Task<object> Ejercicio7();
    Task<object> Ejercicio8();
    Task<object> Ejercicio9();
    Task<object> Ejercicio10();
    Task<object> Ejercicio11(int clientId);
    Task<object> Ejercicio12(int productId);
}