using Octetus.ConsultasDgii.Core.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoNet4XWeb.Models
{
    public class ConsultaDgiiModel
    {
        [Display(Name ="RNC/Cédula a consultar")]
        [Required(ErrorMessage = "Debe ingresar el RNC o cédula que dese consultar.")]
        public string RncOCedula { get; set; }

        public DgiiQueryResponse Response { get; set; }
    }
}