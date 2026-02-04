var _play_x = o_player.x 
var _play_y = o_player.y
var _pathGrid2 = o_controller.newgrid
var _enemiesList2 = enemiesList
var _turns2 = 1
with (o_enemy)
{
    if (!keyboard_check(vk_shift))
    {
        if HP >= 1
        {
            if faction_key == "Neutral" && scr_round_cell(point_distance(x, y, _play_x, _play_y)) < 208
            {
                scr_mp_clear_tiles(o_unit)
                if path_exists(path)
                {
                    astar_grid_path(_pathGrid2, path, x, y, _play_x, _play_y, 1)
                    _turns2 = path_get_number(path)
                }
                else
                    _turns2 = ds_list_size(_enemiesList2)
                var _map2 = __dsDebuggerMapCreate()
                ds_map_add_map(_map2, "dataMap", scr_locationRoomEntityMobsSaveDataGet(id))
                ds_map_add(_map2, "turns", _turns2)
                ds_map_add(_map2, "turnsInitial", _turns2)
                ds_map_add(_map2, "locationTag", scr_locationGenerateTag())
                ds_map_add(_map2, "roomTag", scr_locationRoomGenerateTag())
                ds_list_add(_enemiesList2, _map2)
                ds_list_mark_as_map(_enemiesList2, (ds_list_size(_enemiesList2) - 1))
                scr_locationRoomEntityGeneratePresetTag(id, "transition")
            }
        }
    }
}