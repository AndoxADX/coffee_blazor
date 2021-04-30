using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Coffee.Core.User.Api
{
    public class UserKYC2 : AuditableEntity
    {
        [Key]
        public int UserId { get; set; }
        
        public string RealName { get; set; }
        
        public int DocumentId { get; set; }
        
        public string DocumentNo { get; set; }
        
        public string HandheldICImageFileName { get; set; }
        
        public string FrontICImageFileName { get; set; }
        
        public string BackICImageFileName { get; set; }
        
        public string WalletICImageFileName { get; set; }
        
        public bool IsVerified { get; set; }
        
        public bool IsPending { get; set; }
        
        public bool IsRejected { get; set; }
        
        public string RejectedReason { get; set; }
        
        public string ManualRejectReason { get; set; }
        
        public string VerifiedBy { get; set; }
        
        // public DateTime UpdatedDate { get; set; }
        
        public DateTime? VerifiedDate { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

        // [ForeignKey("DocumentId")]
        // [JsonIgnore]
        // public Document Document { get; set; }
    }
}
