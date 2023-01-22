import { Button, Table } from "reactstrap";

const TablaProductos = ({data}) =>{
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>CodProducto</th>
                    <th>Nombre</th>
                    <th>NombreCientifico</th>
                    <th>Concentracion</th>
                    <th>Presentacion</th>
                    <th>PrecioVenta</th>
                    <th>Stock</th>
                    <th>Restriccion</th>
                    <th>IdLote</th>
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
                    <tr key={item.idProducto} >
                        <td>{item.codProducto}</td>
                        <td>{item.nombre     }</td>
                        <td>{item.nombreCientifico}</td>
                        <td>{item.concentracion     }</td>
                        <td>{item.presentacion      }</td>
                        <td>{item.precioVenta}</td>
                        <td>{item.stock    }</td>
                        <td>{item.restriccion  }</td>
                        <td>{item.idLote}</td>
                        <td> <Button color="primary" size="sm">Imprimir</Button></td>
                    </tr>                    
                    ))
                )
               }
            </tbody>
        </Table>
    )
}
export default TablaProductos;