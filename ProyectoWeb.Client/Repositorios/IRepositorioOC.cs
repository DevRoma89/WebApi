
namespace ProyectoWeb.Client.Repositorios
{
    public interface IRepositorioOC
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
