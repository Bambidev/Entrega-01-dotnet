using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Utiles;
using SGE.Aplicacion.Validadores;
using SGE.Repositorio;


SistemaSQlite.Inicializar();

//CUIDADO AL EJECUTAR MAS DE UNA VEZ YA QUE SE REPETIRAN LAS ALTAS

//REPOSITORIOS DE LA APLICACION
IExpedienteRepositorio repoExpedientes = new RepositorioExpedienteSQlite();
ITramiteRepositorio repoTramites = new RepositorioTramiteSQlite();
IUsuarioRepositorio repoUsers = new RepositorioUsuariosSQlite();
//SERVICIO AUTORIZACION, 
IServicioAutorizacion auth = new ServicioAutorizacion(repoUsers);

//prueba casos de uso de usuarios
UsuarioValidador validadoUsers = new UsuarioValidador();
GeneradorHash generador = new GeneradorHash();

CasoDeUsoRegistrar reg = new CasoDeUsoRegistrar(repoUsers, validadoUsers, generador);
//como es el primer usuario el de abajo sera el admin y tendra todos los permisos automaticamente
Usuario usuarioPrueba = new Usuario("pepe", "sand", "hola123@gmail.com", "contra1234");
reg.Ejecutar(usuarioPrueba);

CasoDeUsoLogin log = new CasoDeUsoLogin(repoUsers, generador);
Console.WriteLine(log.Ejecutar(usuarioPrueba.Correo, "contra123")); //true o false si deja logear o no

//este otro usuario como se acaba de registrar y no es el primero solo tendra permiso de lectura
Usuario usuarioPrueba2 = new Usuario("juan", "perez", "juan@gmail.com", "asd234");
reg.Ejecutar(usuarioPrueba2);

//VALIDADORES
ExpedienteValidador validadorExpedientes = new ExpedienteValidador();
TramiteValidador validadorTramites = new TramiteValidador();


// -- EXPEDIENTES PARA PROBAR
//ORDEN CONSTRUCTOR: (string caratula, EstadoExpediente estado)
Expediente expediente1 = new Expediente("Caratula1", EstadoExpediente.RecienIniciado);
Expediente expediente2 = new Expediente("Caratula2", EstadoExpediente.ParaResolver);
Expediente expediente3 = new Expediente("Caratula3", EstadoExpediente.ConResolucion);

//-- TRAMITES PARA PROBAR
//ORDEN CONSTRUCTOR: (int idExpediente, EtiquetaTramite etiqueta, String contenido)
Tramite tramite1 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "Contenido1");
Tramite tramite2 = new Tramite(2, EtiquetaTramite.PaseAEstudio, "Contenido2");


//ALTA DE EXPEDIENTE 1 y 2
CasoDeUsoExpedienteAlta casoAltaExp = new CasoDeUsoExpedienteAlta(repoExpedientes, auth, validadorExpedientes);
casoAltaExp.Ejecutar(expediente1, 1); //id 1, sino no da permiso
casoAltaExp.Ejecutar(expediente2, 1);

//MODIFICACION EXPEDIENTE 1
CasoDeUsoExpedienteModificacion casoModExp = new CasoDeUsoExpedienteModificacion(auth, repoExpedientes, validadorExpedientes);
casoModExp.Ejecutar(1, expediente3, 1);

//LISTAR EXPEDIENTES
CasoDeUsoListarExpedientes casoListarExp = new CasoDeUsoListarExpedientes(repoExpedientes);
List<Expediente> expedientes = casoListarExp.Ejecutar();
foreach (Expediente ex in expedientes)
{
    Console.WriteLine(ex.ToString());
}

//SERVICIO ACTUALIZACION AUTOMATICA
EspecificacionCambioEstado especificacion = new EspecificacionCambioEstado(repoExpedientes);
ServicioActualizacionEstado servicioAct = new ServicioActualizacionEstado(repoExpedientes, repoTramites, especificacion);

//ALTAS DE TRAMITE 1 y 2
CasoDeUsoTramiteAlta casoAltaTram = new CasoDeUsoTramiteAlta(repoTramites, validadorTramites, auth, servicioAct);
// (idTRamite, idEjecutor)
casoAltaTram.Ejecutar(tramite1, 1);
casoAltaTram.Ejecutar(tramite2, 1);

//MODIFICACION TRAMITE 2
Tramite tramite3 = new Tramite(2, EtiquetaTramite.Despacho, "Contenido del t2 modificado");
CasoDeUsoTramiteModificacion casoModTram = new CasoDeUsoTramiteModificacion(auth, repoTramites, validadorTramites, servicioAct);
// (idTramite, Tramite, idEjecutor)
casoModTram.Ejecutar(tramite3, 1);

//-- CONSULTA EXPEDIENTE Y TODOS SUS TRAMITES
//tramite adicional para el expediente 2
Tramite otroTramiteMas = new Tramite(2, EtiquetaTramite.Resolucion, "este es el ultimo tramite");
casoAltaTram.Ejecutar(otroTramiteMas, 1);

CasoDeUsoConsultaExpediente casoConsultaExpedientes = new CasoDeUsoConsultaExpediente(repoExpedientes);
Expediente e = casoConsultaExpedientes.Ejecutar(2);
foreach (Tramite t in e.listaTramites)
{
    Console.WriteLine(t.ToString());
}

//CONSULTA TODOS LOS TRAMITES DE UNA ETIQUETA
CasoDeUsoConsultaTramitesEtiqueta casoTramitesEtiqueta = new CasoDeUsoConsultaTramitesEtiqueta(repoTramites);
List<Tramite> tramitesEtiqueta = casoTramitesEtiqueta.Ejecutar(EtiquetaTramite.Resolucion);
foreach (Tramite t in tramitesEtiqueta)
{
    Console.WriteLine(t.ToString());
}

//BAJA DE UN EXPEDIENTE Y SUS TRAMITES ASOCIADOS
//ELIMINAMOS EL EXPEDIENTE 2, QUE TIENE ASOCIADOS LOS TRAMITES ID 2 Y ID 3 QUE AGREGAMOS ANTERIORMENTE
CasoDeUsoExpedienteBaja casoBajaExp = new CasoDeUsoExpedienteBaja(repoExpedientes, repoTramites, auth);
casoBajaExp.Ejecutar(2, 1);






