event_inherited()
ds_list_add(global.speech_text,
	"wild_shape", "Veheheye ka Zehev...", "wild_shape_end",
	"MC_wild_shape", "Veheheye ka Enda...", "MC_wild_shape_end"
)
child_skill = o_skill_wild_shape
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["STR", "Vitality"]
attributes_value_to_open = 4
level_to_open = 6
tier_to_open = global.druidism_tier1
