using pmlhrDTO;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static pmlhrDTO.CalibrationDTO;


namespace pmlhrDAL
{
    public class CalibrationDAL : DALBase
    {
        private DbCommand command = null;
        CalibrationDTO obj_CalibrationDTO = new CalibrationDTO();

        public DataSet GetInstrumentReferences(int instrumentid) 
        {
            DataSet retDataset = new DataSet();
            using(command = db.GetStoredProcCommand("sp_InstrumentMaster"))
            {
                db.AddInParameter(command,"@Action",DbType.String, "GetRef");
                db.AddInParameter(command, "@InstrumentMasterID", DbType.Int64, instrumentid);
                try
                {
                    retDataset = db.ExecuteDataSet(command);
                }
                catch (Exception ex)
                {
                    errorLog("GetInstrumentReferences", ex.ToString());
                    throw;
                }
            }
            return retDataset;
        }

        public DataSet GetCalibrationTransaction(string Action,int instrumentid, string TypeOfInstrument,int MaintenanceActivityID)
        {
            DataSet retDataset = new DataSet();
            using(command = db.GetStoredProcCommand("sp_CalibrationTransaction"))
            {
                db.AddInParameter(command, "@Action", DbType.String, Action);
                db.AddInParameter(command, "@InstrumentMasterID", DbType.Int64, instrumentid);
                db.AddInParameter(command, "@TypeOfInstrument", DbType.String, TypeOfInstrument);
                db.AddInParameter(command, "@MaintenanceActivityID", DbType.Int32, MaintenanceActivityID);
                try
                {
                    retDataset = db.ExecuteDataSet(command);
                }
                catch(Exception ex)
                {
                    errorLog("GetCalibrationTransaction", ex.ToString());
                    throw;
                }
            }
            return retDataset;
        }


        public DataSet InsertUpdateDeleteCalibration(string Action, long CalibrationTransactionID, int InstrumentMasterID, string InstrumentTypeName, string InstrumentName, string InstrumentLocation, string InstrumentDescription, string InstrumentCalibrationType, 
                                                            string LeastCount, string AcceptanceCriteria, DateTime? CalibrationPlannedDate, DateTime? CalibrationActualDate, string Remark, string TestCertificateNumber, DateTime? InstrumentSubmissionDate, 
                                                            int DivisionID, string DivisionName, int EmployeeID, string EmployeeName, int UserID, string Comments, bool ClosedFlag,string TypeOfInstrument,string Responsible,string DoneBy)
        {
            DataSet retDataset = new DataSet();


            using(command = db.GetStoredProcCommand("sp_CalibrationTransaction"))
            {
                db.AddInParameter(command, "@Action", DbType.String, Action);
                db.AddInParameter(command, "@CalibrationTransactionID", DbType.Int64, CalibrationTransactionID);
                db.AddInParameter(command, "@InstrumentMasterID", DbType.Int32, InstrumentMasterID);
                db.AddInParameter(command, "@InstrumentTypeName", DbType.String, InstrumentTypeName);
                db.AddInParameter(command, "@InstrumentName", DbType.String, InstrumentName);
                db.AddInParameter(command, "@InstrumentLocation", DbType.String, InstrumentLocation);
                db.AddInParameter(command, "@InstrumentDescription", DbType.String, InstrumentDescription);
                db.AddInParameter(command, "@InstrumentCalibrationType", DbType.String, InstrumentCalibrationType);
                db.AddInParameter(command, "@LeastCount", DbType.String, LeastCount);
                db.AddInParameter(command, "@AcceptanceCriteria", DbType.String, AcceptanceCriteria);
                db.AddInParameter(command, "@CalibrationPlannedDate", DbType.DateTime, CalibrationPlannedDate);
                db.AddInParameter(command, "@CalibrationActualDate", DbType.DateTime, CalibrationActualDate);
                db.AddInParameter(command, "@Remark", DbType.String, Remark);
                db.AddInParameter(command, "@TestCertificateNumber", DbType.String, TestCertificateNumber);
                db.AddInParameter(command, "@InstrumentSubmissionDate", DbType.DateTime, InstrumentSubmissionDate);
                db.AddInParameter(command, "@DivisionID", DbType.Int32, DivisionID);
                db.AddInParameter(command, "@DivisionName", DbType.String, DivisionName);
                db.AddInParameter(command, "@EmployeeID", DbType.Int32, EmployeeID);
                db.AddInParameter(command, "@EmployeeName", DbType.String, EmployeeName);
                db.AddInParameter(command, "@UserID", DbType.Int32, UserID);
                db.AddInParameter(command, "@Comments", DbType.String, Comments);
                db.AddInParameter(command, "@ClosedFlag", DbType.Boolean, ClosedFlag);
                db.AddInParameter(command, "@TypeOfInstrument", DbType.String, TypeOfInstrument);
                db.AddInParameter(command, "@DoneBy", DbType.String, DoneBy);
                db.AddInParameter(command, "@Responsible", DbType.String, Responsible);

                try
                {
                    retDataset = db.ExecuteDataSet(command);
                    
                   // obj_CalibrationDTO.CalibrationTransactionList = retDataset.Tables[0].DataTableToList<CalibrationDTO.CalibrationTransaction>();
                }
                catch (Exception ex)
                {
                    errorLog("InsertUpdateDeleteCalibration", ex.ToString());
                    obj_CalibrationDTO.Message = "Server busy try";
                    obj_CalibrationDTO.Code = (int)ErrorCode.ErrorType.DataNotFound;
                }


            }

            return retDataset;
        }


