event_inherited()

with (target)
{
    ds_list_delete(lock_turn, 0)
    
    if (object_index == o_harpy)
    {
        if (ds_map_find_value(Body_Parts_map, "rhand") > 50 && ds_map_find_value(Body_Parts_map, "lhand") > 50)
            scr_enemy_change_form(s_harpy_fly)
    }
}

net = scr_onUnitEffectDestroy(net)

with (target)
    scr_simple_particles_create(s_webparts, 5, false)