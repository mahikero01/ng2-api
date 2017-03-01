﻿using System.Data;
using System.Data.SqlClient;

namespace BTSS_Auth
{
    public class DL_DA_set_group : DL_DU_DbContext
    {
        public DataTable ReadGroupID(BL_BE_set_user setUserBLBE)
        {
            var param = new SqlCommand().Parameters;

            param.AddWithValue(BL_BC_AppCons.PM_SETUSER_USERNAME, setUserBLBE.user_name);

            return this.GetData(BL_BC_AppCons.SP_SETGROUP_READGROUPID, param);
        }
    }
}