﻿
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
        public const string Update = "Update";
        public const string Insert = "Insert";
        public const string Delete = "Delete";
        
        public const string GetAllEF = "GetAllEF";
        public const string UpdateEF = "UpdateEF";
        public const string InsertEF = "InsertEF";
        public const string DeleteEF = "DeleteEF";

    }
}