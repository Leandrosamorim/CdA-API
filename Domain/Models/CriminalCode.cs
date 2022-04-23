using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            Configure(name, description, penalty, prisonTime, statusId, createDate, updateDate, createUserId, updateUserId);
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

        private static void Configure(string name, string description, decimal penalty, int prisonTime, int statusId, DateTime createDate, DateTime updateDate, int createUserId, int updateUserId)
        {
            Assert.IsNotNull(name, "Invalid Name" );
            Assert.IsNotNull(description, "Invalid Description");
            Assert.IsNotNull(penalty, "Invalid Penalty");
            Assert.IsNotNull(prisonTime, "Invalid Prison Time");
            Assert.IsNotNull(statusId, "Invalid Status Id");
            Assert.IsNotNull(createDate, "Invalid Create Date");
            Assert.IsNotNull(updateDate, "Invalid Update Date");
            Assert.IsNotNull(createUserId, "Invalid Create User Id");
            Assert.IsNotNull(updateUserId, "Invalid Update User Id");

        }
    }
}
