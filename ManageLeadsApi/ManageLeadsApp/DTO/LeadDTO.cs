using ManageLeadsDomain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.DTO
{
    public class LeadDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Suburb { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public LeadStatus? Status { get; set; }
    }
}
