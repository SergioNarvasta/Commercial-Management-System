using System;
using System.Collections.Generic;

namespace ReactVentas.Models
{
    public class Archivo
    {
        public int     Archivo_Id         {get;set;}
        public string  Archivo_Nombre     {get;set;}       
        public string  Archivo_Extension  {get;set;}   
        public double  Archivo_Tamanio    {get;set;}      
        public string  Archivo_Ubicacion  {get;set;}  
        public int     Archivo_Estado     {get;set;}   
        public string  Archivo_Base64     {get;set;} 

        public string   Aud_UsuCre  {get;set;} 
        public datetime Aud_FecCre  {get;set;} 
        public string   Aud_UsuAct  {get;set;} 
        public datetime Aud_FecAct  {get;set;} 
          
    }
}