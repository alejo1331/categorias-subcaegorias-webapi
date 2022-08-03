using Microsoft.Extensions.Configuration;
using Categorias.Domain.Repository.Interface;
using Noticias.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categorias.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Categorias.Domain.Repository
{
    public class RepositoryCategoriaTramiteDestacado : InterfaceCategoriaTramiteDestacado
    {
        private IConfiguration Configuration;
        private string apiEndPointTramites;

        public RepositoryCategoriaTramiteDestacado()
        {
            Configuration = AppSettings.GetConfiguration();
            apiEndPointTramites = Configuration["HostWebAPIs:TramitesWebApi"];
        }

        public void Dispose() { }

        public async Task<CategoriaTramiteDestacado> EliminarCategoriaTramiteDestacado(int idCategoria,string numeroTramite)
        {
           var apiClient = new HttpClient();
            Response<CategoriaTramiteDestacado> response = new Response<CategoriaTramiteDestacado>();

            var responseDelete = await apiClient.DeleteAsync(apiEndPointTramites + "CategoriaTramiteDestacado/" + idCategoria + "/" + numeroTramite);
            if (responseDelete.IsSuccessStatusCode)
            {
                var responseBody = await responseDelete.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<Response<CategoriaTramiteDestacado>>(responseBody);
            }
          
            return response.Data;

        }
    }
}
