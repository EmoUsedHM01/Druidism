if (instance_exists(owner))
{
    ds_map_replace(data, "Hit_Chance", 420 + owner.PRC)
}

event_inherited()