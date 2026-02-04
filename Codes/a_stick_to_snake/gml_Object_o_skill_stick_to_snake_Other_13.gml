event_inherited()
if (!instance_exists(o_player))
    return;
with (o_player)
{
    if instance_exists(o_floor_target)
        var _target = instance_create_depth(o_floor_target.x, o_floor_target.y, 0, o_attacked_target)
}
with (instance_create_depth(target.x + irandom_range(-6, 6), target.y + irandom_range(-6, 6), 0, o_inv_stick_oak))
{
    var _weight = Weight
    var _material = Material
    var _balance = Balance
    var _type = type
    var _loot_object = loot_object
    instance_destroy()
}
with (_loot_object)
{
    alarm[0] = -1
    Balance = _balance
    event_user(2)
    visible = false
    culling = 0
}
with (instance_create_depth(o_player.x, (o_player.y - 6.5), 0, o_throwed_loot))
{
    sprite_index = s_loot_oakstick
    image_speed = 0
    loot_object = _loot_object
    target = _target
    is_weapon = 0
    scr_rest_disable(target)
    owner = o_player
    arrow = id
    Weight = _weight
    Material = _material
    Balance = _balance
    damage = 0
    type = _type
    is_alcohol = 0
    is_beverage = 0
    scr_audio_play_at(snd_snake_attack_1)
}
is_cancel = 0
