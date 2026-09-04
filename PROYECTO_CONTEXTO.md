# PROYECTO MULTITRACV2 — CONTEXTO COMPLETO PARA NUEVO CHAT/DEVELOPER

> Este documento asume que quien lo lee NO tiene ninguna información previa sobre el proyecto.
> Contiene todo lo necesario para entender el estado actual, retomar el trabajo y no romper nada.

---

## 1. QUÉ ES ESTE PROYECTO (en una frase)

Modernizar un sistema viejo de transporte/logística llamado **"Multitrac/Operaciones"** (hecho en ASP.NET WebForms 2.0, ~280 páginas, ~180 tablas y ~1000 stored procedures en SQL Server) a una **API moderna en .NET 10 con Clean Architecture**, pero **sin volver a crear la base de datos**: se usa la base de datos SQL Server existente tal cual.

- El sistema es de uso interno de una empresa de transporte ("Multitrac").
- Los datos reales YA existen en SQL Server. No se crean tablas nuevas; se lee/escribe sobre las que ya existen.
- Incluye módulos de: operaciones de flete, equipos/vehículos, personal, combustible, clientes, proveedores, y catálogos generales.

---

## 2. REGLAS DE ORO (IMPORTANTE — LÉELO PRIMERO)

1. **NO agregar nuevas funciones ni entidades** por el momento. El dueño del proyecto dijo: *"No quiero que agregues más funciones o entidades por el momento. Quiero que con lo que tenemos ya tengamos una base y todo el proyecto hasta ahora esté ya funcionando"*.
2. **NO recrear la base de datos**. Es una BD existente con 30 años de datos. Se mapea y se trabaja contra ella.
3. **Mantener la Clean Architecture** (ver sección 5). Prohibido crear dependencias circulares.
4. Respetar los **nombres de columnas reales** de la BD (muchas usan guion bajo, ver sección 9).
5. Los mensajes de herramientas en consola aparecen en **español** (ej. "Compilación correcta." = build OK, "Superado" = tests pasan).
6. Antes de tocar código, **leer este documento completo**. Hay trampas conocidas muy específicas de esta BD.

---

## 3. ENTORNO TÉCNICO (Sistema donde corre)

- **Sistema operativo**: Windows (shell PowerShell 5.1)
- **Framework del proyecto**: .NET 10 (`net10.0`)
- **Base de datos**: SQL Server, instancia `REBAZA\SQLEXPRESS`, base de datos `BDMultitrac`
- **Conexión a BD**: Windows Authentication (`Trusted_Connection=True`), sin usuario/contraseña
- **Formato de solución**: `.slnx` (archivo `MultitracV2.slnx`, NO es `.sln` tradicional)

### Ubicaciones (¡MUY IMPORTANTE — hay dos carpetas similares!)

- La **carpeta de trabajo del CLI** (donde a veces aparece el cursor) es:
  `C:\Users\fabri\Downloads\Multitrac\Multitrac.API\Multitrac.API`
- El **proyecto REAL** vive en esta otra carpeta:
  `C:\Users\fabri\Downloads\MultitracV2`

> ⚠️ Siempre trabajar con la ruta `C:\Users\fabri\Downloads\MultitracV2`. Ahí está todo el código.

---

## 4. COMANDOS BÁSICOS (PowerShell)

```powershell
# ─── 1) PARAR la API (SIEMPRE antes de consultar la BD con sqlcmd) ───
Stop-Process -Name "dotnet" -Force -ErrorAction SilentlyContinue
Start-Sleep -Seconds 3

# ─── 2) ARRANCAR la API en segundo plano ───
Start-Process -FilePath "dotnet" -ArgumentList `
  "C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\bin\Debug\net10.0\Multitrac.Api.dll", "--urls", "http://localhost:5100" `
  -WindowStyle Hidden
Start-Sleep -Seconds 4

# ─── 3) COMPILAR (build) ───
dotnet build MultitracV2.slnx
# cada vez que cambies código hay que recompilar y reiniciar la API

# ─── 4) CORRER TESTS ───
dotnet test MultitracV2.slnx

# ─── 5) CONSULTAR LA BD directamente (solo con la API apagada) ───
Invoke-Sqlcmd -ServerInstance "REBAZA\SQLEXPRESS" -Database "BDMultitrac" -Query "SELECT ..."
```

