using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Nunit.Models
{
    public class CreateEducationRecordWithoutDegree
    {
            public string CollegeName { get; set; }
            public string CountryCollege { get; set; }
            public string Title { get; set; }
            public string Degree { get; set; }
            public string YearOfGraduation { get; set; }

            public string ExpectedMessage { get; set; }
        }
    }



