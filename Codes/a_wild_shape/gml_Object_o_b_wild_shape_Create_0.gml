event_inherited()
scr_buff_atr()
stack = 1
first_turn = 1
feral = 0
draw_duration = 0 // Hide the 9999 turns the buff has
have_duration = 0 // Make infinite
with (o_pass_skill_feral_nature)
{
	if is_open
		other.feral = 1
}
bear = 0
with (o_pass_skill_bear_aspect)
{
	if is_open
		other.bear = 1
}
if (bear)
    buff_snd = snd_bear_agr_phase1
else
    buff_snd = snd_wolf_howl_1