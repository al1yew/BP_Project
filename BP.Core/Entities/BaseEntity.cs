using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public bool IsUpdated { get; set; }
    }
}
