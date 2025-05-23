# ConsultasDgii

**ConsultasDgii** es una librería .NET escrita en C# que permite realizar consultas de RNC, cédulas, NCF y e-NCF a través del sitio web de la Dirección General de Impuestos Internos (DGII) de la República Dominicana.

## 📦 Instalación

### Usando NuGet Package Manager

```powershell
Install-Package Octetus.ConsultasDgii 
````

### Usando .NET CLI

```bash
dotnet add package Octetus.ConsultasDgii 
```

## Requisitos

* .NET Core 3.1 o superior
* Conexión a internet para realizar las consultas a la DGII

## 🚀 Ejemplos de Uso

### Consultar Contribuyente por RNC/Cédula

```csharp
var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarRncContribuyentes("[SU RNC]");

if (response.Success)
{
    Console.WriteLine($"RNC/Cédula: {response.CedulaORnc}");
    Console.WriteLine($"Nombre Comercial: {response.NombreComercial}");
}
```

### Consultar RNC Registrados

```csharp
var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarRncRegistrados("[SU RNC]");

if (response.Success)
{
    Console.WriteLine($"RNC/Cédula: {response.RncOCedula}");
    Console.WriteLine($"Nombre: {response.Nombre}");
}
```

### Consultar NCF

```csharp
var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarNcf("[SU NCF]", "[SU RNC]");

if (response.Success)
{
    Console.WriteLine($"Tipo: {response.TipoDeComprobante}");
    Console.WriteLine($"Estado: {response.Estado}");
}
```

### Consultar e-NCF

```csharp
var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarENcf("[RNC EMISOR]", "[e-NCF]", "[RNC COMPRADOR]", "[CÓDIGO DE SEGURIDAD]");

if (response.Success)
{
    Console.WriteLine($"Estado: {response.Estado}");
}
```

## 🧾 Manejo de Errores

Revisar siempre la propiedad `Success` de la respuesta para verificar que la consulta se realizó correctamente. En caso de error, puedes manejarlo así:

```csharp
if (!response.Success)
{
    Console.WriteLine("Ocurrió un error en la consulta.");
    Console.WriteLine(response.Message);
}
```

## 📄 Licencia

Este proyecto está licenciado bajo la licencia [MIT](https://github.com/wrobirson/ConsultasDgii/blob/master/LICENSE).

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si deseas mejorar esta librería, por favor abre un issue o envía un pull request.