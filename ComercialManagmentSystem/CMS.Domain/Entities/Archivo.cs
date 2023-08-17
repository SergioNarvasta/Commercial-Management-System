using System;
using System.Collections.Generic;

namespace CMS.Domain.Entities
{
    public class File : Audit
    {
        public int     Id         {get;set;}
        public string  Name     {get;set;}       
        public string  Extension  {get;set;}   
        public double  Size    {get;set;}      
        public string  Location  {get;set;}  
        public int     Status     {get;set;}   
        public string  Base64     {get;set;} 
          
    }
}