
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistance
{
    public class EntityAuditingOptions
    {
        public EntityAuditingOptions()
        {
            UserId = "1";
        }
        public string UserId { get; set; }
    }
}
