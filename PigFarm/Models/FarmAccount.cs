using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigFarm.Models
{
    [Table("FarmAccount")]
    public class FarmAccount
    {
        public FarmAccount(int farmID, int accountID)
        {
            FarmID = farmID;
            AccountID = accountID;
        }

        [Key]
        public int ID { get; set; }
        public int FarmID { get; set; }
        public int AccountID { get; set; }

        public virtual Account Account { get; set; }
        [ForeignKey(nameof(FarmID))]
        public virtual Oc OC { get; set; }
    }
}
