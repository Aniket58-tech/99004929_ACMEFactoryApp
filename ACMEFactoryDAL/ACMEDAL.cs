using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEFactoryDTO;

namespace ACMEFactoryDAL
{
    public class ACMEDAL
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public ACMEDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ACMEFactoryConStr"].ToString());
        }
        public List<WorkerDTO> GetAllWorkerDetails()
        {
            try
            {
                List<WorkerDTO> lst = new List<WorkerDTO>();
                ACMEFactoryContext Context = new ACMEFactoryContext();
                var workerList = Context.uspAddWorkers.ToList();
                foreach (var dept in workerList)
                {
                    lst.Add(
                        new WorkerDTO
                        {
                            workerName = workerList.workerName,
                            typeOfWorker = workerList.typeOfWorker,
                            workerStartTime = workerList.workerStartTime,
                            workerEndTime = workerList.workerEndTime
                        }
                        );
                }
                return lst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int AddNewWorkerDetails(string Name, int Type)
        {
            
            sqlCmdObj = new SqlCommand("dbo.uspAddWorker", sqlConObj);
            sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@workerName", Name);
            sqlCmdObj.Parameters.AddWithValue("@typeOfWorker", Type);
            try
            {
                sqlConObj.Open();
                WorkerDTO obj = new WorkerDTO();
                //List<WorkerDTO>=new List
                int row = sqlCmdObj.ExecuteNonQuery();
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public int DeleteWorker(int ID, out int rows2)
        {
            sqlCmdObj = new SqlCommand("dbo.uspDeleteWorker", sqlConObj);
            sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@WorkerId", ID);
            try
            {
                sqlConObj.Open();
                SqlParameter parameter = sqlCmdObj.Parameters.Add("ReturnValue", System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                rows2 = sqlCmdObj.ExecuteNonQuery();
                int results2 = (int)parameter.Value;
                return results2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
        public int ModifyWorker(string id, DateTime starttime, DateTime endtime, out int rows1)
        {
            sqlCmdObj = new SqlCommand("dbo.uspModifyCourseDuration", sqlConObj);
            sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@Workerid", id);
            sqlCmdObj.Parameters.AddWithValue("@starttime", starttime);
            sqlCmdObj.Parameters.AddWithValue("@endtime", endtime);
            try
            {
                sqlConObj.Open();
                SqlParameter parameter = sqlCmdObj.Parameters.Add("ReturnValue", SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                rows1 = sqlCmdObj.ExecuteNonQuery();
                int results1 = (int)parameter.Value;
                return results1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
}
