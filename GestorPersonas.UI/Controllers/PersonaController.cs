using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GestionDePersonas.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace IIParcial_Lenguajes.UI.Controllers
{
    public class PersonaController : Controller
    {
        public PersonaController()
        {

        }


        public async Task<IActionResult> Listar()
        {
            List<Persona> listadePersonas;

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://gestorpersonassi20200712171624.azurewebsites.net/api/Persona");
                string apiResponse = await response.Content.ReadAsStringAsync();
                listadePersonas = JsonConvert.DeserializeObject<List<Persona>>(apiResponse);

                foreach (var item in listadePersonas)
                {
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(listadePersonas);
        }

        public ActionResult Agregar()
        {

          return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Agregar(Persona persona, List<IFormFile> Foto)
        {
           

            foreach (var item in Foto)
            {
                if (item.Length>0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        persona.Foto = stream.ToArray();
                    }
                }
            }
           
            try
            {
                
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(persona);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://gestorpersonassi20200712171624.azurewebsites.net/api/Persona", byteContent); 

                    return RedirectToAction(nameof(Listar));
                
            }
            catch
            {
                return View();
            }


        }

        public async Task<IActionResult> Detalles(int id)
        {
            Persona persona;

            try
            {

                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                persona = JsonConvert.DeserializeObject<Persona>(apiResponse);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(persona);
        }

    }
}
