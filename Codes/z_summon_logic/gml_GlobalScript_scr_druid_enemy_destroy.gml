function scr_druid_enemy_destroy(argument0)
{
    // Only run in phase 2 (after event_inherited hook)
    if (argument0 != 2)
        exit

    // Only when enemy actually fully dies
    if (!variable_instance_exists(id, "is_full_destroy") || !is_full_destroy)
        exit

    if (!instance_exists(o_player))
        exit

    var _player = o_player.id

    // Vanilla XP condition
    var _vanilla_condition = false
    if (variable_instance_exists(id, "Received_Damage_Priority"))
    {
        _vanilla_condition =
            (scr_tile_distance(id, _player) <= 20) &&
            (ds_map_find_value(Received_Damage_Priority, string(_player)) || is_player(last_attacker))
    }

    // Detection for being killed by a summon
    var _follower_kill = false

    if (instance_exists(last_attacker))
    {
        if (variable_instance_exists(last_attacker, "druid_is_follower") && last_attacker.druid_is_follower)
            _follower_kill = true
    }

    // Fallback: follower contributed damage priority (in case last_attacker isn't the follower)
    // Shamelessly stolen from BW (I love you king)
    if (!_follower_kill)
    {
        if (variable_global_exists("druid_followers") && variable_instance_exists(id, "Received_Damage_Priority"))
        {
            for (var i = 0; i < ds_list_size(global.druid_followers); i++)
            {
                var f = ds_list_find_value(global.druid_followers, i)
                if (instance_exists(f))
                {
                    if (ds_map_find_value(Received_Damage_Priority, string(f)))
                    {
                        _follower_kill = true
                        break
                    }
                }
            }
        }
    }

    // If summon got the kill and player wouldn’t get XP cuz they didn't hit them, grant player XP
    if (_follower_kill && !_vanilla_condition)
    {
        var _gainxp = gain_xp
        var _xp = scr_get_XP(_gainxp)
        scr_actionsLogXP("death", [scr_id_get_name(id)], _xp)
    }
}
