with (target)
{
    if faction_key == "Neutral"
        is_neutral = 1
    else
        is_neutral = 0
    loot_script = -4
}
if instance_exists(o_player)
    alarm[6] = 1
