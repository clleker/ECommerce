

namespace ECommerce.Application.Abstracts.MailQuene
{
    [Serializable]
    public class SendedMailDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        /// <summary>
        /// The name of the person to be sent.
        /// </summary>
        public string ToFullName { get; set; }

        /// <summary>
        /// The Email of the person to be sent.
        /// </summary>
        public string ToEmail { get; set; }
    }
}
