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

                var response = await httpClient.GetAsync("");
                string apiResponse = await response.Content.ReadAsStringAsync();
                listadePersonas = JsonConvert.DeserializeObject<List<Persona>>(apiResponse);

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
        public async Task<ActionResult> Agregar(Persona persona)
        {
            var ms = new MemoryStream();
            persona.Imagen.OpenReadStream().CopyTo(ms); 
            Byte[] Valor = ms.ToArray();

            persona.Foto.SetValue(Valor.);

            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(persona);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("", byteContent); 

                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }
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
