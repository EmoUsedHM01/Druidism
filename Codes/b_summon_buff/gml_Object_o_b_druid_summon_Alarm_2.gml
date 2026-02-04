event_user(5)
var _count = false
with o_enemy
{
    if id != other.target 
    {
        if visible && is_visible(id) && !scr_instance_exists_in_list(o_b_druid_summon, buffs) && !object_is_ancestor(object_index, o_bird_parent)
            _count = true
    }
}
if _count
    check = 0
else
    check = 1
