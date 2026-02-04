event_inherited()

// Drain MP each tick
with (target)
{
    MP = max(0, MP - 10)
    scr_atr_calc(id)

    if (MP <= 0)
    {
        // destroy THIS buff instance
        with (other) 
        {
            var _hp_before  = HP
            with (_buffId) instance_destroy()
            scr_atr_calc(id)
            HP = min(_hp_before, max_hp)
        }
        exit
    }
}