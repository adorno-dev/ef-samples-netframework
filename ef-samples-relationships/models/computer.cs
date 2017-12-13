using System.Collections.Generic;

namespace Ef.Samples.Relationships.Models
{
    public class Computer
    {
        public Computer()
        {
            this.OperatingSystems = new List<OS>();
        }

        public int Id { get; set; }

        public string HostName { get; set; }

        public int ProcessorId { get; set; }

        public virtual Processor Processor { get; set; }

        public virtual ICollection<OS> OperatingSystems { get; set; }
    }
}
