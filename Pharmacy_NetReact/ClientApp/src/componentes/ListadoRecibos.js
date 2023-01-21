import { useEffect, useState } from "react";
import { Button, Card, CardBody, CardHeader, Col, Container, Row} from "reactstrap";
import TablaRecibos from "./TablaRecibos";

const ListadoRecibos = () =>{
  const [recibos,setRecibos] = useState([]);
  

  const ListarRecibos = async () => {
    const response = await fetch("/api/receipt/Listado");

    if(response.ok){
      const data = await response.json();
      setRecibos(data);
      //console.log(data);
    }else{
      console.log("Error al listar (/api/receipt/Listado)")
    }
  }
  useEffect(()=>{
    ListarRecibos()
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
            <h5>Listado de Recibos</h5>
          </CardHeader>
          <CardBody>
            <Button id="btn_new" onClick={IrRegistro}> Nuevo Recibo</Button>
            <hr/><hr/>
            <TablaRecibos data={recibos}></TablaRecibos>
          </CardBody>
        </Card>
        </Col>
      </Row>
    </Container>
  )
}

export default ListadoRecibos;