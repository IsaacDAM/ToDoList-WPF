using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDoList_WPF.Entitats;

namespace ToDoList_WPF.API
{
    class TascaAPI
    {
        String BaseUri;

        public TascaAPI()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"];
        }
        //GET tots els treballadors
        public async Task<List<TascaDades>> GetTascaAsync()
        {
            List<TascaDades> tasques = new List<TascaDades>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET a /tasca.
                HttpResponseMessage response = await client.GetAsync("tasca");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim i posa el resultat a la llista de tasques.
                    tasques = await response.Content.ReadAsAsync<List<TascaDades>>();
                    response.Dispose();
                }
                else
                {
                    tasques = null;
                }
            }
            return tasques;
        }
        //POST una tasca
        public async Task AddAsync(TascaDades tasca)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició POST a /tasca}
                HttpResponseMessage response = await client.PostAsJsonAsync("tasca", tasca);
                response.EnsureSuccessStatusCode();
            }
        }
        //PUT (Modificar) una tasca
        public async Task UpdateAsync(TascaDades tasca, String titol)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició PUT a /tasca
                HttpResponseMessage response = await client.PutAsJsonAsync("tasca",tasca);
                response.EnsureSuccessStatusCode();
            }
        }
        //DELETE una tasca
        public async Task DeleteAsync(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició DELETE a /treballador/Id
                HttpResponseMessage response = await client.DeleteAsync($"tasca/{id}");
                response.EnsureSuccessStatusCode();
            }
        }
        //GET tasca
        public async Task<TascaDades> GetTascaAsync(string Id)
        {
            TascaDades tasca = new TascaDades();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició GET a /tasca/(Titol de la tasca).
                HttpResponseMessage response = await client.GetAsync($"tasca/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    //Reposta 204 quan no ha trobat dades
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        tasca = null;
                    }
                    else
                    {
                        //Obtenim i coloca el resultat a treballador.
                        tasca = await response.Content.ReadAsAsync<TascaDades>();
                        response.Dispose();
                    }
                }
                else
                {
                    tasca = null;
                }
            }
            return tasca;
        }
    }
}
