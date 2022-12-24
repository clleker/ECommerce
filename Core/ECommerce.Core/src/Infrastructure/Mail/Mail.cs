using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Infrastructure.Mail
{
    /// <summary>
    /// This Object is message template that we will send to the customer or another type 
    /// </summary>
    public class Mail
    {
        public string Subject { get; set; }

        /// <summary>
        /// Mail Body
        /// </summary>
        public string Body { get; set; }

    }
}
