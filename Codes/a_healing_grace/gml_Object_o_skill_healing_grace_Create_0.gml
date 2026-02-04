event_inherited()
skill = "healing_grace"
ds_list_add(attribute, ds_map_find_value(global.attribute, "Vitality"), ds_map_find_value(global.attribute, "WIL"))
scr_skill_atr()
spell = o_healing_grace_birth
filter = gml_Script_scr_barrier_filter
click_snd = -4
