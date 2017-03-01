using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTSS_Auth
{
    public class BL_BW_set_user_set_group
    {
        #region "Protected Attributes"

        protected DL_DU_DbContext _comDAL;

        #endregion "Protected Attributes"

        #region "Public Attributes"

        public string _errorMessage;

        #endregion "Public Attributes"

        #region "Protected Methods"

        protected SqlParameterCollection InjectDep(BL_BE_Common userInfo)
        {
            var parArray = new SqlCommand().Parameters;

            parArray.AddWithValue(BL_BC_AppCons.PM_USRID, userInfo.user_id);
            parArray.AddWithValue(BL_BC_AppCons.PM_USRNME, userInfo.user_name);
            parArray.AddWithValue(BL_BC_AppCons.PM_LSTNME, userInfo.user_last_name);
            parArray.AddWithValue(BL_BC_AppCons.PM_FSTNME, userInfo.user_first_name);
            parArray.AddWithValue(BL_BC_AppCons.PM_MIDNME, userInfo.user_middle_name);
            parArray.AddWithValue(BL_BC_AppCons.PM_CDTUSR, userInfo.created_date_user);
            parArray.AddWithValue(BL_BC_AppCons.PM_GRPID, userInfo.grp_id);
            parArray.AddWithValue(BL_BC_AppCons.PM_GRPNME, userInfo.grp_name);
            parArray.AddWithValue(BL_BC_AppCons.PM_GRPDES, userInfo.grp_desc);
            parArray.AddWithValue(BL_BC_AppCons.PM_CDTGRP, userInfo.created_date_grp);
            parArray.AddWithValue(BL_BC_AppCons.PM_MODID, userInfo.mod_id);
            parArray.AddWithValue(BL_BC_AppCons.PM_MODNME, userInfo.mod_name);
            parArray.AddWithValue(BL_BC_AppCons.PM_MODDES, userInfo.mod_desc);
            parArray.AddWithValue(BL_BC_AppCons.PM_CDTMOD, userInfo.created_date_mod);

            return parArray;
        }

        #endregion "Protected Methods"

        #region "Public Methods"

        public BL_BW_set_user_set_group()
        {
            this._comDAL = new DL_DU_DbContext();
            this._errorMessage = "";
        }

        //get set_user_set_group
        public List<BL_BE_Common> ReadSetUser(BL_BE_Common userInfo)
        {
            BL_BE_Common blbeCommon;
            DataTable dataTable = new DataTable();
            List<BL_BE_Common> userList = new List<BL_BE_Common>();

            dataTable = this._comDAL.GetData(BL_BC_AppCons.SP_USERGROUP_GET, InjectDep(userInfo));
            this._errorMessage = this._comDAL._errorMessage;

            if (dataTable == null)
                return userList;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                blbeCommon = new BL_BE_Common();
                blbeCommon.user_id = dataRow["user_id"].ToString();
                blbeCommon.user_name = dataRow["user_name"].ToString();
                blbeCommon.user_last_name = dataRow["user_last_name"].ToString();
                blbeCommon.user_first_name = dataRow["user_first_name"].ToString();
                blbeCommon.user_middle_name = dataRow["user_middle_name"].ToString();
                blbeCommon.created_date_user = dataRow["created_date_user"].ToString();
                blbeCommon.grp_id = dataRow["grp_id"].ToString();
                blbeCommon.grp_name = dataRow["grp_name"].ToString();
                blbeCommon.grp_desc = dataRow["grp_desc"].ToString();
                blbeCommon.created_date_grp = dataRow["created_date_grp"].ToString();
                userList.Add(blbeCommon);
            }

            return userList;
        }

        //check if user is authorized
        public bool IsUserAuthorized(BL_BE_Common userInfo)
        {
            List<BL_BE_Common> userList = new List<BL_BE_Common>();

            userList = this.ReadSetUser(userInfo);

            if (String.Compare(this._errorMessage, "") != 0)
                return false;

            if (userList.Count == 0)
                return false;

            return true;
        }

        #endregion "Public Methods"
    }
}