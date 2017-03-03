using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTSS_Auth
{
    public class BLBW_SetUserSetGroup
    {
        #region "Protected Attributes"

        protected DLDA_DbContext _comDAL;

        #endregion "Protected Attributes"

        #region "Public Attributes"

        public string _errorMessage;

        #endregion "Public Attributes"

        #region "Protected Methods"

        protected SqlParameterCollection InjectDep(BLBE_UserInfo userInfo)
        {
            var parArray = new SqlCommand().Parameters;

            parArray.AddWithValue(BLBC_Constant.PM_USRID, userInfo.user_id);
            parArray.AddWithValue(BLBC_Constant.PM_USRNME, userInfo.user_name);
            parArray.AddWithValue(BLBC_Constant.PM_LSTNME, userInfo.user_last_name);
            parArray.AddWithValue(BLBC_Constant.PM_FSTNME, userInfo.user_first_name);
            parArray.AddWithValue(BLBC_Constant.PM_MIDNME, userInfo.user_middle_name);
            parArray.AddWithValue(BLBC_Constant.PM_CDTUSR, userInfo.created_date_user);
            parArray.AddWithValue(BLBC_Constant.PM_GRPID, userInfo.grp_id);
            parArray.AddWithValue(BLBC_Constant.PM_GRPNME, userInfo.grp_name);
            parArray.AddWithValue(BLBC_Constant.PM_GRPDES, userInfo.grp_desc);
            parArray.AddWithValue(BLBC_Constant.PM_CDTGRP, userInfo.created_date_grp);
            parArray.AddWithValue(BLBC_Constant.PM_MODID, userInfo.mod_id);
            parArray.AddWithValue(BLBC_Constant.PM_MODNME, userInfo.mod_name);
            parArray.AddWithValue(BLBC_Constant.PM_MODDES, userInfo.mod_desc);
            parArray.AddWithValue(BLBC_Constant.PM_CDTMOD, userInfo.created_date_mod);

            return parArray;
        }

        #endregion "Protected Methods"

        #region "Public Methods"

        public BLBW_SetUserSetGroup()
        {
            this._comDAL = new DLDA_DbContext();
            this._errorMessage = "";
        }

        //get set_user_set_group
        public List<BLBE_UserInfo> ReadSetUserSetGroup(BLBE_UserInfo userInfo)
        {
            BLBE_UserInfo blbeCommon;
            DataTable dataTable = new DataTable();
            List<BLBE_UserInfo> userList = new List<BLBE_UserInfo>();

            dataTable = this._comDAL.GetData(BLBC_Constant.SP_USERGROUP_GET, InjectDep(userInfo));
            this._errorMessage = this._comDAL._errorMessage;

            if (dataTable == null)
                return userList;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                blbeCommon = new BLBE_UserInfo();
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

        //check if user is authenticated
        public bool IsUserAuthenticated(BLBE_UserInfo userInfo)
        {
            List<BLBE_UserInfo> userList = new List<BLBE_UserInfo>();

            userList = this.ReadSetUserSetGroup(userInfo);

            if (String.Compare(this._errorMessage, "") != 0)
                return false;

            if (userList.Count == 0)
                return false;

            return true;
        }

        //check if user is authorized
        public bool IsUserAuthorized(BLBE_UserInfo userInfo)
        {
            List<BLBE_UserInfo> userList = new List<BLBE_UserInfo>();

            userList = this.ReadSetUserSetGroup(userInfo);

            if (String.Compare(this._errorMessage, "") != 0)
                return false;

            if (userList.Count == 0)
                return false;

            return true;
        }

        #endregion "Public Methods"
    }
}