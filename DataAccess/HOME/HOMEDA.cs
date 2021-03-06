﻿using DataAccess;
using DBConnectionBase;
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
            switch (dto.Execute.ExecuteType)
            {
                case HOMEExecuteType.GetAll: return GetAll(dto);
                case HOMEExecuteType.GetAllEF: return GetAllEF(dto);
            }
            
            return dto;
        }
        private HOMEDTO GetAll(HOMEDTO dto)
        {
            dto.Model = _DBManger.TEST.FirstOrDefault().ToNewObject(new HOMEModel());
            return dto;
        }
        private HOMEDTO GetAllEF(HOMEDTO dto)
        {
            string sql = @"SELECT TOP (1000) [ID]
                              ,[DATA]
                          FROM [TCDB].[dbo].[TEST]";
            var result = _DBMangerNoEF.ExecuteDataSet(sql, null, commandType: CommandType.Text);
            if (result.Success(dto))
            {
                dto.Models = result.OutputDataSet.Tables[0].ToList<HOMEModel>();
            }
            return dto;
        }
        #endregion

        #region ====Insert==========
        protected override BaseDTO DoInsert(BaseDTO baseDTO)
        {
            var dto = (HOMEDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case HOMEExecuteType.Insert: return Insert(dto);
                case HOMEExecuteType.InsertEF: return InsertEF(dto);
            }

            return dto;
        }
        private HOMEDTO InsertEF(HOMEDTO dto)
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
        private HOMEDTO Insert(HOMEDTO dto)
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
            var dto = (HOMEDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case HOMEExecuteType.Update: return Update(dto);
                case HOMEExecuteType.UpdateEF: return UpdateEF(dto);
            }
            return dto;
        }
        private HOMEDTO UpdateEF(HOMEDTO dto)
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
        private HOMEDTO Update(HOMEDTO dto)
        {


            return dto;
        }
        #endregion

        #region ====Delete==========
        protected override BaseDTO DoDelete(BaseDTO baseDTO)
        {
            var dto = (HOMEDTO)baseDTO;
            switch (dto.Execute.ExecuteType)
            {
                case HOMEExecuteType.Delete: return Delete(dto);
                case HOMEExecuteType.DeleteEF: return DeleteEF(dto);
            }
            return dto;
        }
        private HOMEDTO DeleteEF(HOMEDTO dto)
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
        private HOMEDTO Delete(HOMEDTO dto)
        {
            var model = _DBManger.TEST.Where(m => m.ID == dto.Model.ID);
            _DBManger.TEST.RemoveRange(model);

            return dto;
        }
        #endregion
    }
}