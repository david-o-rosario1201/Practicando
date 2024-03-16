using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un nombre")]
    [RegularExpression(@"^[A-Za-z ]+$",ErrorMessage = "El nombre no debe contener números ni caracteres especiales")]
    public string Nombre { get; set; }

    [EmailAddress(ErrorMessage = "El email no es válido")]
	public string Email { get; set;}


    [ForeignKey("UsuarioId")]
    public ICollection<UsuariosDetalle> UsuariosDetalles { get; set; } = new List<UsuariosDetalle>();
}
