if __is_undefined(ds_map_find_value(global.buff_name_text, "o_b_druid_summon"))
{
    ds_map_add(global.buff_name_text, "o_b_druid_summon", "This is the Druidism summon AI")
    ds_map_add(global.buff_desc_text, "o_b_druid_summon", "I just use a this buff as an AI check. Think of it a little like mind-control ^^")
}
event_inherited()
light = -4
index = 0
stack = 1
max_stage = 1
scr_buff_atr()
buff_snd = -4
have_duration = 0
draw_duration = 0
check = 0
executed = 0
selected_positionX = -4
selected_positionY = -4
selected_target = -4
adjacent_enemies = 0
timer = 0
druid_hp_fixed = false