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
            switch (dto.Execute.ExecuteType)
            {
                case HOMEExecuteType.Insert: return Insert(dto);
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
            switch (dto.Execute.ExecuteType)
            {
                case HOMEExecuteType.Update: return Update(dto);
            }
            return dto;
        }
        private HOMEDTO Update(HOMEDTO dto)
        {
            

            return dto;
        }
        #endregion
    }
}