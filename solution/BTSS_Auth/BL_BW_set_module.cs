using System;
using System.Data;

namespace BTSS_Auth
{
    public class BL_BW_set_module : IDisposable
    {
        private BL_BE_set_user _setUserBLBE;
        private BL_BE_set_module _setModuleBLBE;
        private DL_DA_set_module _setModuleDLDA;
        private DataTable _setModuleDT;
        public string _errorMessage;

        public BL_BW_set_module()
        {
            this._setUserBLBE = new BL_BE_set_user();
            this._setModuleBLBE = new BL_BE_set_module();
            this._setModuleDLDA = new DL_DA_set_module();
            this._setModuleDT = new DataTable();
            this._errorMessage = "";
        }

        public void Dispose()
        {
            this._setModuleDT = null;
            this._setModuleDLDA = null;
            this._setUserBLBE = null;
        }

        public string CheckModuleAccess(string userName, string curPage)
        {
            this._setUserBLBE.user_name = userName;
            this._setModuleBLBE.mod_name = curPage;
            this._setModuleDT = this._setModuleDLDA.ReadModuleName(this._setUserBLBE, this._setModuleBLBE);
            this._errorMessage = this._setModuleDLDA._errorMessage;

            //if error is detected return -1
            if (!(String.Compare(this._errorMessage, "") == 0))
            {
                return "-1";
            }

            //if no error found return list of module name
            if (this._setModuleDT.Rows.Count > 0)
            {
                return "1";
            }

            return "0";
        }
    }
}