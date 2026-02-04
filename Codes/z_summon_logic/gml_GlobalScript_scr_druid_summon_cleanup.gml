function scr_druid_summon_cleanup()
{
    var _inst = id
    if (argument_count > 0)
        _inst = argument[0]

    if (!variable_global_exists("druid_summons"))
        exit

    if (!instance_exists(_inst))
        exit

    // Skibidi toilet or something
    if (variable_instance_exists(_inst, "druid_summon_key"))
    {
        var _key = _inst.druid_summon_key

        if (ds_map_exists(global.druid_summons, _key))
        {
            var _cur = ds_map_find_value(global.druid_summons, _key)
            if (_cur == _inst)
                ds_map_delete(global.druid_summons, _key)
        }
    }
}
