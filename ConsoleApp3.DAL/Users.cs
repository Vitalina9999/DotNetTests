using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp3.DAL
{
    [Table("Users")] // Указывает имя таблицы в базе данных
    public class Users
    {
        [Key] // Первичный ключ
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автогенерация идентификатора
        public int Id { get; set; }

        [MaxLength(50)] // Максимальная длина строки соответствует nvarchar(50)
        public string? Name { get; set; } // Поле допускает null

        [MaxLength(50)] // Максимальная длина строки соответствует nvarchar(50)
        public string? Email { get; set; } // Поле допускает null
    }
}