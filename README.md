# ConsultasDgii

ConsultasDgii es una libraría que provee un API de .NET escrita en el lenguaje C# que permite realizar validaciones de RNC/Cédula en el sitio web de la Dirección General de Impuestos Internos (DGII) de la República Dominicana.



## Instalación

Utilizando NuGet

```
Install-Package Octetus.ConsultasDgii.Scraping -Version 1.0.0
```

Utilizando dotnet CLI

```
dotnet add package Octetus.ConsultasDgii.Scraping --version 1.0.0
```

## Ejemplo

```c#
string rnc = string.Empty;
string nombre = string.Empty;

var dgii = new DgiiScraper();
var response = dgii.Execute(new DgiiQueryRequest
{
	Rnc = "[SU RNC]"
});

if (response.IsOk)
{
	rnc = response.Rnc;
   	nombre = response.Nombre;
}
```
## Licencia

[MTI](https://github.com/wrobirson/ConsultasDgii/blob/master/LICENSE)

