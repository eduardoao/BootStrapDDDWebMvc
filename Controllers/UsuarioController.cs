using BootStrapDDDWebMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

//Todo esta uma zona refatorar 
namespace BootStrapDDDWebMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private static readonly HttpClient client = new HttpClient();


        // GET: Usuario
        public ActionResult Index()
        {
            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri("https://localhost:44332/api/");

                var get = api.GetAsync("usuario");
                get.Wait();

                var retorno = get.Result;

                if (retorno.IsSuccessStatusCode)
                {                    
                    var readTask = retorno.Content.ReadAsAsync<IEnumerable<Usuario>>().Result;

                    return View(readTask);
                }
            }

            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            string url = "https://localhost:44332/api/usuario";
            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri("https://localhost:44332/api/");
                
                var get = api.GetAsync(url + "/" + id.ToString());
                get.Wait();

                var retorno = get.Result;

                if (retorno.IsSuccessStatusCode)
                {
                    var readTask = retorno.Content.ReadAsAsync<Usuario>().Result;

                    return View(readTask);
                }
            }

            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (var api = new HttpClient())
                {
                    api.BaseAddress = new Uri("https://localhost:44332/api/");


                    var post = api.PostAsJsonAsync("usuario", (collection));
                    post.Wait();

                    var retorno = post.Result;

                    if (retorno.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                    

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "https://localhost:44332/api/usuario";
            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri("https://localhost:44332/api/");

                var get = api.GetAsync(url + "/" + id.ToString());
                get.Wait();

                var retorno = get.Result;

                if (retorno.IsSuccessStatusCode)
                {
                    var readTask = retorno.Content.ReadAsAsync<Usuario>().Result;

                    return View(readTask);
                }
            }

            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario collection)
        {
            try
            {
                string url = "https://localhost:44332/api/usuario";
                // TODO: Add insert logic here
                using (var api = new HttpClient())
                {
                    api.BaseAddress = new Uri("https://localhost:44332/api/");


                    var post = api.PutAsJsonAsync(url + "/" + id, (collection));
                    post.Wait();

                    var retorno = post.Result;

                    if (retorno.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            string url = "https://localhost:44332/api/usuario";
            using (var api = new HttpClient())
            {
                //api.BaseAddress = new Uri("https://localhost:44332/api/");

                var get = api.GetAsync(url + "/" + id.ToString());
                get.Wait();

                var retorno = get.Result;

                if (retorno.IsSuccessStatusCode)
                {
                    var readTask = retorno.Content.ReadAsAsync<Usuario>().Result;

                    return View(readTask);
                }
            }

            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                string url = "https://localhost:44332/api/usuario";
                using (var api = new HttpClient())
                {                  

                    var get = api.DeleteAsync(url + "/" + id.ToString());
                    get.Wait();

                    var retorno = get.Result;

                    if (retorno.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}