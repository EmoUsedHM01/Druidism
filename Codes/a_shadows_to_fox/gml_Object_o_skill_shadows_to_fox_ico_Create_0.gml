event_inherited()
ds_list_add(global.speech_text,
	"shadows_to_fox", "Foshia le Shanin!", "shadows_to_fox_end",
	"MC_shadows_to_fox", "Foshia le... Shanin?", "MC_shadows_to_fox_end"
)
child_skill = o_skill_shadows_to_fox
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["Vitality", "WIL"]
attributes_value_to_open = 7
level_to_open = 12
tier_to_open = global.druidism_tier1