using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_OOP_Enum
{
    [Flags]
    public enum WorkDays
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
        WK = Monday | Tuesday | Wednesday,
    }

    public class Schedule
    {
        public WorkDays WorkDays { get; set; }
        public void PrincSchedule()
        {
            Console.WriteLine($"Work schedule: {WorkDays}");
        }
    }

    [Flags]
    public enum UserRole
    {
        None = 0,
        Admin = 1 << 0, // 1
        Editor = 1 << 1, // 2
        Viewer = 1 << 2, // 4
        Manager = 1 << 3  // 8
    }

}
