import { useState } from "react";
import { Button, Form, FormGroup,Input } from "reactstrap";
import {Document,Page,Text} from "@react-pdf/renderer";

const modeloRecibo = {  
    id : 0,
    nroDoc :"",
    titulo :"",
    descripcion:"",
    moneda :"",
    monto  : 0.00,
    tipoDoc :"",
    direccion:"",
    nombres :""
}

const RegistroRecibo = () =>{
   const [recibo,setrecibo]= useState(modeloRecibo);
   const [verRecibo,setVerRecibo]=useState(false);
   const [infoRecibo,setInfoRecibo]=useState([]);
        
   const mostrarRecibo = (recibo) =>{
    setVerRecibo(true);
    setInfoRecibo(recibo);
   }
   const actualizaDato = (e) => {
     console.log(e.target.name+" : "+ e.target.value);
     setrecibo(
        {
            ...recibo,
            [e.target.name] : e.target.value
        }
     )
   }
   const enviarDatos = () => {
        guardarRecibo(recibo)
    
   }
   const guardarRecibo = async (recibo) =>{
    const response = await fetch("api/receipt/Registrar",{
      method:'POST',
      headers: {
         'Content-Type':'application/json;charset=utf-8'
      },
      body:JSON.stringify(recibo)
    })
    if(response.ok){
        console.log("Registrado con exito");
        document.getElementById("LnList").click();
    }
   }

   return(   
    <Form>
        <h2 className="text-center">Generador de Recibos</h2> <hr/>
            {verRecibo ? (
                <div>
                    <button onClick={() => setVerRecibo(false)}>Cerrar Vista</button>
                    
                </div>
            ): null
            }
        <Button id="btn_gen" onClick={enviarDatos}>Generar Recibo</Button>
        <Button className="ms-3" onClick={mostrarRecibo(recibo)} >Mostrar PDF</Button><hr/>
        <Document>
            <Page size ="A4">
                <FormGroup className="d-flex flex-row fg-tit">
                  <Text>Titulo</Text>
                  <Input id="form-titulo" name="titulo" onChange={(e) => actualizaDato(e) } value={recibo.titulo}></Input>
               </FormGroup>
                <div className="d-flex flex-row fg-box2">
                   <FormGroup className="d-flex flex-row">
                     <Text>Nro de Documento</Text>
                     <Input id="form-nroDoc" name="nroDoc" onChange={(e) => actualizaDato(e) } value={recibo.nroDoc}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <Text>Tipo de Documento</Text>
                     <Input id="form-tipodoc" name="tipoDoc" onChange={(e) => actualizaDato(e) } value={recibo.tipoDoc}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <Text>Moneda</Text>
                     <Input name="moneda" onChange={(e) => actualizaDato(e) } value={recibo.moneda}></Input>
                 </FormGroup>
                </div>
                <FormGroup className="d-flex flex-row">
                  <Text>Descripcion</Text>
                  <Input id="form-desc" name="descripcion" onChange={(e) => actualizaDato(e) } value={recibo.descripcion}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <Text>Nombres Completos</Text>
                  <Input id="form-nombres" name="nombres" onChange={(e) => actualizaDato(e) } value={recibo.nombres}></Input>
                </FormGroup> 
                <FormGroup className="d-flex flex-row"> 
                  <Text>Direccion</Text>
                  <Input name="direccion" onChange={(e) => actualizaDato(e) } value={recibo.direccion}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <Text>Monto</Text>
                  <Input id="form-monto" name="monto" onChange={(e) => actualizaDato(e) } value={recibo.monto}></Input>
                </FormGroup>
            </Page>
        </Document>
    </Form>
   )
}

export default RegistroRecibo;