import { useState } from "react";
import { Button, Form, FormGroup,Input } from "reactstrap";
import {Document,Page,Text} from "@react-pdf/renderer";

const modeloProducto = {  
  idProducto : 0,
  codProducto :"",
  nombre :"",
  nombreCientifico:"",
  concentracion :0,
  presentacion  : "",
  precioVenta:0.00,
  stock :0,
  restriccion:0,
  idLote :0
}

const RegistroProducto = () =>{
   const [producto,setproducto]= useState(modeloProducto);
   //const [verRecibo,setVerRecibo]=useState(false);
   //const [infoRecibo,setInfoRecibo]=useState([]);
        
   /*const mostrarRecibo = (producto) =>{
    setVerRecibo(true);
    setInfoRecibo(producto);
   }*/
   const actualizaDato = (e) => {
     console.log(e.target.name+" : "+ e.target.value);
     setproducto(
        {
            ...producto,
            [e.target.name] : e.target.value
        }
     )
   }
   const enviarDatos = () => {
        guardarProducto(producto)
    
   }
   const guardarProducto = async (producto) =>{
    console.log(producto);
    const response = await fetch("/api/producto/RegistrarPrd",{
      method:'POST',
      headers: {
         'Content-Type':'application/json;charset=utf-8'
      },
      body:JSON.stringify(producto)
    })
    if(response.ok){
        console.log("Registrado con exito");
        document.getElementById("LnList").click();
    }else{
      console.log("Ocurrio un error");
    }
   }

   return(   
    <Form>
        <h2 className="text-center">Registra Productos</h2> <hr/>
           
        <Button id="btn_gen" onClick={enviarDatos}>Registrar</Button>
        <Document>
            <Page size ="A4">
                <FormGroup className="d-flex flex-row fg-tit">
                  <Text>Codigo</Text>
                  <Input id="form-titulo" name="codProducto" onChange={(e) => actualizaDato(e) } value={producto.codProducto}></Input>
               </FormGroup>
                <div className="d-flex flex-row fg-box2">
                   <FormGroup className="d-flex flex-row">
                     <Text>Nombre</Text>
                     <Input id="form-nroDoc" name="nombre" onChange={(e) => actualizaDato(e) } value={producto.nombre}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <Text>Nombre Cientifico</Text>
                     <Input id="form-tipodoc" name="nombreCientifico" onChange={(e) => actualizaDato(e) } value={producto.nombreCientifico}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <Text>Concentracion</Text>
                     <Input name="concentracion" onChange={(e) => actualizaDato(e) } value={producto.concentracion}></Input>
                 </FormGroup>
                </div>
                <FormGroup className="d-flex flex-row">
                  <Text>Presentacion</Text>
                  <Input id="form-desc" name="presentacion" onChange={(e) => actualizaDato(e) } value={producto.presentacion}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <Text>Precio de Venta</Text>
                  <Input id="form-desc" name="precioVenta" onChange={(e) => actualizaDato(e) } value={producto.precioVenta}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <Text>Stock</Text>
                  <Input id="form-nombres" name="stock" onChange={(e) => actualizaDato(e) } value={producto.stock}></Input>
                </FormGroup> 
                <FormGroup className="d-flex flex-row"> 
                  <Text>Restriccion</Text>
                  <Input name="restriccion" onChange={(e) => actualizaDato(e) } value={producto.restriccion}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <Text>idLote</Text>
                  <Input id="form-monto" name="idLote" onChange={(e) => actualizaDato(e) } value={producto.idLote}></Input>
                </FormGroup>
            </Page>
        </Document>
    </Form>
   )
}

export default RegistroProducto;