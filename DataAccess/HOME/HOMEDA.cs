using DataAccess;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using UtilityLib;

namespace DataAccess.HOME
{
    public class HOMEDA : BaseDA
    {
        public HOMEDTO DTO { get; set; }

        #region ====Property========
        public HOMEDA()
        {
            DTO = new HOMEDTO();
        }

       


        #endregion

        #region ====Select==========
        protected override BaseDTO DoSelect(BaseDTO baseDTO)
        {
            var dto = (HOMEDTO)baseDTO;
            //switch (dto.Execute.ExecuteType)
            //{
            //    case HOMEExecuteType.GetAll: return GetAll(dto);
            //}
            string sql = @"SELECT TOP (1000) [ID]
                              ,[DATA]
                          FROM [TCDB].[dbo].[TEST] ";
            var result = _DBMangerNoEF.ExecuteDataSet(sql, null, commandType: CommandType.Text);
            if (result.Success(dto))
            {
                dto.Models = result.OutputDataSet.Tables[0].ToList<HOMEModel>();
            }
            return dto;
        }

        #endregion
        private HOMEDTO GetAll(HOMEDTO dto)
        {


            return dto;
        }
        #region ====Insert==========
        protected override BaseDTO DoInsert(BaseDTO baseDTO)
        {
            var dto = (HOMEDTO)baseDTO;
            //switch (dto.Execute.ExecuteType)
            //{
            //    case HOMEExecuteType.Insert: return Insert(dto);
            //}
            string sql = @"INSERT INTO [dbo].[TEST]
           ([ID]
           ,[DATA])
     VALUES
           (@id
           ,@data)";
            var parameters = CreateParameter();
            parameters.AddParameter("id", dto.Model.ID);
            parameters.AddParameter("data", dto.Model.DATA);
            var result = _DBMangerNoEF.ExecuteNonQuery(sql, parameters, CommandType.Text);
            if (!result.Success(dto))
            {
                dto.Result.IsResult = false;
                dto.Result.ResultMsg = result.ErrorMessage;
            }
            return dto;
        }
        private HOMEDTO Insert(HOMEDTO dto)
        {


            return dto;
        }
        #endregion

        #region ====Update==========
        protected override BaseDTO DoUpdate(BaseDTO baseDTO)
        {
            var dto = (HOMEDTO)baseDTO;
            //switch (dto.Execute.ExecuteType)
            //{
            //    case HOMEExecuteType.Update: return Update(dto);
            //}
            string sql = @"update [dbo].[TEST] set data = @data where id = 1";
            var parameters = CreateParameter();
            parameters.AddParameter("id", dto.Model.ID);
            parameters.AddParameter("data", dto.Model.DATA);
            var result = _DBMangerNoEF.ExecuteNonQuery(sql, parameters, CommandType.Text);
            if (!result.Success(dto))
            {
                dto.Result.IsResult = false;
                dto.Result.ResultMsg = result.ErrorMessage;
            }
            return dto;
        }
        private HOMEDTO Update(HOMEDTO dto)
        {
            

            return dto;
        }
        #endregion

        #region ====Delete==========
        protected override BaseDTO DoDelete(BaseDTO baseDTO)
        {
            var dto = (HOMEDTO)baseDTO;
            //switch (dto.Execute.ExecuteType)
            //{
            //    case HOMEExecuteType.Update: return Update(dto);
            //}
            string sql = @"delete from [dbo].[TEST] where id = @id";
            var parameters = CreateParameter();
            parameters.AddParameter("id", dto.Model.ID);
            var result = _DBMangerNoEF.ExecuteNonQuery(sql, parameters, CommandType.Text);
            if (!result.Success(dto))
            {
                dto.Result.IsResult = false;
                dto.Result.ResultMsg = result.ErrorMessage;
            }
            return dto;
        }
        private HOMEDTO Delete(HOMEDTO dto)
        {


            return dto;
        }
        #endregion
    }
}