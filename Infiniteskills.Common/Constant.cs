namespace Infiniteskills.Common
{
    public class TablaConstante
    {
        public const string CLIENTE = "0001";
        public const string PROVEEDOR = "0010";
        public const string PRODUCTO = "0002";
        public const string EMPRESA = "0003";
        public const string SUCURSAL = "0004";
        public const string PERSONAL = "0005";
        public const string PEDIDO = "0006";
        public const string INVENTARIO = "0007";
    }
    public class ParametrosSistema
    {
        public const string IMPUESTO = "18";
        public const decimal VALOR_IMPUESTO = 18;
    }

    public class DireccionConstant
    {
        public const string FISCAL = "1";
        public const string NO_FISCAL = "0";
    }

    public class TipoProveedorConstant
    {
        public const string PROVEEDOR = "P";
        public const string CLIENTE = "C";
    }
    public class AppConstante
    {
        public static readonly string ROOT_IMAGES_PATH = "~/content/images";
        public static readonly string ENABLED_PATH = "/enabled";
        public static readonly string DISABLED_PATH = "/disabled";

        public static readonly string ENABLED_TBR_IMAGES_PATH = ROOT_IMAGES_PATH + "/toolbar" + ENABLED_PATH;
        public static readonly string DISABLED_TBR_IMAGES_PATH = ROOT_IMAGES_PATH + "/toolbar" + DISABLED_PATH;
    }
    public class EstadoConstante
    {
        public static readonly string ACTIVO = "A";
        public static readonly string INACTIVO = "I";
    }

    public class EstadoNumericoConstante
    {
        public static readonly string ACTIVO = "1";
        public static readonly string INACTIVO = "0";
    }

    public class LetraEstadoConstante
    {
        public static readonly string ACTIVO = "ACTIVO";
        public static readonly string INACTIVO = "INACTIVO";
    }
    public class HabilitadoConstante
    {
        public static readonly string HABILITADO = "1";
        public static readonly string DESHABILITADO = "0";
    }
    public class EstadoPedido
    {
        public static readonly string ACTIVO = "ACTIVO";
        public static readonly string ANULADO = "ANULADO";
    }
    public class LetraConstante
    {
        public static readonly string A = "A";
        public static readonly string B = "B";
        public static readonly string C = "C";
        public static readonly string D = "D";
        public static readonly string S = "S";
        public static readonly string N = "N";
        public static readonly string I = "I";
        public static readonly string P = "P";
    }

    public struct OperacionConstant
    {
        public static readonly string INGRESO = "I";
        public static readonly string SALIDA = "S";
        public static readonly string TRANSFERENCIA = "T";
        public static readonly string VENTA = "T";
    }

    public struct TipoOperacionConstant
    {
        public static readonly string ORDEN_COMPRA = "0001";
        public static readonly string TRANSFERENCIA = "0003";
    }



    public class EstadoConstantes
    {
        public static readonly string ACTIVO = "1";
        public static readonly string INACTIVO = "0";
    }

    public class DigitosConstante
    {
        public const string CERO = "0";
        public const string UNO = "1";
        public const string DOS = "2";
        public const string TRES = "3";
        public const string CUATRO = "4";
        public const string CINCO = "5";
        public const string SEIS = "6";
        public const string SIETE = "7";
        public const string OCHO = "8";
        public const string NUEVE = "9";
        public const string DIEZ = "10";
    }
    public class ButtonMenuBarFontConstant
    {
        public const string NEW = "glyphicon glyphicon-plus";
        public const string EDIT = "glyphicon glyphicon-edit";
        public const string COPY = "glyphicon glyphicon-copy";
        public const string DELETE = "glyphicon glyphicon-trash";
        public const string SEARCH = "glyphicon glyphicon-search";
        public const string SAVE = "glyphicon glyphicon-floppy-disk";
        public const string EXIT = "glyphicon glyphicon-arrow-left";
        public const string CANCEL = "glyphicon glyphicon-ban-circle";
        public const string ASIGNAR = "glyphicon glyphicon-hand-right";
        public const string APROBAR = "glyphicon glyphicon-thumbs-up";
        public const string DESAPROBAR = "glyphicon glyphicon-thumbs-down";
        public const string PREVIEW = "glyphicon glyphicon-eye-open";
        public const string PRINT = "glyphicon glyphicon-print";
        public const string IMPORT = "glyphicon glyphicon-open";
    }

    public class ButtonMenuBarValueConstant
    {
        public const string NEW = "Nuevo";
        public const string COPY = "Copiar";
        public const string EDIT = "Editar";
        public const string DELETE = "Eliminar";
        public const string PREVIEW = "Vista Previa";
        public const string PRINT = "Imprimir";
        public const string SAVE = "Guardar";
        public const string SAVEEXIT = "Guardar y Salir";
        public const string SAVENEW = "Guardar y Nuevo";
        public const string CANCEL = "Cancelar";
        public const string EXPORT_PDF = "Exportar PDF";
        public const string EXPORT_XLS = "Exportar Excel";
        public const string IMPORTAR_XLS = "Importar";
        public const string EXIT = "Salir";
        public const string ASIGNAR = "Asignar";
        public const string APROBAR = "Aprobar";
        public const string DESAPROBAR = "Desaprobar";
    }
    public class ButtonMenuBarNameConstant
    {
        public const string NEW = "_MB_NEW";
        public const string COPY = "_MB_COPY";
        public const string EDIT = "_MB_EDIT";
        public const string DELETE = "_MB_DEL";
        public const string PREVIEW = "_MB_PREVI";
        public const string PRINT = "_MB_PRN";
        public const string SAVE = "_MB_SAVE";
        public const string SAVEEXIT = "_MB_SAVE_EXIT";
        public const string SAVENEW = "_MB_SAVNEW";
        public const string CANCEL = "_MB_CANCEL";
        public const string EXPORT_PDF = "_MB_EXPORTPDF";
        public const string EXPORT_XLS = "_MB_EXPORTXLS";
        public const string IMPORTAR_XLS = "_MB_IMPORTXLS";
        public const string EXIT = "_MB_EXIT";
        public const string IMPORT = "_MB_IMPORT";
        public const string UPLOAD = "_MB_UPLOAD";
        public const string DOWNLOAD = "_MB_DOWNLOAD";
        public const string ASIGNAR = "_MB_ASIGNAR";
        public const string APROBAR = "_MB_APROBAR";
        public const string DESAPROBAR = "_MB_DESAPROBAR";
        public const string ELEGIR = "_MB_ELEGIR";
        public const string PRESUPUESTO = "_MB_PRESUPUESTO";
        public const string APERTURAR = "_MB_APERTURAR";
        public const string CERRAR = "_MB_CERRAR";
        public const string AMPLIACION = "_MB_AMPLIACION";
        public const string REBAJA = "_MB_REBAJA";
        public const string ENVIAR_SIAF = "_MB_SENDSIAF";
    }

  


    public class SqlOperatorConstant
    {
        public const string AND = " AND ";
        public const string OR = " OR ";
        public const string EQUALS = " = ";
        public const string NOT_EQUALS = " <> ";
        public const string IN = " IN ";
        public const string NOTIN = " NOT IN ";
        public const string IS = " IS ";
        public const string IS_NULL = " IS NULL ";
        public const string LIKE = " LIKE ";
    }
    public class SqlParameterPrefix
    {
        public const string AT = "@";
    }

    public class VariableSesionConstante
    {
        public const string USUARIO_ID = "_userId";
        public const string USUARIO_LOGON = "_userLogon";
        public const string USUARIO_NOMBRE = "_userName";
        public const string USUARIO_EMPRESA = "_userEmpresa";
        public const string USUARIO_SUCURSAL = "_userSucursal";
        public const string USUARIO_ALMACEN_ID = "_userAlmacenId";
        public const string USUARIO_ALMACEN = "_userAlmacen";
        public const string PERIODO_EMPRESA = "_periodoEmpresa";
        public const string PERIODO = "_periodoId";
        public const string PERIODO_NOMBRE = "_periodoNombre";
    }
}
