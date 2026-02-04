event_inherited()
scr_param("Snake", true, "Neutral")
scr_create_skill_passive(o_enemy_pass_snake_stealth)
shadow_spr = s_snake01_shadow
ds_list_clear(weapon_impact)
ds_list_clear(emo_sound)
ds_list_add(weapon_impact, snd_snake_attack_1, snd_snake_attack_2, snd_snake_attack_3)
netSize = "small"

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
follower_type = "snake"
follower_owner = noone
if (instance_exists(o_player))
	follower_owner = o_player.id