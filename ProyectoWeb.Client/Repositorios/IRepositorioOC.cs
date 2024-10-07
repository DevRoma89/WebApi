
using ProyectoWeb.Shared.DTOs;

namespace ProyectoWeb.Client.Repositorios
{
    public interface IRepositorioOC
    {
        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<OCCabeceraDTO> GetByCliente(int id);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);
    }
}
