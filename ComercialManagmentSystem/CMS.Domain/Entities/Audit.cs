using System;
using System.Collections.Generic;

namespace CMS.Domain.Entities
{
    public class Audit
    {
        public string   Aud_UsuCre  {get;set;} 
        public DateTime Aud_FecCre  {get;set;} 
        public string   Aud_UsuAct  {get;set;} 
        public DateTime Aud_FecAct  {get;set;} 
          
    }
}