Trucos de PowerShell 5.1:
- **NO usa `&&`** (ese operador no existe). Encadenar con `;` o con `if ($?) { ... }`.
- `Invoke-Sqlcmd` falla con "login failed" si la API está corriendo (la API bloquea la BD). Por eso hay que apagarla primero.

### Autenticación de prueba de la API
- usuario: `admin`
- contraseña: `admin123`

### Login para probar endpoints autenticados
```powershell
$loginBody = @{ username = "admin"; password = "admin123" } | ConvertTo-Json
$loginResp = Invoke-RestMethod -Uri "http://localhost:5100/api/auth/login" -Method POST -ContentType "application/json" -Body $loginBody
$headers = @{ Authorization = "Bearer $($loginResp.token)" }

# ejemplo de GET autenticado
Invoke-WebRequest -Uri "http://localhost:5100/api/banco" -Headers $headers -UseBasicParsing
```

---

## 5. ARQUITECTURA DEL PROYECTO (Clean Architecture)

```
MultitracV2/
│   MultitracV2.slnx                        ← solución
│
├── src/
│   ├── Multitrac.Domain/                   ← CAPA MÁS INTERNA (no referencia a nadie)
│   │   ├── Entities/                       ← entidades (CatalogEntities, Equipo, Personal, Operacion, etc.)
│   │   ├── Interfaces/                     ← IRepository, IUnitOfWork, ISpRepository...
│   │   └── Exceptions/                     ← NotFoundException, BadRequestException, ConflictException...
│   │
│   ├── Multitrac.Application/              ← lógica de negocio
│   │   ├── DTOs/                           ← objetos de transferencia
│   │   ├── Services/                       ← ServiceBase + 5 archivos de servicios de negocio
│   │   ├── Validators/                     ← FluentValidation
│   │   └── Interfaces/                     ← IService<TDto,TEntity>, IEquipoService, IOperacionFleteSpRepository
│   │
│   ├── Multitrac.Infrastructure/           ← acceso a datos (EF Core + SQL)
│   │   ├── Data/                           ← BdmultitracContext (DbContext)
│   │   ├── Data/Configurations/            ← configuración Fluent API (nombres de columnas, identity...)
│   │   └── Repositories/                   ← Repository<T>, UnitOfWork, OperacionFleteSpRepository
│   │
│   └── Multitrac.Api/                      ← punto de entrada (Web API)
│       ├── Program.cs                      ← registro de dependencias (DI), JWT, middleware
│       ├── Controllers/                    ← controllers HTTP
│       ├── Middleware/                     ← ExceptionHandlingMiddleware
│       └── Services/                       ← AuthService (login/JWT)
│
└── tests/
    ├── Multitrac.UnitTests/                ← 5 tests unitarios (validators) — PASAN
    └── Multitrac.IntegrationTests/         ← PROYECTO VACÍO (no tiene ningún test todavía)
```

### Reglas de referencias entre proyectos (¡respetar o compila mal!)
- `Domain` → no referencia a ninguno.
- `Application` → referencia a `Domain`.
- `Infrastructure` → referencia a `Domain` + `Application`.
- `Api` → referencia a `Application` + `Infrastructure`.
- **Prohibido**: Domain referenciando a algo, o Application referenciando Infrastructure.

---

## 6. LO QUE YA ESTÁ HECHO (estado actual)

### 6.1. Entidades y CRUD base
- **~46 entidades** mapeadas con EF Core Fluent API contra las tablas reales.
- **~35 DTOs** y **~31 servicios** y **~31 controllers** (cada uno con GET/GET/page/GET by id/POST/PUT/DELETE).

