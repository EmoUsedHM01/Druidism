event_inherited()

with (target)
{
    ds_map_clear(other.data)
    ds_map_add(other.data, "FMB", 30)
    ds_map_add(other.data, "Miscast_Chance", 30)
    ds_map_add(other.data, "EVS", -100)
    ds_map_add(other.data, "PRR", -50)
    ds_map_add(other.data, "Block_Recovery", -0.5 * Block_Recovery)
    ds_map_add(other.data, "CTA", -50)
    
    if (object_index == o_harpy)
        scr_enemy_change_form(s_harpy)
    
    if (is_player())
        scr_random_speech("debuffNet")
}

net = scr_onUnitEffectCreate(target, o_onUnitEffectRoot, -55)
duration = min(duration, 8)