using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class UsuariosDetalle
{
	[Key]
	public int DetalleId { get; set; }

    public int UsuarioId { get; set; }

	public int TipoId { get; set; }

	public string Telefono { get; set; }
}
