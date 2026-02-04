if instance_exists(o_player)
{
    if (!instance_exists(target) || !instance_exists(o_player))
        exit

    // If the summon is hostile to player, don't force idle/combat/follow loop
    if (variable_instance_exists(target, "player_hostile") && target.player_hostile)
        exit

    if (variable_instance_exists(target, "target") && instance_exists(target.target) && target.target == o_player.id)
        exit

    // If it's already in combat-ish states, don't be fucking with it
    if (variable_instance_exists(target, "state"))
    {
        if (target.state == "combat" || target.state == "attacking" || target.state == "alarm" || target.state == "threat" || target.state == "attack" || target.state == "skill")
            exit
    }

    var _angy = 0
    with (o_enemy)
    {
        if (scr_round_cell(point_distance(x, y, o_player.x, o_player.y)) < 208) // 208 here means 8 tiles (game uses 26px per tile)
        {
            if (visible && is_visible() && (!(object_is_ancestor(object_index, o_bird_parent))))
            {
                if (!(scr_instance_exists_in_list(o_b_druid_summon, buffs)))
                    _angy++
            }
        }
    }
    if _angy
        target.state = "npc combat"
    else
    {
        with (target)
        {
            state = -4
            if (scr_tile_distance(id, o_player) > 2 && !scr_instance_exists_in_list(o_db_net, buffs) && !scr_instance_exists_in_list(o_db_immob, buffs) && !scr_instance_exists_in_list(o_db_web, buffs) && !scr_instance_exists_in_list(o_db_immobilized_special, buffs))
                scr_turn(o_player.x, o_player.y)
        }
    }
}