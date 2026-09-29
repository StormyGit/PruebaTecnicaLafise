# PruebaTecnica_BancoLafise
API REST desarrollada en .NET 8 con ASP.NET Core Web API, Entity Framework Core y SQLite.

abrir el programa con visual studio, con la instalación de la dependencias y base de datos SQLlite
```code
cd Backend_PruebaTecnica_Lafise
dotnet restore
dotnet ef database update
```

## Endpoints de la API

La API utiliza las siguientes rutas principales.

### Clientes

#### Obtener todos los clientes

**GET**

```http
https://localhost:7280/Cliente
```

Respuesta de ejemplo:

```json
[
  {
    "id": "61d0b51a-71d9-4ab3-8c49-327028b72659",
    "nombre": "Daniel Lopez",
    "fechaNacimiento": "2026-09-29T00:11:42.455",
    "sexo": 0,
    "ingreso": 0
  }
]
```

#### Crear cliente

**POST**

```http
https://localhost:7280/Cliente
```

Body:

```json
{
  "nombreCliente": "Daniel Lopez",
  "fechaNacimiento": "2026-09-29T00:11:42.455Z",
  "genero": 0
}
```

Valores para `genero`:

```text
0 = Masculino
1 = Femenino
```

---

### Cuentas bancarias

#### Crear cuenta bancaria

**POST**

```http
https://localhost:7280/CuentaBancaria/crearCuentaBancaria
```

Body:

```json
{
  "clienteId": "61d0b51a-71d9-4ab3-8c49-327028b72659",
  "saldoInicial": 600
}
```

El campo `clienteId` debe corresponder a un cliente existente.

---

### Transacciones

#### Consultar historial de transacciones

**GET**

```http
https://localhost:7280/transaccion/historial/{cuentaBancariaId}
```

Ejemplo:

```http
https://localhost:7280/transaccion/historial/552de1bb-45ea-486b-84c5-d39f4fc4ad75
```

---

#### Realizar depósito o retiro

**POST**

```http
https://localhost:7280/transaccion/transaccion/{cuentaBancariaId}
```

Ejemplo:

```http
https://localhost:7280/transaccion/transaccion/552de1bb-45ea-486b-84c5-d39f4fc4ad75
```

Body:

```json
{
  "monto": 300,
  "tipo": 0
}
```

Valores para `tipo`:

```text
0 = Depósito
1 = Retiro
```

El sistema valida que la cuenta exista y, en caso de retiro, que tenga saldo suficiente.
# PruebaTecnicaLafise