        public CalibrationDTO InsertUpdateDeleteInstrument(string Action,int InstrumentMasterID, string InstrumentTypeName, string InstrumentName, string InstrumentLocation, string InstrumentDescription, string InstrumentCalibrationType,
                                                            string LeastCount, string AcceptanceCriteria, string Frequency, int Duration,int DurationInMonths,int DurationInDays,
                                                            int DivisionID, string DivisionName, DateTime? CalibrationPlannedDate, int EmployeeID, string EmployeeName, int UserID, string Comments, string TypeOfInstrument,DataTable Activities, int departmentid, string DepartmentName)
        {
            //DataSet dataSet = new DataSet();
            using (command = db.GetStoredProcCommand("sp_InstrumentMaster"))
            {
                db.AddInParameter(command, "@Action", DbType.String, Action);
                
                db.AddInParameter(command, "@InstrumentMasterID", DbType.Int32, InstrumentMasterID);
                db.AddInParameter(command, "@InstrumentTypeName", DbType.String, InstrumentTypeName);
                db.AddInParameter(command, "@InstrumentName", DbType.String, InstrumentName);
                db.AddInParameter(command, "@InstrumentLocation", DbType.String, InstrumentLocation);
                db.AddInParameter(command, "@InstrumentDescription", DbType.String, InstrumentDescription);
                db.AddInParameter(command, "@InstrumentCalibrationType", DbType.String, InstrumentCalibrationType);
                db.AddInParameter(command, "@LeastCount", DbType.String, LeastCount);
                db.AddInParameter(command, "@AcceptanceCriteria", DbType.String, AcceptanceCriteria);
                db.AddInParameter(command, "@Frequency", DbType.String, Frequency);
                db.AddInParameter(command, "@Duration", DbType.Int32, Duration);
                db.AddInParameter(command, "@DurationInMonths", DbType.Int32, DurationInMonths);
                db.AddInParameter(command, "@DivisionID", DbType.Int32, DivisionID);
                db.AddInParameter(command, "@DivisionName", DbType.String, DivisionName);
                db.AddInParameter(command, "@CalibrationPlannedDate", DbType.Date, CalibrationPlannedDate);
                db.AddInParameter(command, "@DurationInDays", DbType.Int32, DurationInDays);
                db.AddInParameter(command, "@EmployeeID", DbType.Int32, EmployeeID);
                db.AddInParameter(command, "@EmployeeName", DbType.String, EmployeeName);
                db.AddInParameter(command, "@UserID", DbType.Int32, UserID);
                db.AddInParameter(command, "@Comments", DbType.String, Comments);
                db.AddInParameter(command, "@TypeOfInstrument", DbType.String, TypeOfInstrument);
                db.AddInParameter(command, "@departmentID", DbType.Int32, departmentid);
                db.AddInParameter(command, "@departmentname", DbType.String, DepartmentName);
              
                if (Activities.Rows.Count > 0)
                {
                    SqlParameter sq = new SqlParameter("@MaintenanceActivities", Activities);
                    sq.SqlDbType = SqlDbType.Structured;
                    command.Parameters.Add(sq);
                }

                try
                {
                    //dataSet = db.ExecuteDataSet(command);
                   


                        IDataReader reader = db.ExecuteReader(command);
                        while (reader.Read())
                        {
                            obj_CalibrationDTO.Message = Convert.ToString(reader["Status"]);
                            if (obj_CalibrationDTO.Message == "SUCCESS")
                            {
                                obj_CalibrationDTO.Code = (int)ErrorCode.ErrorType.Success;
                            }
                        else if (obj_CalibrationDTO.Message == "InstrumentNameExist")
                        {
                            obj_CalibrationDTO.Code = (int)ErrorCode.ErrorType.Unsucessful;
                        }
                        else if (obj_CalibrationDTO.Message == "CheckActualDate")
                            {
                               // obj_CalibrationDTO.Message = "Before closing the instrument, please close all actual date records for calibration.";
                                obj_CalibrationDTO.Code = (int)ErrorCode.ErrorType.Unsucessful;
                            }
                            else
                            {
                                obj_CalibrationDTO.Message = "ERROR";
                                obj_CalibrationDTO.Code = (int)ErrorCode.ErrorType.DataNotFound;
                            }
                        }
                      

                }
                catch (Exception ex)
                {
                    errorLog("Instrument", ex.ToString());
                    obj_CalibrationDTO.Message = "Server busy try";
                    obj_CalibrationDTO.Code = (int)ErrorCode.ErrorType.DataNotFound;
                }
               
            }

            return obj_CalibrationDTO;
        }


    }
}
