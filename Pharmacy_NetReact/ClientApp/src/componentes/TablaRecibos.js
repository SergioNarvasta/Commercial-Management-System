import { Button, Table } from "reactstrap";

const TablaRecibos = ({data}) =>{
    //const [verRecibo,setVerRecibo]=useState(false);
    //const [infoRecibo,setInfoRecibo]=useState([]);

    /*const mostrarRecibo = (recibo) =>{
        setVerRecibo(true);
        setInfoRecibo(recibo);
    }*/
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>NroDoc      </th>
                    <th>Titulo      </th>
                    <th>Descripcion </th>
                    <th>Moneda      </th>
                    <th>Monto       </th>
                    <th>TipoDoc     </th>
                    <th>Direccion   </th>
                    <th>Nombres     </th>
                    <th>Accion</th>
                </tr>
            </thead>
            <tbody>
               {
                (data.length < 1) ?(
                    <tr>
                        <td colSpan="8">Sin registros</td>
                    </tr>
                ):(
                    data.map((item) =>(
                    <tr key={item.id} >
                        <td>{item.nroDoc}</td>
                        <td>{item.titulo     }</td>
                        <td>{item.descripcion}</td>
                        <td>{item.moneda     }</td>
                        <td>{item.monto      }</td>
                        <td>{item.tipoDoc    }</td>
                        <td>{item.direccion  }</td>
                        <td>{item.nombres}</td>
                        <td> <Button color="primary" size="sm">Imprimir</Button></td>
                    </tr>                    
                    ))
                )
               }
            </tbody>
        </Table>
    )
}
export default TablaRecibos;