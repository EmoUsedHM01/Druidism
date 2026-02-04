event_inherited()
scr_param("Fox", true, "Neutral")
scr_create_skill_map("Dash")
shadow_spr = s_shadow_big
footsteps_sprite = s_footsteps_predator
targ = instance_furthest(x, y, o_oak)
ds_list_clear(weapon_impact)
ds_list_clear(emo_sound)
ds_list_add(idle_animation, s_fox_idle)
alert_snd = choose(snd_forest_fox_alert_1, snd_forest_fox_alert_2, snd_forest_fox_alert_3)
emo_death_sound = choose(snd_fox_death_1, snd_fox_death_2, snd_fox_death_3)
ds_list_add(emo_sound, snd_fox_emotion_1, snd_fox_emotion_2, snd_fox_emotion_3)
ds_list_add(cought_list, snd_cough_medium_animals_1, snd_cough_medium_animals_2, snd_cough_medium_animals_3, snd_cough_medium_animals_4)
animation_CD = 0
netSize = "small"
netOffset = [3, 0]
netWaterDeepOffset = [0, 4]
netWaterDeepDrawLimit = 23
waterwaveShallowOffset = [4, 2]
waterwaveDeepOffset = [0, 4]

// Follower additions
master = o_player
faction_key = "Neutral"
subfaction_key = "Neutral"
ai_script = scr_enemy_choose_state
can_talk = false
can_speak = false
occupation = "companion"
is_enemy = false
ai_is_on = true
follower_type = "fox"
follower_owner = noone
if (instance_exists(o_player))
	follower_owner = o_player.id