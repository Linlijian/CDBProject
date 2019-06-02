using DataAccess;
using DBConnectionBase;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using UtilityLib;

namespace DataAccess.ACTION
{
    public class ACTIONDA : BaseDA
    {
        public ACTIONDTO DTO { get; set; }

        #region ====Property========
        public ACTIONDA()
        {
            DTO = new ACTIONDTO();
        }

       


        #endregion

        #region ====Select==========
        protected override BaseDTO DoSelect(BaseDTO baseDTO)
        {
            var dto = (ACTIONDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case ACTIONExecuteType.GetAll: return GetAll(dto);
                case ACTIONExecuteType.GetByID: return GetByID(dto);
                case ACTIONExecuteType.GetByIDEF: return GetByIDEF(dto);
                case ACTIONExecuteType.GetAllEF: return GetAllEF(dto);
            }
            
            return dto;
        }
        private ACTIONDTO GetAll(ACTIONDTO dto)
        {
            //dto.Model = _DBManger.TEST.FirstOrDefault().ToNewObject(new ACTIONModel());
            dto.Models = _DBManger.TEST
                  .Select(m => new
                  {
                      ID = m.ID,
                      DATA = m.DATA
                  }).Distinct().Select(m => new ACTIONModel { ID = m.ID, DATA = m.DATA }).ToList();

            return dto;
        }
        private ACTIONDTO GetByID(ACTIONDTO dto)
        {
            dto.Model = _DBManger.TEST.Where(m=>m.ID == dto.Model.ID).FirstOrDefault().ToNewObject(new ACTIONModel());
            
            return dto;
        }
        private ACTIONDTO GetByIDEF(ACTIONDTO dto)
        {
            string sql = @"SELECT TOP (1000) [ID]
                              ,[DATA]
                          FROM [TCDB].[dbo].[TEST] whrer id = @id";

            var parameters = CreateParameter();
            parameters.AddParameter("id", dto.Model.ID);

            var result = _DBMangerNoEF.ExecuteDataSet(sql, parameters, commandType: CommandType.Text);

            if (result.Success(dto))
            {
                dto.Models = result.OutputDataSet.Tables[0].ToList<ACTIONModel>();
            }

            return dto;
        }
        private ACTIONDTO GetAllEF(ACTIONDTO dto)
        {
            string sql = @"SELECT TOP (1000) [ID]
                              ,[DATA]
                          FROM [TCDB].[dbo].[TEST]";
            var result = _DBMangerNoEF.ExecuteDataSet(sql, null, commandType: CommandType.Text);
            if (result.Success(dto))
            {
                dto.Models = result.OutputDataSet.Tables[0].ToList<ACTIONModel>();
            }
            return dto;
        }
        #endregion

        #region ====Insert==========
        protected override BaseDTO DoInsert(BaseDTO baseDTO)
        {
            var dto = (ACTIONDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case ACTIONExecuteType.Insert: return Insert(dto);
                case ACTIONExecuteType.InsertEF: return InsertEF(dto);
            }

            return dto;
        }
        private ACTIONDTO InsertEF(ACTIONDTO dto)
        {
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
        private ACTIONDTO Insert(ACTIONDTO dto)
        {
            if (dto.Model.ID.IsNullOrEmpty())
            {
                dto.Model.ID = _DBManger.TEST.Max(m => m.ID) + 1;
            }

            var model = dto.Model.ToNewObject(new TEST());
            _DBManger.TEST.Add(model);

            return dto;
        }
        #endregion

        #region ====Update==========
        protected override BaseDTO DoUpdate(BaseDTO baseDTO)
        {
            var dto = (ACTIONDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case ACTIONExecuteType.Update: return Update(dto);
                case ACTIONExecuteType.UpdateEF: return UpdateEF(dto);
            }
            return dto;
        }
        private ACTIONDTO UpdateEF(ACTIONDTO dto)
        {
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
        private ACTIONDTO Update(ACTIONDTO dto)
        {
            var ID = dto.Model.ID;
            var model = _DBManger.TEST.First(m => m.ID == ID);
            model.MergeObject(dto.Model);

            return dto;
        }
        #endregion

        #region ====Delete==========
        protected override BaseDTO DoDelete(BaseDTO baseDTO)
        {
            var dto = (ACTIONDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case ACTIONExecuteType.Delete: return Delete(dto);
                case ACTIONExecuteType.DeleteEF: return DeleteEF(dto);
            }
            return dto;
        }
        private ACTIONDTO DeleteEF(ACTIONDTO dto)
        {
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
        private ACTIONDTO Delete(ACTIONDTO dto)
        {
            var model = _DBManger.TEST.Where(m => m.ID == dto.Model.ID);
            _DBManger.TEST.RemoveRange(model);

            return dto;
        }
        #endregion
    }
}