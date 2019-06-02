
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAccess.ACTION
{
    [Serializable]
    public class ACTIONDTO : BaseDTO
    {
        public ACTIONDTO()
        {
            Model = new ACTIONModel();   // new โมเดล 
        }

        public ACTIONModel Model { get; set; }   //model
        public List<ACTIONModel> Models { get; set; }  //list 
    }

    public class ACTIONExecuteType : DTOExecuteType
    {
        public const string Update = "Update";
        public const string Insert = "Insert";
        public const string Delete = "Delete";
        
        public const string GetAllEF = "GetAllEF";
        public const string GetByIDEF = "GetByIDEF";
        public const string UpdateEF = "UpdateEF";
        public const string InsertEF = "InsertEF";
        public const string DeleteEF = "DeleteEF";

    }
}