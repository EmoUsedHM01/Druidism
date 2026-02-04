event_inherited()
xx = 0
skill = "celestial_strike"
ds_list_add(attribute, ds_map_find_value(global.attribute, "Magic_Power"), ds_map_find_value(global.attribute, "Bonus_Range"))
scr_skill_atr(8)
startcast_sprite_tag = "s_spell_celestial_strike_cast_"
ignore_interact = 1
click_snd = snd_AetherShield_loop
cast_speech = "celestial_strike"
filter = gml_Script_scr_barrier_filter
is_missile = 1