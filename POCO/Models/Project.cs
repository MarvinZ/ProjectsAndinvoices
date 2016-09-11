using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO.Models
{
    public class Project

    {

        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

    }
}
