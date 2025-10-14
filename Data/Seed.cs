using CazuelaChapina.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Data
{
    public static class Seed
    {
        /// <summary>
        /// Pobla la base con datos de ejemplo.
        /// - force=false: inserta solo si está vacío (idempotente).
        /// - force=true: intenta insertar aunque ya haya algo (evita duplicados con checks).
        /// </summary>
        public static async Task SeedAsync(AppDbContext db, bool force = false)
        {
            await db.Database.MigrateAsync();

            // ===== Sucursales =====
            if (force || !await db.Sucursales.AnyAsync())
            {
                db.Sucursales.AddRange(
                    new Sucursal { Nombre = "Central" },
                    new Sucursal { Nombre = "Zona 10" },
                    new Sucursal { Nombre = "Antigua" }
                );
                await db.SaveChangesAsync();
            }
            var sucursales = await db.Sucursales.ToListAsync();

            // ===== Materias Primas (10) =====
            if (force || !await db.MateriasPrimas.AnyAsync())
            {
                db.MateriasPrimas.AddRange(
                    new MateriaPrima { Nombre = "Masa maíz amarillo", Categoria = "masa", Unidad = "kg", PuntoCritico = 5 },
                    new MateriaPrima { Nombre = "Masa maíz blanco",  Categoria = "masa", Unidad = "kg", PuntoCritico = 5 },
                    new MateriaPrima { Nombre = "Masa arroz",         Categoria = "masa", Unidad = "kg", PuntoCritico = 5 },
                    new MateriaPrima { Nombre = "Hoja plátano",       Categoria = "hoja", Unidad = "unidad", PuntoCritico = 50 },
                    new MateriaPrima { Nombre = "Tusa de maíz",       Categoria = "hoja", Unidad = "unidad", PuntoCritico = 50 },
                    new MateriaPrima { Nombre = "Carne de cerdo",     Categoria = "proteina", Unidad = "kg", PuntoCritico = 3 },
                    new MateriaPrima { Nombre = "Pollo",              Categoria = "proteina", Unidad = "kg", PuntoCritico = 3 },
                    new MateriaPrima { Nombre = "Chipilín",           Categoria = "verdura",  Unidad = "kg", PuntoCritico = 2 },
                    new MateriaPrima { Nombre = "Elote molido",       Categoria = "grano",    Unidad = "kg", PuntoCritico = 5 },
                    new MateriaPrima { Nombre = "Panela",             Categoria = "endulzante", Unidad = "kg", PuntoCritico = 2 }
                );
                await db.SaveChangesAsync();
            }
            var materias = await db.MateriasPrimas.ToListAsync();

            // ===== Proveedores (5) =====
            if (force || !await db.Proveedores.AnyAsync())
            {
                db.Proveedores.AddRange(
                    new Proveedor { Nombre = "AgroMaíz" },
                    new Proveedor { Nombre = "Carnes del Valle" },
                    new Proveedor { Nombre = "Hojas Selectas" },
                    new Proveedor { Nombre = "Dulces Panela GT" },
                    new Proveedor { Nombre = "Granos del Altiplano" }
                );
                await db.SaveChangesAsync();
            }

            // ===== Inventario Saldos: cada materia x sucursal =====
            if (force || !await db.InventarioSaldos.AnyAsync())
            {
                foreach (var s in sucursales)
                {
                    foreach (var m in materias)
                    {
                        if (!await db.InventarioSaldos.AnyAsync(x => x.SucursalId == s.Id && x.MateriaPrimaId == m.Id))
                        {
                            db.InventarioSaldos.Add(new InventarioSaldo
                            {
                                SucursalId = s.Id,
                                MateriaPrimaId = m.Id,
                                Cantidad = 100,
                                CostoPromedio = m.Categoria == "proteina" ? 35 : 12
                            });
                        }
                    }
                }
                await db.SaveChangesAsync();
            }

            // ===== Tamales (~6) + Presentaciones (~18) =====
            if (force || !await db.Tamales.AnyAsync())
            {
                var tamales = new List<Tamal>
                {
                    new Tamal { Masa = MasaTamal.MaizAmarillo, Relleno = RellenoTamal.RecadoRojoCerdo, Envoltura = EnvolturaTamal.HojaPlatano, Picante = PicanteTamal.Suave, PrecioUnitario = 12 },
                    new Tamal { Masa = MasaTamal.MaizBlanco,  Relleno = RellenoTamal.NegroPollo,       Envoltura = EnvolturaTamal.HojaPlatano, Picante = PicanteTamal.Sin,   PrecioUnitario = 12 },
                    new Tamal { Masa = MasaTamal.Arroz,       Relleno = RellenoTamal.ChipilinVeg,      Envoltura = EnvolturaTamal.TusaMaiz,    Picante = PicanteTamal.Suave, PrecioUnitario = 11 },
                    new Tamal { Masa = MasaTamal.MaizAmarillo, Relleno = RellenoTamal.MezclaChuchito, Envoltura = EnvolturaTamal.TusaMaiz,    Picante = PicanteTamal.Chapin,PrecioUnitario = 13 },
                    new Tamal { Masa = MasaTamal.MaizBlanco,  Relleno = RellenoTamal.RecadoRojoCerdo, Envoltura = EnvolturaTamal.HojaPlatano, Picante = PicanteTamal.Sin,   PrecioUnitario = 12 },
                    new Tamal { Masa = MasaTamal.Arroz,       Relleno = RellenoTamal.NegroPollo,       Envoltura = EnvolturaTamal.HojaPlatano, Picante = PicanteTamal.Suave, PrecioUnitario = 12 }
                };
                db.Tamales.AddRange(tamales);
                await db.SaveChangesAsync();

                foreach (var t in await db.Tamales.ToListAsync())
                {
                    if (!await db.TamalPresentaciones.AnyAsync(x => x.TamalId == t.Id && x.Presentacion == TamalPresentacion.Unidad))
                        db.TamalPresentaciones.Add(new TamalPresentacionPrecio { TamalId = t.Id, Presentacion = TamalPresentacion.Unidad,      Precio = t.PrecioUnitario });

                    if (!await db.TamalPresentaciones.AnyAsync(x => x.TamalId == t.Id && x.Presentacion == TamalPresentacion.MediaDocena))
                        db.TamalPresentaciones.Add(new TamalPresentacionPrecio { TamalId = t.Id, Presentacion = TamalPresentacion.MediaDocena, Precio = Math.Round(t.PrecioUnitario * 6 * 0.94m, 2) });

                    if (!await db.TamalPresentaciones.AnyAsync(x => x.TamalId == t.Id && x.Presentacion == TamalPresentacion.Docena))
                        db.TamalPresentaciones.Add(new TamalPresentacionPrecio { TamalId = t.Id, Presentacion = TamalPresentacion.Docena,      Precio = Math.Round(t.PrecioUnitario * 12 * 0.89m, 2) });
                }
                await db.SaveChangesAsync();
            }

            // ===== Bebidas (8) =====
            if (force || !await db.Bebidas.AnyAsync())
            {
                db.Bebidas.AddRange(
                    new Bebida { Tipo = TipoBebida.AtolElote,  Endulzante = Endulzante.Panela,      Topping = Topping.Ninguno,         Tamano = TamanoBebida.Oz12,   Precio = 15 },
                    new Bebida { Tipo = TipoBebida.AtolElote,  Endulzante = Endulzante.Panela,      Topping = Topping.Canela,          Tamano = TamanoBebida.Litro1, Precio = 40 },
                    new Bebida { Tipo = TipoBebida.AtoleShuco, Endulzante = Endulzante.SinAzucar,   Topping = Topping.Ninguno,         Tamano = TamanoBebida.Oz12,   Precio = 14 },
                    new Bebida { Tipo = TipoBebida.AtoleShuco, Endulzante = Endulzante.Miel,        Topping = Topping.RalladuraCacao,  Tamano = TamanoBebida.Litro1, Precio = 42 },
                    new Bebida { Tipo = TipoBebida.Pinol,      Endulzante = Endulzante.Panela,      Topping = Topping.Ninguno,         Tamano = TamanoBebida.Oz12,   Precio = 16 },
                    new Bebida { Tipo = TipoBebida.Pinol,      Endulzante = Endulzante.Miel,        Topping = Topping.Malvaviscos,     Tamano = TamanoBebida.Litro1, Precio = 44 },
                    new Bebida { Tipo = TipoBebida.CacaoBatido,Endulzante = Endulzante.Panela,      Topping = Topping.RalladuraCacao,  Tamano = TamanoBebida.Oz12,   Precio = 18 },
                    new Bebida { Tipo = TipoBebida.CacaoBatido,Endulzante = Endulzante.SinAzucar,   Topping = Topping.Ninguno,         Tamano = TamanoBebida.Litro1, Precio = 48 }
                );
                await db.SaveChangesAsync();
            }

            // ===== Recetas (para cada tamal y bebida) =====
            if (force || !await db.Recetas.AnyAsync())
            {
                var masaAmarilla = materias.First(x => x.Nombre == "Masa maíz amarillo");
                var masaBlanca   = materias.First(x => x.Nombre == "Masa maíz blanco");
                var masaArroz    = materias.First(x => x.Nombre == "Masa arroz");
                var hojaPlatano  = materias.First(x => x.Nombre == "Hoja plátano");
                var tusaMaiz     = materias.First(x => x.Nombre == "Tusa de maíz");
                var cerdo        = materias.First(x => x.Nombre == "Carne de cerdo");
                var pollo        = materias.First(x => x.Nombre == "Pollo");
                var chipilin     = materias.First(x => x.Nombre == "Chipilín");
                var elote        = materias.First(x => x.Nombre == "Elote molido");
                var panela       = materias.First(x => x.Nombre == "Panela");

                foreach (var t in await db.Tamales.ToListAsync())
                {
                    if (!await db.Recetas.AnyAsync(r => r.TipoProducto == TipoProductoLinea.Tamal && r.ProductoId == t.Id))
                    {
                        var receta = new Receta { TipoProducto = TipoProductoLinea.Tamal, ProductoId = t.Id };
                        db.Recetas.Add(receta);
                        await db.SaveChangesAsync();

                        var masa = t.Masa switch
                        {
                            MasaTamal.MaizAmarillo => masaAmarilla,
                            MasaTamal.MaizBlanco   => masaBlanca,
                            MasaTamal.Arroz        => masaArroz,
                            _                      => masaArroz
                        };
                        var envol = t.Envoltura == EnvolturaTamal.HojaPlatano ? hojaPlatano : tusaMaiz;
                        var prot = t.Relleno switch
                        {
                            RellenoTamal.RecadoRojoCerdo => cerdo,
                            RellenoTamal.NegroPollo      => pollo,
                            RellenoTamal.ChipilinVeg     => chipilin,
                            RellenoTamal.MezclaChuchito  => cerdo,
                            _                            => cerdo
                        };

                        db.RecetaItems.AddRange(
                            new RecetaItem { RecetaId = receta.Id, MateriaPrimaId = masa.Id, CantidadPorUnidad = 0.25m, Unidad = "kg" },
                            new RecetaItem { RecetaId = receta.Id, MateriaPrimaId = envol.Id, CantidadPorUnidad = 1m,    Unidad = "unidad" },
                            new RecetaItem { RecetaId = receta.Id, MateriaPrimaId = prot.Id,  CantidadPorUnidad = 0.15m, Unidad = "kg" }
                        );
                        await db.SaveChangesAsync();
                    }
                }

                foreach (var b in await db.Bebidas.ToListAsync())
                {
                    if (!await db.Recetas.AnyAsync(r => r.TipoProducto == TipoProductoLinea.Bebida && r.ProductoId == b.Id))
                    {
                        var receta = new Receta { TipoProducto = TipoProductoLinea.Bebida, ProductoId = b.Id };
                        db.Recetas.Add(receta);
                        await db.SaveChangesAsync();

                        db.RecetaItems.AddRange(
                            new RecetaItem { RecetaId = receta.Id, MateriaPrimaId = elote.Id,  CantidadPorUnidad = 0.20m, Unidad = "kg" },
                            new RecetaItem { RecetaId = receta.Id, MateriaPrimaId = panela.Id, CantidadPorUnidad = b.Endulzante == Endulzante.SinAzucar ? 0m : 0.02m, Unidad = "kg" }
                        );
                        await db.SaveChangesAsync();
                    }
                }
            }

            // ===== Combos (3) + items =====
            if (force || !await db.Combos.AnyAsync())
            {
                var t1 = await db.Tamales.FirstAsync();
                var b1 = await db.Bebidas.FirstAsync();

                var familiar   = new Combo { Nombre = "Fiesta Patronal",    Descripcion = "Docena surtida + 2 jarros", Precio = 200, EsEditableEnProduccion = false };
                var eventos    = new Combo { Nombre = "Madrugada del 24",   Descripcion = "3 docenas + 4 jarros + termo", Precio = 600, EsEditableEnProduccion = false };
                var estacional = new Combo { Nombre = "Combo Estacional",   Descripcion = "Varía por temporada", Precio = 220, EsEditableEnProduccion = true };

                db.Combos.AddRange(familiar, eventos, estacional);
                await db.SaveChangesAsync();

                db.ComboItems.AddRange(
                    new ComboItem { ComboId = familiar.Id,   TipoProducto = TipoProductoLinea.Tamal,  TamalId = t1.Id, Cantidad = 12 },
                    new ComboItem { ComboId = familiar.Id,   TipoProducto = TipoProductoLinea.Bebida, BebidaId = b1.Id, Cantidad = 2 },

                    new ComboItem { ComboId = eventos.Id,    TipoProducto = TipoProductoLinea.Tamal,  TamalId = t1.Id, Cantidad = 36 },
                    new ComboItem { ComboId = eventos.Id,    TipoProducto = TipoProductoLinea.Bebida, BebidaId = b1.Id, Cantidad = 4 },

                    new ComboItem { ComboId = estacional.Id, TipoProducto = TipoProductoLinea.Tamal,  TamalId = t1.Id, Cantidad = 12 },
                    new ComboItem { ComboId = estacional.Id, TipoProducto = TipoProductoLinea.Bebida, BebidaId = b1.Id, Cantidad = 2 }
                );
                await db.SaveChangesAsync();
            }

            // ===== Lotes de cocción (3) =====
            if (force || !await db.LotesCoccion.AnyAsync())
            {
                var t = await db.Tamales.FirstAsync();
                db.LotesCoccion.AddRange(
                    new LoteCoccion { SucursalId = sucursales[0].Id, TamalId = t.Id, CantidadProgramada = 50, Estado = EstadoLote.Pendiente },
                    new LoteCoccion { SucursalId = sucursales[1].Id, TamalId = t.Id, CantidadProgramada = 80, Estado = EstadoLote.EnCoccion, Inicio = DateTime.UtcNow.AddMinutes(-30) },
                    new LoteCoccion { SucursalId = sucursales[2].Id, TamalId = t.Id, CantidadProgramada = 40, Estado = EstadoLote.Finalizado, Inicio = DateTime.UtcNow.AddHours(-2), Fin = DateTime.UtcNow.AddHours(-1) }
                );
                await db.SaveChangesAsync();
            }

            // ===== Ventas (10) con descuento de inventario por recetas =====
            if (force || !await db.Ventas.AnyAsync())
            {
                var rnd = new Random(7);
                var tamales = await db.Tamales.ToListAsync();
                var bebidas = await db.Bebidas.ToListAsync();
                var suc = sucursales[0];

                for (int i = 0; i < 10; i++)
                {
                    var itemT = tamales[rnd.Next(tamales.Count)];
                    var itemB = bebidas[rnd.Next(bebidas.Count)];
                    var cantT = rnd.Next(1, 5);
                    var cantB = rnd.Next(1, 3);

                    var venta = new Venta
                    {
                        SucursalId = suc.Id,
                        MedioPago = MedioPago.Efectivo,
                        Fecha = DateTime.UtcNow.AddMinutes(-rnd.Next(0, 300)),
                        Items = new List<VentaItem>
                        {
                            new VentaItem {
                                TipoProducto = TipoProductoLinea.Tamal, TamalId = itemT.Id, Cantidad = cantT,
                                PrecioUnitario = itemT.PrecioUnitario, TotalLinea = itemT.PrecioUnitario * cantT,
                                Picante = itemT.Picante
                            },
                            new VentaItem {
                                TipoProducto = TipoProductoLinea.Bebida, BebidaId = itemB.Id, Cantidad = cantB,
                                PrecioUnitario = itemB.Precio, TotalLinea = itemB.Precio * cantB,
                                TamanoBebida = itemB.Tamano, TipoBebida = itemB.Tipo
                            }
                        }
                    };

                    // Totales
                    venta.Subtotal = venta.Items.Sum(x => x.TotalLinea);
                    venta.Impuestos = Math.Round(venta.Subtotal * 0.12m, 2);
                    venta.Total = venta.Subtotal + venta.Impuestos;

                    db.Ventas.Add(venta);
                    await db.SaveChangesAsync();

                    // Descontar inventario por recetas
                    foreach (var it in venta.Items)
                    {
                        var idProd = it.TamalId ?? it.BebidaId ?? it.ComboId ?? 0;
                        await new InventoryService(db).DescontarPorRecetaAsync(it.TipoProducto, idProd, venta.SucursalId, it.Cantidad, $"SEED-VENTA:{venta.Id}");
                    }
                }
            }
        }
    }
}
