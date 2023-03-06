import { useState } from "react";

const Archivo = () =>{
   const [archivos,setArchivos]= useState(null);
   const subirArchivos=e=>{
    setArchivos(e);
   }
   const insertarArchivos=async()=>{
    const file = new FormData();

    for(let index=0; index<archivos.length; index++){
        file.append("files",archivos[index]);
    }
    const response = await fetch("api/archivo",{
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
   }
   
   return(   
    <div className="Archivos">
        <br></br>
        <input type="file" name="files" multiple 
            onChange={(e)=>subirArchivos(e.target.files)} />
        <button className="btn btn-sucess" 
            onClick={()=>insertarArchivos()}>Cargar Archivo</button>
    
    </div>
   );
}

export default Archivo;