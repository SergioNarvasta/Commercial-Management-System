import { useState } from "react";
import { Button, Form, FormGroup,Input } from "reactstrap";

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
    const response = await fetch("api/producto/RegistrarPrd",{
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
                <FormGroup className="d-flex flex-row fg-tit">
                  <label>Codigo</label>
                  <Input id="form-titulo" name="codProducto" onChange={(e) => actualizaDato(e) } value={producto.codProducto}></Input>
               </FormGroup>
                <div className="d-flex flex-row fg-box2">
                   <FormGroup className="d-flex flex-row">
                     <label>Nombre</label>
                     <Input id="form-nroDoc" name="nombre" onChange={(e) => actualizaDato(e) } value={producto.nombre}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <label>Nombre Cientifico</label>
                     <Input id="form-tipodoc" name="nombreCientifico" onChange={(e) => actualizaDato(e) } value={producto.nombreCientifico}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <label>Concentracion</label>
                     <Input name="concentracion" onChange={(e) => actualizaDato(e) } value={producto.concentracion}></Input>
                 </FormGroup>
                </div>
                <FormGroup className="d-flex flex-row">
                  <label>Presentacion</label>
                  <Input id="form-desc" name="presentacion" onChange={(e) => actualizaDato(e) } value={producto.presentacion}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <label>Precio de Venta</label>
                  <Input id="form-desc" name="precioVenta" onChange={(e) => actualizaDato(e) } value={producto.precioVenta}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <label>Stock</label>
                  <Input id="form-nombres" name="stock" onChange={(e) => actualizaDato(e) } value={producto.stock}></Input>
                </FormGroup> 
                <FormGroup className="d-flex flex-row"> 
                  <label>Restriccion</label>
                  <Input name="restriccion" onChange={(e) => actualizaDato(e) } value={producto.restriccion}></Input>
                </FormGroup>
                <FormGroup className="d-flex flex-row">
                  <label>idLote</label>
                  <Input id="form-monto" name="idLote" onChange={(e) => actualizaDato(e) } value={producto.idLote}></Input>
                </FormGroup>  
    </Form>
   )
}

export default RegistroProducto;