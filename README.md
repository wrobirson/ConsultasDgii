# ConsultasDgii

ConsultasDgii es una librería que provee un API de .NET escrita en el lenguaje C# que permite realizar consutas de RNC/Cédula y NCF en el sitio web de la Dirección General de Impuestos Internos (DGII) de la República Dominicana.

## Instalación

Utilizando NuGet

```
Install-Package Octetus.ConsultasDgii -Version 1.0.0
```

Utilizando dotnet CLI

```
dotnet add package Octetus.ConsultasDgii --version 1.0.0
```

## Ejemplo consultar contibuyente

```c#
string cedulaORnc = string.Empty;
string nombreComercial = string.Empty;

var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarRncContribuyentes("[SU RNC]");

if (response.Success)
{
	cedulaORnc = response.CedulaORnc;
	nombreComercial = response.NombreComercial;
}
```

## Ejemplo consultar RNC registrados

```c#
string rncCedula = string.Empty;
string nombre = string.Empty;

var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarRncRegistrados("[SU RNC]");

if (response.Success)
{
	rncCedula = response.RncOCedula;
	nombre = response.Nombre;
}
```
## Ejemplo consultar NCF

```c#
string tipo = string.Empty;
string estado = string.Empty;

var dgii = new ServicioConsultasWebDgii();
var response = dgii.ConsultarNcf("[SU NCF]", "[SU RNC]");

if (response.Success)
{
	tipo = response.TipoDeComprobante;
	estado = response.Estado;
}
```
## Licencia

[MIT](https://github.com/wrobirson/ConsultasDgii/blob/master/LICENSE)

