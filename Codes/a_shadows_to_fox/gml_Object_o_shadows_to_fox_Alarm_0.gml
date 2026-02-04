var _unit = o_fox_summon
var _x = scr_round_cell(mouse_x)
var _y = scr_round_cell(mouse_y)

with (_unit) // Replace the existing summon, very brute-force
{
    instance_destroy()
}

var _fox = scr_enemy_create(_x, _y, _unit, 0)

if (instance_exists(_fox))
{
    with (_fox)
    {
        image_speed = 1
        is_cheack = 0
        owner = other.owner
        gain_xp *= 0
        can_drop_loot = 0

        scr_effect_create(o_b_druid_summon, 42069, id, id)
    }
}
else
{
    instance_destroy()
}
