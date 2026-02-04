event_inherited()
ds_list_add(global.speech_text,
	"butterflies_to_hornets", "Parparim le Tzraot!", "butterflies_to_hornets_end",
	"MC_butterflies_to_hornets", "Parpar le Dvora?!?", "MC_butterflies_to_hornets_end"
)
child_skill = o_skill_butterflies_to_hornets
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["Vitality", "WIL"]
attributes_value_to_open = 12
level_to_open = 18
tier_to_open = global.druidism_tier1
