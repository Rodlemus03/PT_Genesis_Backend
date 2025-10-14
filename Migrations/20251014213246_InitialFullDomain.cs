using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CazuelaChapina.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialFullDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Endulzante = table.Column<int>(type: "INTEGER", nullable: false),
                    Topping = table.Column<int>(type: "INTEGER", nullable: false),
                    Tamano = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Sku = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EsEditableEnProduccion = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LlmLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Origen = table.Column<string>(type: "TEXT", nullable: false),
                    Prompt = table.Column<string>(type: "TEXT", nullable: false),
                    Respuesta = table.Column<string>(type: "TEXT", nullable: true),
                    HttpStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    LatenciaMs = table.Column<long>(type: "INTEGER", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlmLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Unidad = table.Column<string>(type: "TEXT", nullable: false),
                    PuntoCritico = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Mensaje = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: true),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: true),
                    LoteCoccionId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Contacto = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tamales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Masa = table.Column<int>(type: "INTEGER", nullable: false),
                    Relleno = table.Column<int>(type: "INTEGER", nullable: false),
                    Envoltura = table.Column<int>(type: "INTEGER", nullable: false),
                    Picante = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Sku = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecetaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriaPrimaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadPorUnidad = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    Unidad = table.Column<string>(type: "TEXT", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetaItems_MateriasPrimas_MateriaPrimaId",
                        column: x => x.MateriaPrimaId,
                        principalTable: "MateriasPrimas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaItems_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventarioMovimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MateriaPrimaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    CostoUnitario = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    CostoTotal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Referencia = table.Column<string>(type: "TEXT", nullable: true),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioMovimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioMovimientos_MateriasPrimas_MateriaPrimaId",
                        column: x => x.MateriaPrimaId,
                        principalTable: "MateriasPrimas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioMovimientos_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventarioSaldos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MateriaPrimaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    CostoPromedio = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    MetodoCosto = table.Column<int>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioSaldos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioSaldos_MateriasPrimas_MateriaPrimaId",
                        column: x => x.MateriaPrimaId,
                        principalTable: "MateriasPrimas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioSaldos_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Subtotal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Impuestos = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    MedioPago = table.Column<int>(type: "INTEGER", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComboId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    TamalId = table.Column<int>(type: "INTEGER", nullable: true),
                    BebidaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboItems_Bebidas_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "Bebidas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboItems_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboItems_Tamales_TamalId",
                        column: x => x.TamalId,
                        principalTable: "Tamales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LotesCoccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false),
                    TamalId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadProgramada = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadObtenida = table.Column<int>(type: "INTEGER", nullable: true),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Fin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotesCoccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotesCoccion_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotesCoccion_Tamales_TamalId",
                        column: x => x.TamalId,
                        principalTable: "Tamales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TamalPresentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TamalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Presentacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamalPresentaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TamalPresentaciones_Tamales_TamalId",
                        column: x => x.TamalId,
                        principalTable: "Tamales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    TamalId = table.Column<int>(type: "INTEGER", nullable: true),
                    BebidaId = table.Column<int>(type: "INTEGER", nullable: true),
                    ComboId = table.Column<int>(type: "INTEGER", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TotalLinea = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Picante = table.Column<int>(type: "INTEGER", nullable: true),
                    TamanoBebida = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoBebida = table.Column<int>(type: "INTEGER", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaItems_Bebidas_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "Bebidas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VentaItems_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VentaItems_Tamales_TamalId",
                        column: x => x.TamalId,
                        principalTable: "Tamales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VentaItems_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboItems_BebidaId",
                table: "ComboItems",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboItems_ComboId",
                table: "ComboItems",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboItems_TamalId",
                table: "ComboItems",
                column: "TamalId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioMovimientos_MateriaPrimaId",
                table: "InventarioMovimientos",
                column: "MateriaPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioMovimientos_SucursalId",
                table: "InventarioMovimientos",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSaldos_MateriaPrimaId",
                table: "InventarioSaldos",
                column: "MateriaPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSaldos_SucursalId_MateriaPrimaId",
                table: "InventarioSaldos",
                columns: new[] { "SucursalId", "MateriaPrimaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LotesCoccion_SucursalId",
                table: "LotesCoccion",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_LotesCoccion_TamalId",
                table: "LotesCoccion",
                column: "TamalId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaItems_MateriaPrimaId",
                table: "RecetaItems",
                column: "MateriaPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaItems_RecetaId",
                table: "RecetaItems",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_TipoProducto_ProductoId",
                table: "Recetas",
                columns: new[] { "TipoProducto", "ProductoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TamalPresentaciones_TamalId_Presentacion",
                table: "TamalPresentaciones",
                columns: new[] { "TamalId", "Presentacion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_BebidaId",
                table: "VentaItems",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_ComboId",
                table: "VentaItems",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_TamalId",
                table: "VentaItems",
                column: "TamalId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_TipoProducto_TamalId_BebidaId_ComboId",
                table: "VentaItems",
                columns: new[] { "TipoProducto", "TamalId", "BebidaId", "ComboId" });

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_VentaId",
                table: "VentaItems",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Fecha",
                table: "Ventas",
                column: "Fecha");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_SucursalId",
                table: "Ventas",
                column: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboItems");

            migrationBuilder.DropTable(
                name: "InventarioMovimientos");

            migrationBuilder.DropTable(
                name: "InventarioSaldos");

            migrationBuilder.DropTable(
                name: "LlmLogs");

            migrationBuilder.DropTable(
                name: "LotesCoccion");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "RecetaItems");

            migrationBuilder.DropTable(
                name: "TamalPresentaciones");

            migrationBuilder.DropTable(
                name: "VentaItems");

            migrationBuilder.DropTable(
                name: "MateriasPrimas");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Tamales");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
