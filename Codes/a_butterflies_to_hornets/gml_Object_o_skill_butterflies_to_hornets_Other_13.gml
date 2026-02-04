event_inherited()
if (!instance_exists(o_player))
    return;
with (o_player)
{
    if instance_exists(o_floor_target)
        var _target = instance_create_depth(o_floor_target.x, o_floor_target.y, 0, o_attacked_target)
}
is_cancel = 0
