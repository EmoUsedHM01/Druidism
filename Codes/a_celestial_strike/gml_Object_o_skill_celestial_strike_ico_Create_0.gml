event_inherited()
ds_list_add(global.speech_text,
	"celestial_strike", "Maka Shmeimit!", "celestial_strike_end",
	"MC_celestial_strike", "Maka Shm... Eimit...", "MC_celestial_strike_end"
)
child_skill = o_skill_celestial_strike
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["PRC", "WIL"]
attributes_value_to_open = 1
level_to_open = 1
tier_to_open = global.druidism_tier1