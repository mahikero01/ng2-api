namespace BTSS_Auth
{
    internal class BL_BE_set_group_access
    {
        public string grp_id { get; set; }

        public string mod_id { get; set; }

        public int can_view { get; set; }

        public int can_add { get; set; }

        public int can_edit { get; set; }

        public int can_delete { get; set; }
    }
}