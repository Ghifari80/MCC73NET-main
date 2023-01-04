using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_profilings")]
public class Profiling
{
    [Key, Required, Column("nik", TypeName = "nchar(6)")]
    public string NIK { get; set; }
    [Required, Column("education_id")]
    public int EducationId { get; set; }

    // Relation
    [JsonIgnore, ForeignKey("EducationId")]
    public Education? Education { get; set; }
    [JsonIgnore]
    public Account? Account { get; set; }
}
