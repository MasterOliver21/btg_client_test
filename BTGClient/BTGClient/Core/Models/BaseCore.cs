using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTGClient.Core.Models
{
    public class BaseCore
    {
        [PrimaryKey]
        public Guid Id { get;  set; } = Guid.NewGuid();
        [Column("inclusion_date")]
        public DateTime  InclusionDate { get;  set; } = DateTime.Now;
        [Column("change_date")]
        public DateTime ChangeDate { get; set; } = DateTime.Now;
    }
}
