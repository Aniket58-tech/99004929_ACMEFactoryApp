using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEFactoryDTO
{
    public class WorkerDTO
    {
        public string workerName { get; set; }
        public int typeOfWorker { get; set; }
        public DateTime workerStartTime { get; set; }
        public DateTime workerEndTime { get; set; }
    }
}
