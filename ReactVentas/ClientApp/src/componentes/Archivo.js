import { useState } from "react";
import './Proyectos.css';
import axios from 'axios';

const CargaArchivo = () =>{
   const [archivos,setArchivos]= useState(null);
   const subirArchivos=e=>{
    setArchivos(e);
   }
   const insertarArchivos=async()=>{
    const file = new FormData();

    for(let index=0;index<archivos.length; index++){
        file.append("files",archivos[index]);
    }
    const response = await fetch("api/archivos",{
        method:'POST',
        headers: {
           'Content-Type':'application/json;charset=utf-8'
        },
        body:JSON.stringify(file)
      }).then(response=>{
        console.log(response.data);
      }).catch(error=>{
        console.log(error);
      })

      if(response.ok){
          console.log("Registrado con exito");
      }
   }
   
   return(   
    <div className="Archivos">
        <br></br>
        <input type="file" name="files" multiple onChange={()=>subirArchivos(e.target.files)} />
        <button className="btn btn-sucess">Cargar Archivo</button>
    
    </div>
   )
}

export default CargaArchivo;