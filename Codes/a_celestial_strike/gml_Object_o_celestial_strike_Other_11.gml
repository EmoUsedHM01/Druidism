var _currentHour = ds_map_find_value(global.timeDataMap, "hours")
var _night = abs(12 - _currentHour)
var _day = abs(12 - _night)

if (instance_exists(owner))
{
    Arcane_Damage = round(((_night * owner.Magic_Power) / 100))
    Sacred_Damage = round(((_day * owner.Magic_Power) / 100))
}

if (instance_exists(target))
{
    var _dir = direction

    with (instance_create_depth(target.x + irandom_range(-6, 6), target.y + irandom_range(-6, 6), 0, o_spellimpact))
    {
        scr_light_off()
        owner = other.id
        sprite_index = s_celestial_strike_hit
        image_speed = 1
        image_angle = 0
        scr_set_lt()

        if (other.play_impact)
            scr_audio_play_at(choose(snd_arcane_bolt_impact_1, snd_arcane_bolt_impact_2, snd_arcane_bolt_impact_3, snd_arcane_bolt_impact_4))

        repeat (1 + random(3))
        {
            with (instance_create_depth(x + random_range(-3, 3), y, 0, o_lighting_particle))
            {
                speed = 4 + random(4)
                direction = _dir + random_range(-15, 15)
            }
        }
    }
}
else
{
    instance_destroy()
}