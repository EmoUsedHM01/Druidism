event_inherited()
with (target)
{
    if !other.feral
	{
		ds_list_delete(lock_spells, 0)
    }
	if is_player()
    {
        with (o_skill)
            event_user(8)
    }
}