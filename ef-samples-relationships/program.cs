using Ef.Samples.Relationships.Data;
using Ef.Samples.Relationships.Models;
using System.Linq;

using io = System.Console;

namespace Ef.Samples.Relationships
{
    class Program
    {
        static void Populate()
        {
            using (var db = new AppDataContext())
            {
                io.WriteLine("[Computers]");

                foreach (var computer in db.Computers)
                    io.WriteLine($"ID: {computer.Id} HostName: {computer.HostName}");

                io.WriteLine();

                io.WriteLine("[Processors]");

                foreach (var processor in db.Processors)
                    io.WriteLine($"ID: {processor.Id} ProcessorName: {processor.Description}");

                io.WriteLine();

                io.WriteLine("[OS -> Computer]");
                foreach (var os in db.OperatingSystems.Include("Computers"))
                {
                    io.WriteLine($"ID: {os.Id} OS Name: {os.Description}");
                    foreach (var computer in os.Computers)
                        io.WriteLine($"\t ID: {computer.Id} HostName: {computer.HostName}");
                }

                io.WriteLine();

                io.WriteLine("[Computer -> OS]");
                foreach (var computer in db.Computers.Include("OperatingSystems"))
                {
                    io.WriteLine($"ID: {computer.Id} HostName: {computer.HostName}");
                    foreach (var os in computer.OperatingSystems)
                        io.WriteLine($"\t ID: {os.Id} OS Name: {os.Description}");
                }
            }

            io.ReadKey();
        }

        static void Main(string[] args)
        {
            #region +Instances (Models)

            #region +Processors

            var processor_amd_fx = new Processor { Id = 1, Description = "FX9320" };
            var processor_intel_corei7 = new Processor { Id = 2, Description = "COREI7" };
            var processor_qualcomm = new Processor { Id = 3, Description = "QUALCOMM" };

            #endregion

            #region +Computers

            var computer_amd = new Computer { Id = 1, HostName = "HOST-AMD", ProcessorId = 1 };
            var computer_intel = new Computer { Id = 2, HostName = "HOST-INTEL", ProcessorId = 2 };
            var computer_raspberry = new Computer { Id = 3, HostName = "HOST-RASPBERRY", ProcessorId = 3 };

            #endregion

            #region +OS

            var os_linux = new OS { Id = 1, Description = "Linux" };
            var os_windows = new OS { Id = 2, Description = "Windows" };
            var os_macOS = new OS { Id = 3, Description = "macOS" };

            #endregion

            #endregion

            #region +Persistence

            using (var db = new AppDataContext())
            {
                if (!db.Processors.Any())
                {
                    /* Computers */
                    db.Computers.AddRange(new Computer[] { computer_amd, computer_intel, computer_raspberry });
                    /* OSes */
                    db.OperatingSystems.AddRange(new OS[] { os_linux, os_macOS, os_windows });
                    /* Processors */
                    db.Processors.AddRange(new Processor[] { processor_amd_fx, processor_intel_corei7, processor_qualcomm });

                    /* Relationship Samples */
                    computer_amd.OperatingSystems.Add(os_linux);
                    computer_amd.OperatingSystems.Add(os_windows);
                    computer_intel.OperatingSystems.Add(os_macOS);
                    computer_raspberry.OperatingSystems.Add(os_linux);

                    /* Commit */
                    db.SaveChanges();
                }
            }

            #endregion

            Populate();
        }
    }
}
