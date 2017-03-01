using System;

namespace BTSS_Auth
{
    public class BL_ApplicationFacade
    {
        public static string _errorMessage = "ERROR: ";

        //this will get userid
        public static string GetUserIDTask(string userName)
        {
            string status = "";

            using (BL_BW_set_user setUserBLBW = new BL_BW_set_user())
            {
                status = setUserBLBW.GetUserID(userName);

                if (String.Compare(status, "-1") == 0)
                {
                    _errorMessage = _errorMessage + setUserBLBW._errorMessage;
                    return _errorMessage;
                }
            }

            return status;
        }

        //this will get groupID
        public static string GetGroupIDTask(string userName)
        {
            string status = "";

            using (BL_BW_set_group setGroupBLBW = new BL_BW_set_group())
            {
                status = setGroupBLBW.GetGroupID(userName);

                if (String.Compare(status, "-1") == 0)
                {
                    _errorMessage = _errorMessage + setGroupBLBW._errorMessage;
                    return _errorMessage;
                }
            }

            return status;
        }

        //this will check current page if accessible if accessible will return "1" if not "0"
        public static string CheckModuleAccess(string userName, string curPage)
        {
            string status = "";

            using (BL_BW_set_module setModuleBLBW = new BL_BW_set_module())
            {
                status = setModuleBLBW.CheckModuleAccess(userName, curPage);

                if (String.Compare(status, "-1") == 0)
                {
                    _errorMessage = _errorMessage + setModuleBLBW._errorMessage;
                    return _errorMessage;
                }
            }

            return status;
        }
    }
}