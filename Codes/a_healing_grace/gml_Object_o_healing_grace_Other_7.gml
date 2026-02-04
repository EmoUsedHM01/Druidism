if (instance_exists(target))
{
    add_condition = 35 // Same as a Splint

    with (o_wound)
    {
        if (target == other.target) // Only affect wounds on the target, don't wanna heal the whole room innit
        {
            var _conditions_restore = stability_value + other.add_condition
            ds_map_replace(target.Body_Parts_map, Body_Part, min(100, _conditions_restore))
            event_user(0)
        }
    }

    scr_restore_hp(target, 0.3 * target.max_hp, scr_id_get_name(id))
}

event_inherited()