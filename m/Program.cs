using System;

public struct Contacto
{
	public string Nombre;
	public string Direccion;
	public string Telefono;
}

public struct Evento
{
	public string Descripcion;
	public string Fecha;
}

class Agenda
{
	private const int MAX_CONTACTOS = 100;
	private const int MAX_EVENTOS = 100;
	private Contacto[] contactos = new Contacto[MAX_CONTACTOS];
	private Evento[] eventos = new Evento[MAX_EVENTOS];
	private int numContactos = 0;
	private int numEventos = 0;

	public void AgregarContacto()
	{
		if (numContactos < MAX_CONTACTOS)
		{
			Console.Write("Ingrese nombre: ");
			string nombre = Console.ReadLine();
			Console.Write("Ingrese dirección: ");
			string direccion = Console.ReadLine();
			Console.Write("Ingrese teléfono: ");
			string telefono = Console.ReadLine();
			contactos[numContactos] = new Contacto { Nombre = nombre, Direccion = direccion, Telefono = telefono };
			numContactos++;
			Console.WriteLine("Contacto agregado correctamente.");
		}
		else
		{
			Console.WriteLine("Se ha alcanzado el límite máximo de contactos.");
		}
	}

	public void BorrarContacto()
	{
		if (numContactos > 0)
		{
			Console.Write("Ingrese el nombre del contacto a eliminar: ");
			string nombre = Console.ReadLine();
			for (int i = 0; i < numContactos; i++)
			{
				if (contactos[i].Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
				{
					numContactos--;
					contactos[i] = contactos[numContactos];
					Console.WriteLine("Contacto eliminado correctamente.");
					return;
				}
			}
			Console.WriteLine("Contacto no encontrado.");
		}
		else
		{
			Console.WriteLine("No hay contactos disponibles para eliminar.");
		}
	}

	public void BuscarContacto()
	{
		if (numContactos > 0)
		{
			Console.Write("Ingrese el nombre del contacto a buscar: ");
			string nombre = Console.ReadLine();
			for (int i = 0; i < numContactos; i++)
			{
				if (contactos[i].Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Contacto encontrado:");
					Console.WriteLine($"Nombre: {contactos[i].Nombre}");
					Console.WriteLine($"Dirección: {contactos[i].Direccion}");
					Console.WriteLine($"Teléfono: {contactos[i].Telefono}");
					return;
				}
			}
			Console.WriteLine("Contacto no encontrado.");
		}
		else
		{
			Console.WriteLine("No hay contactos disponibles para buscar.");
		}
	}

	public void AgregarEvento()
	{
		if (numEventos < MAX_EVENTOS)
		{
			Console.Write("Ingrese descripción del evento: ");
			string descripcion = Console.ReadLine();
			Console.Write("Ingrese la fecha y hora del evento  Ej: 5-Marzo 9:30 AM : ");
			string fecha = Console.ReadLine();
			eventos[numEventos] = new Evento { Descripcion = descripcion, Fecha = fecha };
			numEventos++;
			Console.WriteLine("Evento agregado correctamente.");
		}
		else
		{
			Console.WriteLine("Se ha alcanzado el límite máximo de eventos.");
		}
	}

	public void BorrarEvento()
	{
		if (numEventos > 0)
		{
			Console.Write("Ingrese la descripción del evento a eliminar: ");
			string descripcion = Console.ReadLine();
			for (int i = 0; i < numEventos; i++)
			{
				if (eventos[i].Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase))
				{
					numEventos--;
					eventos[i] = eventos[numEventos];
					Console.WriteLine("Evento eliminado correctamente.");
					return;
				}
			}
			Console.WriteLine("Evento no encontrado.");
		}
		else
		{
			Console.WriteLine("No hay eventos disponibles para eliminar.");
		}
	}

	public void BuscarEvento()
	{
		if (numEventos > 0)
		{
			Console.Write("Ingrese la descripción del evento a buscar: ");
			string descripcion = Console.ReadLine();
			for (int i = 0; i < numEventos; i++)
			{
				if (eventos[i].Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Evento encontrado:");
					Console.WriteLine($"Descripción: {eventos[i].Descripcion}");
					Console.WriteLine($"Fecha y hora: {eventos[i].Fecha}");
					return;
				}
			}
			Console.WriteLine("Evento no encontrado.");
		}
		else
		{
			Console.WriteLine("No hay eventos disponibles para buscar.");
		}
	}
}

class Programa
{
	static void Main(string[] args)
	{
		Agenda agenda = new Agenda();
		int opcion;

		do
		{
			Console.WriteLine("\nMenú de Agenda:");
			Console.WriteLine("1. Agregar Contacto");
			Console.WriteLine("2. Borrar Contacto");
			Console.WriteLine("3. Buscar Contacto");
			Console.WriteLine("4. Agregar Evento");
			Console.WriteLine("5. Borrar Evento");
			Console.WriteLine("6. Buscar Evento");
			Console.WriteLine("7. Salir");
			Console.Write("Ingrese su opción: ");
			opcion = int.Parse(Console.ReadLine());

			switch (opcion)
			{
				case 1:
					agenda.AgregarContacto();
					break;
				case 2:
					agenda.BorrarContacto();
					break;
				case 3:
					agenda.BuscarContacto();
					break;
				case 4:
					agenda.AgregarEvento();
					break;
				case 5:
					agenda.BorrarEvento();
					break;
				case 6:
					agenda.BuscarEvento();
					break;
				case 7:
					Console.WriteLine("Saliendo...");
					break;
				default:
					Console.WriteLine("Opción inválida. Por favor ingrese un número entre 1 y 7.");
					break;
			}
		}
		while (opcion != 7);
	}
}