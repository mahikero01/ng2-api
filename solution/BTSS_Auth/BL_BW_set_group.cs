using System;
using System.Data;

namespace BTSS_Auth
{
    public class BL_BW_set_group : IDisposable
    {
        private BL_BE_set_user _setUserBLBE;
        private DL_DA_set_group _setGroupDLDA;
        private DataTable _setGroupDT;
        public string _errorMessage;

        public BL_BW_set_group()
        {
            this._setUserBLBE = new BL_BE_set_user();
            this._setGroupDLDA = new DL_DA_set_group();
            this._setGroupDT = new DataTable();
            this._errorMessage = "";
        }

        public void Dispose()
        {
            this._setGroupDT = null;
            this._setGroupDLDA = null;
        }

        public string GetGroupID(string userName)
        {
            string status = "0";

            this._setUserBLBE.user_name = userName;
            this._setGroupDT = this._setGroupDLDA.ReadGroupID(this._setUserBLBE);
            this._errorMessage = this._setGroupDLDA._errorMessage;

            //if error is detected return -1
            if (!(String.Compare(this._errorMessage, "") == 0))
            {
                return "-1";
            }

            //if no error found set ID number for return if there is data
            foreach (DataRow groupID in this._setGroupDT.Rows)
            {
                status = groupID[0].ToString();
            }

            return status;
        }
    }
}