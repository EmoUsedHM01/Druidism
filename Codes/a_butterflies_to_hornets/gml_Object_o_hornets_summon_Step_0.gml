event_inherited()

// If we're using the hornets sprite, animate via c_index (NPC parents often force image_index=c_index)
if (sprite_index == s_hornets)
{
    if (!variable_instance_exists(id, "c_index"))
        c_index = 0

    // keep it alive if combat code tries to freeze it
    image_speed = 1

    c_index += 1
    if (c_index >= image_number)
        c_index = 0

    image_index = c_index
}
