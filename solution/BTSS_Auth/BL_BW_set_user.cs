using System;
using System.Data;

namespace BTSS_Auth
{
    public class BL_BW_set_user : IDisposable
    {
        private BL_BE_set_user _setUserBLBE;
        private DL_DA_set_user _setUserDLDA;
        private DataTable _setUserDT;
        public string _errorMessage;

        public BL_BW_set_user()
        {
            this._setUserBLBE = new BL_BE_set_user();
            this._setUserDLDA = new DL_DA_set_user();
            this._setUserDT = new DataTable();
            this._errorMessage = "";
        }

        public void Dispose()
        {
            this._setUserDT = null;
            this._setUserDLDA = null;
            this._setUserBLBE = null;
        }

        //this will -1 if error is detected
        public string GetUserID(string userName)
        {
            string status = "0";

            this._setUserBLBE.user_name = userName;
            this._setUserDT = this._setUserDLDA.ReadUserID(this._setUserBLBE);
            this._errorMessage = this._setUserDLDA._errorMessage;

            //if error is detected return -1
            if (!(String.Compare(this._errorMessage, "") == 0))
            {
                return "-1";
            }

            //if no error found set ID number for return
            foreach (DataRow user_id in this._setUserDT.Rows)
            {
                status = user_id[0].ToString();
            }

            return status;
        }
    }
}