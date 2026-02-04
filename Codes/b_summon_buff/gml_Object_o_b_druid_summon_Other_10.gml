adjacent_enemies = 0
var _range = target.VSN
with (o_enemy)
{
    if (!(object_is_ancestor(object_index, o_bird_parent)))
    {
        if (!(scr_instance_exists_in_list(o_b_druid_summon, buffs)))
        {
            if (id != other.target && HP > 0 && scr_tile_distance(id, other.target) <= 1)
                other.adjacent_enemies = 1
        }
    }
}
with (target)
{
    isLootDropped = 0
    can_drop_loot = 0
    isMiniboss = 0
    can_speak = 0
}
if (instance_exists(o_player) && instance_exists(target))
{
    event_user(13)
    event_user(5)
    if (check == 2 && adjacent_enemies)
    {
        with (target)
            ds_list_add(lock_turn, 1)
    }
    else if ((!(scr_instance_exists_in_list(o_db_immob, target.buffs))) || (!(scr_instance_exists_in_list(o_db_web, target.buffs))) || (!(scr_instance_exists_in_list(o_db_net, target.buffs))) || (!(scr_instance_exists_in_list(o_db_immobilized_special, target.buffs))))
    {
        with (target)
            ds_list_delete(lock_turn, 0)
    }
}
if (instance_exists(o_player) && instance_exists(o_NPC))
{
    with (o_NPC)
    {
        if (visible & is_visible())
        {
            if (!(scr_instance_exists_in_list(o_db_crime_wanted, o_player.buffs)))
            {
                scr_npc_disorder()
            }
        }
    }
}
