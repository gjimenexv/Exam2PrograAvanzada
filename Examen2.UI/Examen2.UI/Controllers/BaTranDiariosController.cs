using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Examen2.UI.Models;

namespace Examen2.UI.Controllers
{
    public class BaTranDiariosController : Controller
    {
        string baseurl = "http://localhost:44305/";

        // GET: BaTranDiarios
        public async Task<IActionResult> Index()
        {
            List<BaTranDiario> aux = new List<BaTranDiario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/BaTranDiario");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<BaTranDiario>>(auxRes);
                }
            }
            return View(aux);
        }

        // GET: BaTranDiarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batrandiario = await GetOneById(Int32.Parse(id), new BaTranDiario());
            if (batrandiario == null)
            {
                return NotFound();
            }

            return View(batrandiario);
        }

        // GET: BaTranDiarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaTranDiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEmpresa,IdCuenta,NumSecuencia,TipTransaccion,SubtipTransac,FecTransaccion,CodMoneda,CodSistema,CodCliente,MonMovimiento,TipCambio,AsientoContable,Beneficiario,IndEstado,Observaciones,NumDocumento,IndEnvCajas,CodCajero,CtaExterna,NumReferencia,TransactionTime")] BaTranDiario baTranDiario)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseurl);

                    var myContent = JsonConvert.SerializeObject(baTranDiario);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postTask = client.PostAsync("api/BaTranDiario", byteContent).Result;

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("Index");
                        return RedirectToAction(nameof(Index));
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            }
            return View(baTranDiario);
        }

        // GET: BaTranDiarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batrandiario = await GetOneById(Int32.Parse(id), new BaTranDiario());
            if (batrandiario == null)
            {
                return NotFound();
            }
            return View(batrandiario);
        }

        // POST: BaTranDiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodEmpresa,IdCuenta,NumSecuencia,TipTransaccion,SubtipTransac,FecTransaccion,CodMoneda,CodSistema,CodCliente,MonMovimiento,TipCambio,AsientoContable,Beneficiario,IndEstado,Observaciones,NumDocumento,IndEnvCajas,CodCajero,CtaExterna,NumReferencia,TransactionTime")] BaTranDiario baTranDiario)
        {
            if (id != baTranDiario.CodEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseurl);

                    var myContent = JsonConvert.SerializeObject(baTranDiario);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postTask = client.PutAsync("api/BaTranDiario/" + id, byteContent).Result;

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("Index");
                        return RedirectToAction(nameof(Index));
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");


            }
            return View(baTranDiario);
        }

        // GET: BaTranDiarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baTranDiario = await GetOneById(Int32.Parse(id), new BaTranDiario());
            if (baTranDiario == null)
            {
                return NotFound();
            }

            return View(baTranDiario);
        }

        // POST: BaTranDiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var authors = await GetOneById(Int32.Parse(id), new BaTranDiario());
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                var myContent = JsonConvert.SerializeObject(authors);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.DeleteAsync("api/BaTranDiario/" + id).Result;

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool BaTranDiarioExists(string id)
        //{
        //    return _context.BaTranDiario.Any(e => e.CodEmpresa == id);
        //}

        private async Task<BaTranDiario> GetOneById(int? id, BaTranDiario aux)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/BaTranDiario/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<BaTranDiario>(auxRes);
                }
            }

            return aux;
        }
    }
}
