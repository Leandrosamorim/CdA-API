using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CriminalCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Penalty { get; private set; }
        [Required(AllowEmptyStrings = false)]
        public int PrisonTime { get; private set; }
        public int StatusId { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public int CreateUserId { get; private set; }
        public int UpdateUserId { get; private set; }

        public CriminalCode(int id, string name, string description, decimal penalty, int prisonTime, int statusId, DateTime createDate, DateTime updateDate, int createUserId, int updateUserId)
        {
            Id = id;
            Name = name;
            Description = description;
            Penalty = penalty;
            PrisonTime = prisonTime;
            StatusId = statusId;
            CreateDate = createDate;
            UpdateDate = updateDate;
            CreateUserId = createUserId;
            UpdateUserId = updateUserId;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
