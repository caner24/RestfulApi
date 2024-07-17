using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Helpers
{
    public class AuthorParameters : QueryStringParameters
    {
        public AuthorParameters()
        {
            OrderBy = "Name";
        }

        public DateTime MinBirthDate { get; set; }
        public DateTime MaxBirthDate => DateTime.Now;

        public bool ValidYearRange => MaxBirthDate >= MinBirthDate;

        public string Name { get; set; }
    }
}
