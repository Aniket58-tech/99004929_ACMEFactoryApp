using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEFactoryDAL;
using ACMEFactoryDTO;

namespace ACMEFactoryBL
{
    public class ACMEBL
    {
        ACMEDAL obj;
        public ACMEBL()
        {
            obj = new ACMEDAL();
        }
        public void AddNewWorkerDetails(string Name, int Type)
        {
            try
            {
                obj.AddNewWorkerDetails(Name, Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<WorkerDTO> GetAllWorkerDetails()
        {
            try
            {
                var Val = obj.GetAllWorkerDetails();
                return Val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
