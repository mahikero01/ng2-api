using System.Data;
using System.Data.SqlClient;

namespace BTSS_Auth
{
    public class DL_DA_set_module : DL_DU_DbContext
    {
        public DataTable ReadModuleName(BL_BE_set_user setUserBLBE, BL_BE_set_module setModuleBLBE)
        {
            var param = new SqlCommand().Parameters;

            param.AddWithValue(BL_BC_AppCons.PM_SETUSER_USERNAME, setUserBLBE.user_name);
            param.AddWithValue(BL_BC_AppCons.PM_SETMODULE_MODNAME, setModuleBLBE.mod_name);

            return this.GetData(BL_BC_AppCons.SP_SETMODULE_READMODULENAME, param);
        }
    }
}