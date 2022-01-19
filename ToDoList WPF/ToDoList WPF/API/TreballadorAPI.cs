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
    public class TreballadorAPI
    {
        string BaseUri;

        public TreballadorAPI()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"];
            //BaseUri = "https://localhost:44374/api/";
        }

        //GET tots els treballadors
        public async Task<List<TreballadorDades>> GetTreballadorsAsync()
        {
            List<TreballadorDades> treballadors = new List<TreballadorDades>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET a /treballador.
                HttpResponseMessage response = await client.GetAsync("treballador");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim i posa el resultat a la llista de treballadors.
                    treballadors = await response.Content.ReadAsAsync<List<TreballadorDades>>();
                    response.Dispose();
                }
                else
                {
                    treballadors = null;
                }
            }
            return treballadors;
        }

        //GET un treballador
        public async Task<TreballadorDades> GetTreballadorAsync(int Id)
        {
            TreballadorDades treballador = new TreballadorDades();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició GET a /treballador/(dni del treballador).
                HttpResponseMessage response = await client.GetAsync($"treballador/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    //Reposta 204 quan no ha trobat dades
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        treballador = null;
                    }
                    else
                    {
                        //Obtenim i coloca el resultat a treballador.
                        treballador = await response.Content.ReadAsAsync<TreballadorDades>();
                        response.Dispose();
                    }
                }
                else
                {
                    treballador = null;
                }
            }
            return treballador;
        }

        //POST un treballador
        public async Task AddAsync(TreballadorDades treballador)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició POST a /treballador}
                HttpResponseMessage response = await client.PostAsJsonAsync("treballador", treballador);
                response.EnsureSuccessStatusCode();
            }
        }

        //PUT (Modificar) un treballador
        public async Task UpdateAsync(TreballadorDades treballador, string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició PUT a /treballador/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"treballador/{Id}", treballador);
                response.EnsureSuccessStatusCode();
            }
        }

        //DELETE un treballador
        public async Task DeleteAsync(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem petició DELETE a /treballador/Id
                HttpResponseMessage response = await client.DeleteAsync($"treballador/{Id}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
