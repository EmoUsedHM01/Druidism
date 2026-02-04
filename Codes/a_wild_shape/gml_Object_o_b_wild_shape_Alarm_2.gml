event_inherited()
var _feral = (1 + bear + (feral * 0.5))

// "other" here is the buff instance (o_b_wild_shape)
with (target)
{
    // Snapshot BEFORE changing stats
    var _hp_before  = HP

    // apply stat changes
    ds_map_add(other.data, "max_hp", 20 * _feral)
    ds_map_add(other.data, "Hit_Chance", 5 * _feral)
    ds_map_add(other.data, "EVS", 25 * _feral)
    ds_map_add(other.data, "FMB", -5 * _feral)
    ds_map_add(other.data, "Bleeding_Chance", 30 * _feral)
    ds_map_add(other.data, "Armor_Piercing", 30 * _feral)
    ds_map_set(other.data, "Rending_Damage", 21 * _feral)
    if (other.bear == 1)
        ds_map_set(other.data, "Duration_Resistance", 1)

    // Recalc (this is what causes the 'free heal' from max_hp)
    scr_atr_calc(id)

    // Revert HP back to the original value
    HP = _hp_before
}