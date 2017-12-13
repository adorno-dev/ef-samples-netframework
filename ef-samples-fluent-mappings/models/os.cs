using System.Collections.Generic;

namespace Ef.Samples.Mappings.Models
{
    public class OS
    {
        public OS() {}

        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
