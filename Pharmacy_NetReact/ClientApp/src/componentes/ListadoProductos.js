import { useEffect, useState } from "react";
import { Button, Card, CardBody, CardHeader, Col, Container, Row} from "reactstrap";
import TablaProductos from "./TablaProductos";

const ListadoProductos = () =>{
  const [productos,setProductos] = useState([]);
  

  const ListarProductos = async () => {
    const response = await fetch("api/producto/ListadoPrd");

    if(response.ok){
      const data = await response.json();
      setProductos(data);
      console.log(data);
    }else{
      console.log("Error al listar (/api/producto/ListadoPrd)")
    }
  }
  useEffect(()=>{
    ListarProductos()
  },[])

const IrRegistro = () =>{
  document.getElementById("LnReg").click();
}
 
  return (
    <Container>
      <Row className="mt-5">
        <Col>
        <Card>
          <CardHeader>
            <h5>Listado de Productos </h5>
          </CardHeader>
          <CardBody>
            <Button id="btn_new" onClick={IrRegistro}> Nuevo Recibo</Button>
            <hr/><hr/>
            <TablaProductos data={productos}></TablaProductos>
          </CardBody>
        </Card>
        </Col>
      </Row>
    </Container>
  )
}

export default ListadoProductos;