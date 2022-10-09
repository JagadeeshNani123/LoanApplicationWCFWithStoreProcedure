using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LoanApplicationWCFService.Models
{
    [DataContract]
    public class CustomerModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string EmploymentType { get; set; }

        [DataMember]
        public string MaritialStatus { get; set; }


        [DataMember]
        public decimal Income { get; set; }

        [DataMember]
        public string DateOfBirth { get; set; }

        [DataMember]
        public string AddressProof { get; set; }

        [DataMember]
        public string AddressProofNumber { get; set; }

        [DataMember]
        public string PanCardNumber { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}