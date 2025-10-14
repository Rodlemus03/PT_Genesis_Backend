namespace CazuelaChapina.API.Models
{
    public enum MasaTamal { MaizAmarillo = 1, MaizBlanco = 2, Arroz = 3 }
    public enum RellenoTamal { RecadoRojoCerdo = 1, NegroPollo = 2, ChipilinVeg = 3, MezclaChuchito = 4 }
    public enum EnvolturaTamal { HojaPlatano = 1, TusaMaiz = 2 }
    public enum PicanteTamal { Sin = 0, Suave = 1, Chapin = 2 }

    public enum TamalPresentacion { Unidad = 1, MediaDocena = 6, Docena = 12 }

    public enum TipoBebida { AtolElote = 1, AtoleShuco = 2, Pinol = 3, CacaoBatido = 4 }
    public enum Endulzante { SinAzucar = 0, Panela = 1, Miel = 2 }
    public enum Topping { Ninguno = 0, Malvaviscos = 1, Canela = 2, RalladuraCacao = 3 }
    public enum TamanoBebida { Oz12 = 1, Litro1 = 2 }

    public enum TipoMovimientoInventario { Entrada = 1, Salida = 2, Merma = 3, Ajuste = 4, ConsumoReceta = 5 }
    public enum MetodoCosto { PromedioPonderado = 1 }

    public enum TipoProductoLinea { Tamal = 1, Bebida = 2, Combo = 3 }
    public enum EstadoLote { Pendiente = 0, EnCoccion = 1, Finalizado = 2, Cancelado = 3 }

    public enum MedioPago { Efectivo = 1, Tarjeta = 2, Transferencia = 3, Mixto = 4 }
}
