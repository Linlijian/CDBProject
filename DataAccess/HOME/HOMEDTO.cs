
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAccess.HOME
{
    [Serializable]
    public class HOMEDTO : BaseDTO
    {
        public HOMEDTO()
        {
            Model = new HOMEModel();   // new โมเดล 
        }

        public HOMEModel Model { get; set; }   //model
        public List<HOMEModel> Models { get; set; }  //list 
    }

    public class HOMEExecuteType : DTOExecuteType
    {
        public const string GetNo = "GetNo";
        public const string Insert = "Insert";
        public const string GetAllAssign = "GetAllAssign";
        public const string GetAssignment = "GetAssignment";
        public const string Update = "Update";
        public const string UpdateFilePacket = "UpdateFilePacket";
        public const string GetFilePacket = "GetFilePacket";
        public const string UpdateAssignment = "UpdateAssignment";
        public const string GetAllStatus = "GetAllStatus";
        public const string GetMenuPrgName = "GetMenuPrgName";
        public const string GetReOpen = "GetReOpen";
        public const string GetExl = "GetExl";
        public const string CallSPInsertExcel = "CallSPInsertExcel";
        public const string ValidateExl = "ValidateExl";
        public const string SaveExl = "SaveExl";
    }
}