using IntercambioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntercambioAPI.BLL
{
    public class BLLBase : IDisposable
    {
        protected intercambioEntities dbContext { get; set; }

        public BLLBase()
        {
            this.dbContext = new intercambioEntities();
        }

        protected void LogException(Exception ex) { }

        void IDisposable.Dispose()
        {
            this.dbContext.Dispose();
        }


    }
}