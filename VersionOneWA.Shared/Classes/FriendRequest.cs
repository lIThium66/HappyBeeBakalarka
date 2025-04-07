using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOneWA.Shared.Classes
{
    public class FriendRequest
    {
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public bool isAccepted { get; set; } = false;
        public RequestStatus Status { get; set; } = RequestStatus.None;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
    }

    public enum RequestStatus
    {
        None,
        Pending,
        Accepted,
        Declined
    }
}

