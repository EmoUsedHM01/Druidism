if (is_player(owner))
{
    var _buffId = noone

    with (o_b_wild_shape)
    {
        if (target == other.owner)
        {
            _buffId = id
            break
        }
    }

    if (_buffId != noone)
    {
        var _hp_before  = owner.HP
        with (_buffId) instance_destroy()
        with (owner) scr_atr_calc(id)
        owner.HP = min(_hp_before, owner.max_hp)
        exit
    }
}

event_inherited()
