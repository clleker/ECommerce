
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Persistance.Options
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
