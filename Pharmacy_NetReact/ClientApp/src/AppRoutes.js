import RegistroRecibo from "./componentes/RegistroRecibo";
import ListadoRecibos from "./componentes/ListadoRecibos";

const AppRoutes = [

  {
    path: '/registro-recibo',
    element: <RegistroRecibo />
  },
  {
    path: '/listado-recibo',
    element: <ListadoRecibos />
  }
];

export default AppRoutes;
