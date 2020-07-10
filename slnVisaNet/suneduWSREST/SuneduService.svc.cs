using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using suneduWSREST.Model;
using suneduWSREST.Dominio;

namespace suneduWSREST
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SuneduService : ISuneduService
    {
        private suneduEntities db = new suneduEntities();

        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public CARNET ObtenerHorario(string codcarnet)
        {
            var query = from carnet in db.CARNETs.Where(x => (x.COD_CARNET == codcarnet))
                        select carnet;
            CARNET resultado = query.FirstOrDefault();
            return resultado;

        }
    }
}
