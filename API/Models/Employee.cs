using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_employees")]
[Index(nameof(Phone), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class Employee
{
    [Key, Required, Column("nik", TypeName = "nchar(6)")]
    public string NIK { get; set; }
    [Required, Column("first_name"), MaxLength(50)]
    public string FirstName { get; set; }
    [Column("last_name"), MaxLength(50)]
    public string LastName { get; set; }
    [Required, Column("phone"), MaxLength(15)]
    public string Phone { get; set; }
    [Required, Column("birthdate")]
    public DateTime BirthDate { get; set; }
    [Required, Column("salary")]
    public int Salary { get; set; }
    [Required, Column("email"), MaxLength(50)]
    public string Email { get; set; }
    [Required, Column("gender")]
    public Gender Gender { get; set; }

    // Relation
    [JsonIgnore]
    public Account? Account { get; set; }
}

public enum Gender
{
    Male,
    Female
}
