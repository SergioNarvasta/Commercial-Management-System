import RegistroProducto from "./componentes/RegistroProducto";
import ListadoProductos from "./componentes/ListadoProductos";

const AppRoutes = [

  {
    path: '/registro-producto',
    element: <RegistroProducto />
  },
  {
    path: '/listado-producto',
    element: <ListadoProductos />
  }
];

export default AppRoutes;
