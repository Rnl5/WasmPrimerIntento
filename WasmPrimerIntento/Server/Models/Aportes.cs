using System.ComponentModel.DataAnnotations;

public class Aportes
{
    [Key]
    public int AporteId {get; set;}

    [Required(ErrorMessage ="El campo Fecha es obligatorio")]
    public DateTime Fecha {get; set;} = DateTime.Now;

    [RegularExpression(@"^[a-zA-Z\s]+$")]
    [Required(ErrorMessage ="El campo Persona es obligatorio")]
    public string Persona {get; set;} = string.Empty;
    [Required(ErrorMessage ="El campo Observacion es obligatorio")]
    public string Observacion {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo Monto es obligatorio")]
    public double Monto {get; set;}
}