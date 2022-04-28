using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Laba2_OOPR.Models.Base
{
    public class BaseRepo
    {
        [Key]
        public virtual int Id { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
