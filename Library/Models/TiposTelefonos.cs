using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class TiposTelefonos
{
	[Key]
	public int TipoId { get; set; }

	[RegularExpression(@"^[A-Za-z ]+$",ErrorMessage = "La descripción no debe contener números ni caracteres especiales")]
	public string Descripcion { get; set;}
}
