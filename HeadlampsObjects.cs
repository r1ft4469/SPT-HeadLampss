using System.Collections.Generic;

namespace r1ft.Headlamps
{
    internal static class HeadLamps
    {
        public static readonly string Head = "PlayerSuperior(Clone)/Player/Root_Joint/Base HumanPelvis/Base HumanSpine1/Base HumanSpine2/Base HumanSpine3/Base HumanNeck/Base HumanHead/";

        public static readonly string Mode = "/mode_00";

        public static string[] Helmets = new[]
        {
            "item_equipment_helmet_opsCore_fast_black(Clone)/mod_mount",
            "item_equipment_helmet_opsCore_fast_tan(Clone)/mod_mount",
            "item_equipment_helmet_galvion_caiman(Clone)/mod_mount",
            "item_equipment_helmet_mich2001_od(Clone)/mod_mount",
            "item_equipment_helmet_mich2002_od(Clone)/mod_mount",
            "item_equipment_helmet_tc800(Clone)/mod_mount",
            "item_equipment_helmet_nfm_hjelm(Clone)/mod_mount",
            "item_equipment_helmet_LSHZ(Clone)/mod_mount",
            "item_equipment_helmet_hops_core_fast(Clone)/mod_mount",
            "item_equipment_helmet_crye_airframe_tan(Clone)/mod_mount"
        };

        public static string[] Mounts = new[]
        {
            "/item_equipment_helmet_opsCore_single_clamp_rail_adapter(Clone)/mod_flashlight/",
            "/item_equipment_helmet_opsCore_picatinny_rail_adapter(Clone)/mod_mount/"
        };

        public static string[] Lights = new[] {
            Mounts[0] + "flashlight_ultrafire_WF-501B(Clone)",
            Mounts[0] + "flashlight_armytek_predator_pro_v3_xhp35_hi(Clone)",
            Mounts[1] + "tactical_all_surefire_x400_vis_laser(Clone)",
            Mounts[1] + "tactical_all_zenit_2p_kleh_vis_laser(Clone)"
        };
    }
}
