if (instance_exists(owner) && instance_exists(target))
{
    target = scr_shoot_target_miss(target, owner, 420 + owner.PRC, false)
    
    if (instance_exists(target))
    {
        var _owner = owner
        var _buff = -4
        var _shield = false
        
        with (target)
        {
            if (variable_instance_exists(id, "size") && instance_is(id, o_unit))
            {
                _shield = scr_instance_exists_in_list(o_b_aether_shield)
                
                if (size != "tiny" && size != "giant")
                {
                    if (!_shield)
                        _buff = scr_effect_create(o_db_rooted, irandom_range(6, 8), id, _owner)
                }
            }
        }
        
        if (_buff)
        {            
            with (target)
                scr_audio_play_at(snd_stoneeater_salvo_hit_3)
        }
        else
        {
            with (target)
            {
                if (!_shield)
                {
                    with (scr_guiAnimation(s_webthrow_miss, 1, 1, 0)) // Should always hit, so this is just a fallback
                    {
                        scr_audio_play_at(snd_stoneeater_salvo_hit_3)
                        scale_update = false
                        image_xscale = _owner.image_xscale
                    }
                }
                else
                {
                    scr_skill_call_buff(o_b_aether_shield, id, "absorb")
                }
            }
        }
    }
}

instance_destroy()
