event_inherited()
ds_list_add(global.speech_text,
	"stick_to_snake", "Vaihiu le Taninim!", "stick_to_snake_end",
	"MC_stick_to_snake", "Vaihiu le... Nahashim?", "MC_stick_to_snake_end"
)
child_skill = o_skill_stick_to_snake
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["Vitality", "WIL"]
attributes_value_to_open = 1
level_to_open = 1
tier_to_open = global.druidism_tier1