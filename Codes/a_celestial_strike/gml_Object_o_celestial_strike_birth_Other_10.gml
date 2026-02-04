if (instance_exists(point) && instance_exists(owner) && (!is_execute))
    point = scr_shoot_target_miss(point, owner, (100 + (1.5 * owner.PRC)), 0)

if (!is_execute)
    scr_audio_play_at(snd_arcane_bolt_casting_1)

event_inherited()
