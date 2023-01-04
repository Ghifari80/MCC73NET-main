using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_tr_account_roles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }


    [Required, Column("account_nik", TypeName = "nchar(6)")]
    public string AccountNIK { get; set; }
    
    [Required, Column("role_id")]
    public int RoleId { get; set; }

    // Relation
    [JsonIgnore, ForeignKey("AccountNIK")]
    public Account? Account { get; set; }
    [JsonIgnore, ForeignKey("RoleId")]
    public Role? Role { get; set; }
}
