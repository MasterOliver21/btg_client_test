using SQLite;

namespace BTGClient.Core.Models
{

    [Table("address")]
    public class Address : BaseCore
    {
        [Column("street")]
        public string Street { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("state")]
        public string State { get; set; }
        [Column("client_id")]
        public Guid ClientId { get; set; }

        [Ignore]
        public virtual Client Client { get; set; }
    }
}
