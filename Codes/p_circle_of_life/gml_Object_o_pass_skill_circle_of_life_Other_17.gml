if (is_open)
{
    if (instance_exists(owner))
    {
        var _hp_missing_pct = 100 - ((owner.HP / owner.max_hp) * 100);

        ds_map_replace(data, "Healing_Received", 2 * _hp_missing_pct);
        ds_map_replace(data, "Health_Restoration", 2 * _hp_missing_pct);
        ds_map_replace(data, "max_hp", 10);
        ds_map_replace(data, "Fatigue_Gain", 10);
    }
}
event_inherited();
