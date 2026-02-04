event_inherited()
alarm[7] = 1

if (instance_exists(target))
{
    if (target.faction_key == "Neutral")
    {
        // Don't wipe attacker tracking if it's actually hostile
        if (variable_instance_exists(target, "player_hostile") && target.player_hostile)
            exit

        if (variable_instance_exists(target, "_last_attacker"))
            target._last_attacker = -4
        else if (variable_instance_exists(target, "last_attacker"))
            target.last_attacker = -4
    }
}