using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjMetropolitano.Models;
using System.Web.UI;
using System.IO;
using System.Web.Script.Serialization;
using prjMetropolitano.Dominio;

namespace prjMetropolitano.Controllers
{
    public class TarjetasController : Controller
    {
        private MetropolitanoEntities1 db = new MetropolitanoEntities1();

        // GET: tarjetas
        public async Task<ActionResult> Index()
        {
            var tARJETAs = db.TARJETAs.Include(t => t.TIPO_TARJETA).Include(t => t.USUARIO);
            return View(await tARJETAs.ToListAsync());
        }
        public async Task<ActionResult> Renovacion()
        {
            var tarjetas = db.TARJETAs.Where(t => t.COD_TIPO_TARJETA == "4");
            return View(await tarjetas.ToListAsync());
        }

        // GET: tarjetas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA tARJETA = await db.TARJETAs.FindAsync(id);
            if (tARJETA == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA);
        }

        // GET: tarjetas/Create
        public async Task<ActionResult> Renovar(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA tARJETA = await db.TARJETAs.FindAsync(id);
            if (tARJETA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_TIPO_TARJETA = new SelectList(db.TIPO_TARJETA, "COD_TIPO_TARJETA", "DESC_TIPO_TARJETA", tARJETA.COD_TIPO_TARJETA);
            ViewBag.COD_USUARIO_TARJETA = new SelectList(db.USUARIOs, "COD_USUARIO", "PASSWORD_USUARIO", tARJETA.COD_USUARIO_TARJETA);
            return View(tARJETA);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Renovar([Bind(Include = "COD_TARJETA,ESTADO_TARJETA,FE_EXP_TARJETA,COD_TIPO_TARJETA,COD_USUARIO_TARJETA,SALDO_TARJETA,NRO_TC,CVV_TC,VENCIMIENTO_TC,MONTO,TITULAR_TC,CODCARNET")] TARJETA tarjeta)
        {
           
            int flg = 0;
            if (ModelState.IsValid)
            {
                DateTime fechaexp =ObtieneFecha(tarjeta.CODCARNET);
                if (fechaexp == Convert.ToDateTime("01/01/1900"))
                {
                    TempData["alertMessage"] = "No se encuentra informacion para el codigo ingresado";
                    return RedirectToAction("Renovar");
                }
                else
                {
                    tarjeta.FE_EXP_TARJETA = fechaexp;
                    db.Entry(tarjeta).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["alertMessage"] = "Se actualizo la vigencia, su nuevo vencimiento es " + fechaexp.Date;
                    return RedirectToAction("Renovacion");

                }
            }
            ViewBag.COD_TIPO_TARJETA = new SelectList(db.TIPO_TARJETA, "COD_TIPO_TARJETA", "DESC_TIPO_TARJETA", tarjeta.COD_TIPO_TARJETA);
            ViewBag.COD_USUARIO_TARJETA = new SelectList(db.USUARIOs, "COD_USUARIO", "PASSWORD_USUARIO", tarjeta.COD_USUARIO_TARJETA);
            return View(tarjeta);
        }

        public DateTime ObtieneFecha(string codcarnet)
        {
            DateTime fechaexp = Convert.ToDateTime("01/01/1900");
            try
            {
                String url = "http://localhost:62370/SuneduService.svc/carnets/" + codcarnet;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create(url);
                    request.Method = "GET";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string tramaJson = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Carnet carnetObtenido = js.Deserialize<Carnet>(tramaJson);
                if (carnetObtenido != null) 
                {
                    return carnetObtenido.FECEXP_ALUMNO;
                }
                else
                {
                    return fechaexp;
                }
                    
            }
            catch (Exception ex)
            {

                return fechaexp;
            }
   
        }


        public ActionResult Create()
        {
            ViewBag.COD_TIPO_TARJETA = new SelectList(db.TIPO_TARJETA, "COD_TIPO_TARJETA", "DESC_TIPO_TARJETA");
            ViewBag.COD_USUARIO_TARJETA = new SelectList(db.USUARIOs, "COD_USUARIO", "PASSWORD_USUARIO");
            return View();
        }

        // POST: tarjetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "COD_TARJETA,ESTADO_TARJETA,SALDO_TARJETA,FE_EXP_TARJETA,COD_TIPO_TARJETA,COD_USUARIO_TARJETA")] TARJETA tARJETA)
        {
            if (ModelState.IsValid)
            {
                tARJETA.ESTADO_TARJETA = "A";
                tARJETA.SALDO_TARJETA = 0;
                db.TARJETAs.Add(tARJETA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.COD_TIPO_TARJETA = new SelectList(db.TIPO_TARJETA, "COD_TIPO_TARJETA", "DESC_TIPO_TARJETA", tARJETA.COD_TIPO_TARJETA);
            ViewBag.COD_USUARIO_TARJETA = new SelectList(db.USUARIOs, "COD_USUARIO", "PASSWORD_USUARIO", tARJETA.COD_USUARIO_TARJETA);
            return View(tARJETA);
        }

        // GET: tarjetas/Edit/5
        public async Task<ActionResult> Recarga(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA tARJETA = await db.TARJETAs.FindAsync(id);
            if (tARJETA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_TIPO_TARJETA = new SelectList(db.TIPO_TARJETA, "COD_TIPO_TARJETA", "DESC_TIPO_TARJETA", tARJETA.COD_TIPO_TARJETA);
            ViewBag.COD_USUARIO_TARJETA = new SelectList(db.USUARIOs, "COD_USUARIO", "PASSWORD_USUARIO", tARJETA.COD_USUARIO_TARJETA);
            return View(tARJETA);
        }

        // POST: tarjetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recarga([Bind(Include = "COD_TARJETA,ESTADO_TARJETA,FE_EXP_TARJETA,COD_TIPO_TARJETA,COD_USUARIO_TARJETA,SALDO_TARJETA,NRO_TC,CVV_TC,VENCIMIENTO_TC,MONTO,TITULAR_TC")] TARJETA tarjeta)
        {
            ServiceVisanet.Service1Client proxy = new ServiceVisanet.Service1Client();
            int retorno = 0;
            if (ModelState.IsValid)
            {
                ServiceVisanet.TC_Visa oTC = new ServiceVisanet.TC_Visa();
                oTC.NRO_TARJETA = tarjeta.NRO_TC;
                oTC.CVV_TARJETA = tarjeta.CVV_TC;
                oTC.VENC_TARJETA = tarjeta.VENCIMIENTO_TC;
                oTC.MONTO_CARGA = tarjeta.MONTO;
                oTC.TIT_TARJETA = tarjeta.TITULAR_TC;
                retorno = proxy.ValidarPagoVisaNet(oTC);
                if (retorno == 1)
                {
                    tarjeta.SALDO_TARJETA = tarjeta.SALDO_TARJETA + oTC.MONTO_CARGA;
                    if (ActualizarSaldo(tarjeta))
                    {
                        TempData["alertMessage"] = "Recarga existosa, su nuevo saldo es" + tarjeta.SALDO_TARJETA.ToString();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["alertMessage"] = "Error en el pago.";
                    }
                }
                else 
                {
                    TempData["alertMessage"] = "Los datos ingresados son incorrectos.";
                }
               return RedirectToAction("Recarga");
            }
            ViewBag.COD_TIPO_TARJETA = new SelectList(db.TIPO_TARJETA, "COD_TIPO_TARJETA", "DESC_TIPO_TARJETA", tarjeta.COD_TIPO_TARJETA);
            ViewBag.COD_USUARIO_TARJETA = new SelectList(db.USUARIOs, "COD_USUARIO", "PASSWORD_USUARIO", tarjeta.COD_USUARIO_TARJETA);
            return View(tarjeta);
        }
        public bool ActualizarSaldo(TARJETA tarjeta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tarjeta).State = EntityState.Modified;
                    int flag = db.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }        
            
        }
        // GET: tarjetas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA tARJETA = await db.TARJETAs.FindAsync(id);
            if (tARJETA == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA);
        }

        // POST: tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            TARJETA tARJETA = await db.TARJETAs.FindAsync(id);
            db.TARJETAs.Remove(tARJETA);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
