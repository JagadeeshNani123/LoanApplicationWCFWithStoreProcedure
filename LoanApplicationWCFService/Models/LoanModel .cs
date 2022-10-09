using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LoanApplicationWCFService.Models
{
    [DataContract]
    public class LoanModel
    {
        [DataMember]
        public Guid LoanId { get; set; }

        [DataMember]
        public Guid CustomerId { get; set; }

        [DataMember]
        public string LoanType { get; set; }

        [DataMember]
        public decimal LoanAmount { get; set; }

        [DataMember]
        public string LoanApprovedDate { get; set; }

        [DataMember]
        public int LoanTenure { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}