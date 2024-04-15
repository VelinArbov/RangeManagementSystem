using System.ComponentModel.DataAnnotations;

namespace RangeManagementSystem.Data.Common.Models
{
    public class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