### 6.2. Lista de ENDPOINTS (31 recursos)
- **Catálogos**: moneda, banco, cargo, niveleducativo, afp, flota, actividad, turno, tipopago, tipoocurrencia
- **Operaciones**: operacion, operaciongeneral, operaciongeneralequipo, operacionflete, operacioninforme, tipocarga, unidad
- **Personal**: personal, personalcargo, personalvacaciones, contratista
- **Equipos**: equipo, equipocombustible, equipokilometraje, equipomantenimiento
- **Cliente/Proveedor**: cliente, proveedor, area, tipodocumento, empresa, convoy
- **Auth**: /api/auth/* (register, login, change-password, me)

### 6.3. Estado VERIFICADO (con datos reales de producción)
- **Todos los GET de listado (29 endpoints) devuelven 200 OK** con datos reales. Ejemplos de registros por tabla: operacion(555), operaciongeneral(34604), operaciongeneralequipo(50803), equipocombustible(35221), equipokilometraje(14280), personal(643), equipo(978), cliente(149), contratista(168), cargo(43), banco(5), moneda(3)...
- **CRUD completo (Crear/Actualizar/Eliminar) funciona** en: moneda, cargo, cliente, banco, niveleducativo, tipopago, contratista, operacion, equipocombustible, personal, personalcargo, equipo, equipokilometraje, equipomantenimiento.
- **Paginación** (`GET /api/<recurso>/paged?page=1&pageSize=5&search=...&sortBy=...&sortDirection=desc`) funciona con búsqueda y ordenamiento a nivel de base de datos.
- **JWT Auth** funciona (login, register, cambiar contraseña, perfil).
- **FluentValidation** (validación de entrada) aplicada en todos los controllers.

### 6.4. Integración de Stored Procedures (5 endpoints funcionando)
En el controller `OperacionFleteController` (archivo `OperacionController.cs`):
- `GET /api/operacionflete/by-cliente-tipo-carga` → devuelve fletes por cliente y tipo de carga (668 records)
- `GET /api/operacionflete/by-operacion/{id}` → flete por id de operación
- `GET /api/operacionflete/indicadores` → indicadores calculados (45 records)
- `GET /api/operacionflete/reporte-facturacion` → reporte de facturación (¡solo con rangos de fechas cortos, versección 9!)
- `GET /api/operacionflete/contratista-descuentos/{id}` → descuentos de contratista (6 records)

---

## 7. LO QUE FALTA / PENDIENTE (próximos pasos si te piden continuar)

1. **`tests/Multitrac.IntegrationTests` está vacío** — hay que crear los tests de integración (conectan a la BD real y prueban endpoints/CRUD/auth).
2. **Cambiar el mensaje de error en `src/Multitrac.Api/Middleware/ExceptionHandlingMiddleware.cs`**:
   - Línea ~47: hoy expone `exception.InnerException?.Message ?? exception.Message` para errores 500. Eso es SOLO para depuración.
   - En producción debe devolver un mensaje genérico: `"An unexpected error occurred."`
3. **Auditoría final completa pendiente**: revisar los 31 endpoints × (GET, GET by id, paginado, POST, PUT, DELETE). Algunos GET by id y CRUD de ciertos recursos no están 100% re-verificados después de los últimos cambios.
4. **Recursos con PK tipo string que probablemente fallan** (¡igual que pasó con Equipo!):
   - `proveedor` (id real: `PRV_COD`), `area` (id real: `ARE_COD`), `tipodocumento` (id real: `TIP_COD`) tienen controllers que usan `int id`. Su PK real es texto. Hay que rediseñarlos con una interfaz propia como se hizo con `IEquipoService`.
5. **Entidades con configuración pero SIN endpoint**: equipomantenimientodetalle, equipodocumentotracto, equipodocumentocarreta, personaldocumento, personalequipo, personalepp, personaleppkardex, personalrecord, personalvacacionesregistro, personallicenciaconducir, personalsueno, operacionhorario, operacionturno, operacioncarga, operaciontipo. (No piden agregarlos sin permiso, pero existen como entidades ya.)
6. **Front-end Blazor**: mencionado como objetivo del proyecto pero **aún no existe**.
7. **Más stored procedures**: hay ~1000 en la BD, solo 5 integrados a la API.
8. **Verificar DELETE en tablas con claves foráneas restrictivas** — algunos DELETE podrían dar 409 (conflicto) por dependencias. El middleware ya maneja ese caso devolviendo `ConflictException`.

---

## 8. DECISIONES DE DISEÑO IMPORTANTES (no romper estas reglas)

### 8.1. Nombres de columnas con guion bajo
Las tablas de la BD usan nombres tipo `Id_Operacion`, `Cod_Equipo`, etc. En la configuración Fluent API **siempre** se mapea con `.HasColumnName("Id_Operacion")`. Nunca asumir que el nombre de la propiedad C# coincide con el de la columna.

### 8.2. Errores tipográficos reales de la BD (¡MANTENER tal cual!)
Estas columnas están mal escritas en la BD y así se deben mapear:
- `Nom_RepLegal_Contartista` (falta "a": Cont**a**rtista)
- `ValorRefrencial` (falta "e": Refr**e**ncial)
- `FechaIncio_Cargo` (falta "i": Inic**i**o)
- `Id_Pesonal_Epp` (Pes**o**nal)
- `HoraEstimadaSaalida` (Sa**a**lida)

### 8.3. Tablas con columna IDENTITY (auto-incremento) — 28 tablas
CONFIGURADAS con `.ValueGeneratedOnAdd()` para que la BD genere el id. EF Core NO manda el id en el INSERT.
Ejemplos: BANCO, CARGO, CLIENTE, OPERACION, PERSONAL, ACTIVIDAD, AFP, AREA, CONVOY, EMPRESA, EQUIPO_COMBUSTIBLE, FLOTA, OPERACION_*, PERSONAL_CARGO, PROVEEDOR, TIPO_OCURRENCIA, TURNO, UNIDAD_CANTIDAD...

### 8.4. Tablas SIN identity — 9 tablas (generar el id manualmente, max+1)
CONFIGURADAS con `.ValueGeneratedNever()` y el servicio genera el siguiente id con `SetNextIdAsync` (max + 1):
MONEDA, NIVEL_EDUCATIVO, TIPO_PAGO, PERSONAL_VACACIONES, CONTRATISTA, EQUIPOS, EQUIPO_KILOMETRAJE, EQUIPO_MANTENIMIENTO, TIPO_DOCUMENTO.

### 8.5. Tablas con PK de texto (string) — NO identity
PROVEEDOR (`PRV_COD`), AREA (`ARE_COD`), TIPO_DOCUMENTO (`TIP_COD`).

### 8.6. `Equipo` tiene PK COMPUESTO de texto (TipoEquipo + CodEquipo)
- Es un caso especial: usa la interfaz propia `IEquipoService` (no la genérica `IService`).
- Las rutas son compuestas: `GET/PUT/DELETE /api/equipo/{tipoEquipo}/{codEquipo}` (ej. `/api/equipo/T/MOT101`).
- Esto se hizo porque la interfaz genérica usa `int id` y no servía.

### 8.7. Tablas con TRIGGERS en la BD (EF Core falla al insertar/borrar)
SQL Server no permite `OUTPUT` sin `INTO` en tablas con triggers. EF Core usa `OUTPUT INSERTED` para leer el id generado → falla.
- **Solución aplicada**: `.ToTable("PERSONAL", t => t.UseSqlOutputClause(false))` para PERSONAL y PERSONAL_CARGO.
- Tablas con triggers activos: PERSONAL(1), PERSONAL_CARGO(1), CONTRATISTA(1), EQUIPOS(2), EQUIPO_MANTENIMIENTO(1).
- CONTRATISTA, EQUIPOS y EQUIPO_MANTENIMIENTO funcionan sin el fix porque NO son identity.
- ⚠️ **Si en el futuro se agrega una tabla identity con trigger, hay que ponerle `UseSqlOutputClause(false)`**.

### 8.8. La vista `_Tr` es MUY pesada
Consultas de un año completo dan timeout (aunque el `CommandTimeout` está en 120s). Para el reporte de facturación usar rangos de fechas cortos (máx. ~1 mes).

### 8.9. Tabla `Indicadores`
Es un catálogo (define qué indicadores existen). Los valores calculados se generan dinámicamente con `SP_INDICADORES_Calcular`. No confundir.

### 8.10. JWT / Autenticación
- Hash SHA256 con salt fijo: `"Multitrac_{password}_Salt_2024"`.
- Tokens expiran a las **8 horas**.
- `AuthService` vive en `src/Multitrac.Api/Services/AuthService.cs`.
- **Todos los controllers requieren token** (auth global). Sin token → 401.

---

## 9. PROBLEMAS YA RESUELTOS (historial útil para no repetir errores)

1. **URLs devolvían 404** porque controllers estaban mal nombrados → se renombraron a `PersonalController`, `EquipoController`, `TurnoController`, `ConvoyController`, y se creó `PersonalVacacionesController`.
2. **Errores 500 por columnas sin mapear** → se agregaron todos los `.HasColumnName()` a EquipoCombustible (20+ cols), EquipoKilometraje (6 cols) y EquipoMantenimiento (18 cols, incluyendo el typo `HoraEstimadaSaalida` y `Nro_Orden`).
3. **Crear (POST) fallaba con "Id=0 ya existe"** en tablas sin identity → se añadió `SetNextIdAsync` (genera max+1) en `ServiceBase` y se aplicó solo a las 9 tablas sin identity.
4. **Actualizar (PUT) fallaba** con el error *"property ... is part of a key and so cannot be modified"* → se añadió `RestorePrimaryKey` en `ServiceBase`, aplicado en todos los `UpdateAsync`.
5. **"Cannot insert explicit value for identity column"** → se cambió `ValueGeneratedNever()` → `ValueGeneratedOnAdd()` en las 28 configuraciones de tablas identity.
6. **PERSONAL no se podía insertar/borrar por su trigger** → `.UseSqlOutputClause(false)` + usar `ExecuteSqlRawAsync` para el DELETE.
7. **Dependencia circular** → `IOperacionFleteSpRepository` vive en Application (no en Domain), y la configuración del repositorio SP está en Infrastructure.

---

## 10. ARCHIVOS CLAVE (rutas absolutas)

| Qué es | Ruta |
|---|---|
| Solución | `C:\Users\fabri\Downloads\MultitracV2\MultitracV2.slnx` |
| Configuración de la API | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\Program.cs` |
| Manejo de errores (hay que revisar 500) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\Middleware\ExceptionHandlingMiddleware.cs` |
| Login/JWT | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\Services\AuthService.cs` |
| Controller de ejemplo (patrón estándar) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\Controllers\MonedaController.cs` |
| Controller con endpoints SP (operacionflete) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\Controllers\OperacionController.cs` |
| Controller con PK compuesto (equipo) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Api\Controllers\EquipoController.cs` |
| Servicio base (paginación, búsqueda, ids) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Application\Services\ServiceBase.cs` |
| Interfaz genérica de servicio | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Application\Interfaces\IService.cs` |
| Interfaz para PK compuesto | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Application\Interfaces\IEquipoService.cs` |
| Interfaz de SP | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Application\Interfaces\IOperacionFleteSpRepository.cs` |
| DbContext (todas las tablas) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Infrastructure\Data\BdmultitracContext.cs` |
| Mapeos de tablas (Fluent API) | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Infrastructure\Data\Configurations\*.cs` |
| Repositorio genérico | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Infrastructure\Repositories\Repository.cs` |
| UnitOfWork | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Infrastructure\Repositories\UnitOfWork.cs` |
| SQL de los stored procedures | `C:\Users\fabri\Downloads\MultitracV2\src\Multitrac.Infrastructure\Repositories\OperacionFleteSpRepository.cs` |
| Tests que pasan (referencia) | `C:\Users\fabri\Downloads\MultitracV2\tests\Multitrac.UnitTests\*.cs` |

---

## 11. MÉTODOS IMPORTANTES DE `ServiceBase` (el corazón de los servicios)

Ubicado en `src\Multitrac.Application\Services\ServiceBase.cs`:
- `GetNextIdAsync<T>()` → calcula el siguiente id (max + 1) para tablas sin identity.
- `SetNextIdAsync<T>(entity)` → asigna el id calculado ANTES de insertar (solo si el id actual es 0).
- `RestorePrimaryKey<T>(entity, originalId)` → evita que EF Core intente cambiar la clave primaria durante un Update.
- `GetPaginatedAsync(request)` → paginación + búsqueda por texto + ordenamiento, todo traducido a la BD.
- `GetEntityByIdOrThrowAsync(id)` → busca por id y lanza `NotFoundException` si no existe.

Interfaz genérica `IService<TDto,TEntity>` (tiene los métodos con `int id`):
`GetByIdAsync(int id)`, `GetAllAsync()`, `CreateAsync(dto)`, `UpdateAsync(int id, dto)`, `DeleteAsync(int id)`, `ExistsAsync(int id)`, `GetPaginatedAsync(request)`.

> Nota: los recursos cuyo id real NO es un `int` (equipo, proveedor, area, tipodocumento) necesitan una interfaz propia, como se hizo con `IEquipoService`.

---

## 12. CHECKLIST RÁPIDO PARA EMPEZAR A TRABAJAR

1. `Stop-Process -Name "dotnet" -Force` (apagar API antes de tocar BD).
2. `Invoke-Sqlcmd` para explorar la BD si hace falta.
3. Editar código en `C:\Users\fabri\Downloads\MultitracV2`.
4. `dotnet build MultitracV2.slnx` (debe dar "Compilación correcta." = 0 errores).
5. `dotnet test MultitracV2.slnx` (deben pasar 5 tests).
6. Arrancar la API con `Start-Process ... http://localhost:5100`.
7. Login con admin/admin123, obtener token, probar endpoints con `Invoke-WebRequest` + header `Authorization: Bearer <token>`.
8. Si se prueba la BD directo, volver a apagar la API primero.

### Mensaje de éxito esperado al compilar
```
Compilación correcta.     ← build OK
```
### Mensaje de éxito esperado al testear
```
Superado: 5 ... Total: 5   ← 5 tests pasan
```

---

## 13. GLOSARIO RÁPIDO (por si hay dudas)

- **Entity / Entidad**: clase C# que representa una fila de una tabla de la BD.
- **DTO**: objeto para transportar datos entre la API y el cliente (no expone la entidad tal cual).
- **Controller**: clase C# que define los endpoints HTTP (`[HttpGet]`, `[HttpPost]`, etc.).
- **Service**: clase con la lógica de negocio; los controllers llaman a los services.
- **Repository**: clase que ejecuta las consultas/operaciones contra la BD.
- **Fluent API / Configuration**: archivos que dicen cómo mapear cada entidad a su tabla (nombres de columna, claves, identity...).
- **Stored Procedure (SP)**: script SQL guardado en la BD que hace consultas o cálculos complejos. La API puede llamarlos.
- **Identity column**: columna que SQL Server autoincrementa (no se le pasa valor al insertar).
- **JWT**: token de autenticación que da la API al hacer login y que hay que mandar en cada petición.
- **FluentValidation**: librería que valida que los datos que llegan por la API sean correctos (ej. "el nombre es obligatorio").